using ECommerceSample.Application.Repositories.Order;
using MediatR;

namespace ECommerceSample.Application.CQRS.Orders.Commands.UpdateOrder;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, UpdateOrderCommandResponse>
{
    private readonly IOrderWriteRepository _orderWriteRepository;

    public UpdateOrderCommandHandler(IOrderWriteRepository orderWriteRepository)
    {
        _orderWriteRepository = orderWriteRepository;
    }

    public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommandRequest request,
        CancellationToken cancellationToken)
    {
        var order = await _orderWriteRepository.FindAsync(request.Id);

        order.Description = request.Description;
        order.Address = request.Address;

        var isSuccess = _orderWriteRepository.Update(order);
        await _orderWriteRepository.SaveAsync();

        return new UpdateOrderCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}