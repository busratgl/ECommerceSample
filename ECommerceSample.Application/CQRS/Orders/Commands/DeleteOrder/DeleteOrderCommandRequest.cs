using MediatR;

namespace ECommerceSample.Application.CQRS.Orders.Commands.DeleteOrder;

public class DeleteOrderCommandRequest : IRequest<DeleteOrderCommandResponse>
{
    public long Id { get; set; }
}