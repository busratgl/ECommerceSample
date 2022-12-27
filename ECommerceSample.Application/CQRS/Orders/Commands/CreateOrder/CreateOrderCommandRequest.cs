using MediatR;

namespace ECommerceSample.Application.CQRS.Orders.Commands.CreateOrder;

public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
{
    public string Description { get; set; }
    public string Address { get; set; }
    public long UserId { get; set; }
}