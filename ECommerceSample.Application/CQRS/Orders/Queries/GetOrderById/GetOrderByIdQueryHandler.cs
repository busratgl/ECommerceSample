using ECommerceSample.Application.Repositories;
using ECommerceSample.Application.Repositories.Order;
using MediatR;

namespace ECommerceSample.Application.CQRS.Orders.Queries.GetOrderById;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQueryRequest, GetOrderByIdQueryResponse>
{
    private readonly IOrderReadRepository _orderReadRepository;

    public GetOrderByIdQueryHandler(IOrderReadRepository orderReadRepository)
    {
        _orderReadRepository = orderReadRepository;
    }

    public async Task<GetOrderByIdQueryResponse> Handle(GetOrderByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var order = await _orderReadRepository.GetByIdAsync(request.Id);
        
        return new GetOrderByIdQueryResponse()
        {
            Id = order.Id,
            Description = order.Description
        };
    }
}