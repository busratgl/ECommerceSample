using MediatR;

namespace ECommerceSample.Application.CQRS.BasketItems.Commands.UpdateBasketItem;

public class UpdateBasketItemCommandRequest : IRequest<UpdateBasketItemCommandResponse>
{
    public long Id { get; set; }
}