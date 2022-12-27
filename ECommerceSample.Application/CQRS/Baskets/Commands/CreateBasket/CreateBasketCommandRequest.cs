using MediatR;

namespace ECommerceSample.Application.CQRS.Baskets.Commands.CreateBasket;

public class CreateBasketCommandRequest : IRequest<CreateBasketCommandResponse>
{
    public long UserId { get; set; }
}