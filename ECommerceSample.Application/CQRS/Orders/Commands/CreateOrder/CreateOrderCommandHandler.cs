using DotNetCore.CAP;
using ECommerceSample.Application.Messaging.OrderCreated;
using ECommerceSample.Application.Repositories.BasketItem;
using ECommerceSample.Application.Repositories.Order;
using ECommerceSample.Application.Repositories.OrderItem;
using ECommerceSample.Application.Repositories.User;
using ECommerceSample.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSample.Application.CQRS.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
{
    private readonly IOrderWriteRepository _orderWriteRepository;
    private readonly IBasketItemWriteRepository _basketItemWriteRepository;
    private readonly IOrderItemWriteRepository _orderItemWriteRepository;
    private readonly IUserReadRepository _userReadRepository;
    private readonly ICapPublisher _capPublisher;

    public CreateOrderCommandHandler(IOrderWriteRepository orderWriteRepository,
        IBasketItemWriteRepository basketItemWriteRepository,
        IOrderItemWriteRepository orderItemWriteRepository,
        IUserReadRepository userReadRepository,
        ICapPublisher capPublisher)
    {
        _orderWriteRepository = orderWriteRepository;
        _basketItemWriteRepository = basketItemWriteRepository;
        _orderItemWriteRepository = orderItemWriteRepository;
        _userReadRepository = userReadRepository;
        _capPublisher = capPublisher;
    }

    public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _userReadRepository.Table.AsNoTracking()
            .Include(u => u.Basket)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken: cancellationToken);

        var order = new Order()
        {
            Description = request.Description,
            Address = request.Address,
            UserId = user.Id
        };

        var isSuccess = await _orderWriteRepository.CreateAsync(order);
        await _orderWriteRepository.SaveAsync();

        var basketItems =
            await _basketItemWriteRepository.Table.Where(x => x.BasketId == user.Basket.Id)
                .ToListAsync(cancellationToken: cancellationToken);

        foreach (var basketItem in basketItems)
        {
            var orderItem = new OrderItem
            {
                OrderId = order.Id,
                ProductId = basketItem.ProductId
            };

            await _orderItemWriteRepository.CreateAsync(orderItem);

            basketItem.IsDeleted = true;
        }

        await _basketItemWriteRepository.SaveAsync();
        await _orderItemWriteRepository.SaveAsync();

        await _capPublisher.PublishAsync("order.created", new OrderCreatedEvent()
        {
            OrderId = order.Id
        }, cancellationToken: cancellationToken);

        return new CreateOrderCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}