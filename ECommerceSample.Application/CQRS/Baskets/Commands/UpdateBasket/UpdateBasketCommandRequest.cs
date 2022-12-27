using MediatR;

namespace ECommerceSample.Application.CQRS.Baskets.Commands.UpdateBasket;

public class UpdateBasketCommandRequest : IRequest<UpdateBasketCommandResponse>
{
    public long Id { get; set; }
}