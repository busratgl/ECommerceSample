using MediatR;

namespace ECommerceSample.Application.CQRS.Orders.Commands.UpdateOrder;

public class UpdateOrderCommandRequest : IRequest<UpdateOrderCommandResponse>
{
    public long Id { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
}