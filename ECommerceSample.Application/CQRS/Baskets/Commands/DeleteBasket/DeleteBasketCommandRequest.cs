using MediatR;

namespace ECommerceSample.Application.CQRS.Baskets.Commands.DeleteBasket;

public class DeleteBasketCommandRequest : IRequest<DeleteBasketCommandResponse>
{
    public long Id { get; set; }
}