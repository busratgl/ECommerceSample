using MediatR;

namespace ECommerceSample.Application.CQRS.BasketItems.Commands.DeleteBasketItem;

public class DeleteBasketItemCommandRequest : IRequest<DeleteBasketItemCommandResponse>
{
    public long Id { get; set; }
}