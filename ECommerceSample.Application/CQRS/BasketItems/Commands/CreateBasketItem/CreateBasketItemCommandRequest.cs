using MediatR;

namespace ECommerceSample.Application.CQRS.BasketItems.Commands.CreateBasketItem;

public class CreateBasketItemCommandRequest : IRequest<CreateBasketItemCommandResponse>
{
    public long ProductId { get; set; }
    public long BasketId { get; set; }
}