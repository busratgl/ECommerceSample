using ECommerceSample.Application.Repositories.Order;
using MediatR;

namespace ECommerceSample.Application.CQRS.Orders.Commands.DeleteOrder;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, DeleteOrderCommandResponse>
{
    private readonly IOrderWriteRepository _orderWriteRepository;

    public DeleteOrderCommandHandler(IOrderWriteRepository orderWriteRepository)
    {
        _orderWriteRepository = orderWriteRepository;
    }

    public async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest request,
        CancellationToken cancellationToken)
    {
        var order = await _orderWriteRepository.FindAsync(request.Id);
        order.IsDeleted = true;

        var isSuccess = _orderWriteRepository.Update(order);
        await _orderWriteRepository.SaveAsync();

        return new DeleteOrderCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}