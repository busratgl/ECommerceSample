using DotNetCore.CAP;
using ECommerceSample.Application.Messaging.OrderCreated;
using ECommerceSample.Application.Repositories.BasketItem;
using ECommerceSample.Application.Repositories.Order;
using ECommerceSample.Application.Repositories.OrderItem;
using ECommerceSample.Application.Repositories.User;
using ECommerceSample.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceSample.Application.CQRS.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
{
    private readonly IServiceProvider _serviceProvider;

    public CreateOrderCommandHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request,
        CancellationToken cancellationToken)
    {
        var orderWriteRepository = _serviceProvider.GetService<IOrderWriteRepository>();
        var basketItemWriteRepository = _serviceProvider.GetService<IBasketItemWriteRepository>();
        var orderItemWriteRepository = _serviceProvider.GetService<IOrderItemWriteRepository>();
        var userReadRepository = _serviceProvider.GetService<IUserReadRepository>();
        var capPublisher = _serviceProvider.GetService<ICapPublisher>();
        
        var user = await userReadRepository.SingleGetAsync(x=> x.Id == request.UserId);

        var order = new Order()
        {
            Description = request.Description,
            Address = request.Address,
            UserId = user.Id
        };

        var isSuccess = await orderWriteRepository.CreateAsync(order);
        await orderWriteRepository.SaveAsync();

        var basketItems =
            await basketItemWriteRepository.Table.Where(x => x.BasketId == user.Basket.Id)
                .ToListAsync(cancellationToken: cancellationToken);

        foreach (var basketItem in basketItems)
        {
            var orderItem = new OrderItem
            {
                OrderId = order.Id,
                ProductId = basketItem.ProductId
            };

            await orderItemWriteRepository.CreateAsync(orderItem);

            basketItem.IsDeleted = true;
        }

        await basketItemWriteRepository.SaveAsync();
        await orderItemWriteRepository.SaveAsync();

        await capPublisher.PublishAsync("order.created", new OrderCreatedEvent()
        {
            OrderId = order.Id
        }, cancellationToken: cancellationToken);

        return new CreateOrderCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}