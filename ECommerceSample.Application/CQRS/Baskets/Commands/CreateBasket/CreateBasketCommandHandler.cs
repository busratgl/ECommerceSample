using ECommerceSample.Application.Repositories.Basket;
using ECommerceSample.Domain.Entities;
using MediatR;

namespace ECommerceSample.Application.CQRS.Baskets.Commands.CreateBasket;

public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommandRequest, CreateBasketCommandResponse>
{
    private readonly IBasketWriteRepository _basketWriteRepository;

    public CreateBasketCommandHandler(IBasketWriteRepository basketWriteRepository)
    {
        _basketWriteRepository = basketWriteRepository;
    }

    public async Task<CreateBasketCommandResponse> Handle(CreateBasketCommandRequest request,
        CancellationToken cancellationToken)
    {
        var basket = new Basket()
        {
            UserId = request.UserId
        };

        var isSuccess = await _basketWriteRepository.CreateAsync(basket);
        await _basketWriteRepository.SaveAsync();

        return new CreateBasketCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}