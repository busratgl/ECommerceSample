using ECommerceSample.Application.Repositories;
using ECommerceSample.Application.Repositories.Order;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSample.Application.CQRS.Orders.Queries.GetAllOrders;

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQueryRequest, List<GetAllOrdersQueryResponse>>
{
    private readonly IOrderReadRepository _orderReadRepository;

    public GetAllOrdersQueryHandler(IOrderReadRepository orderReadRepository)
    {
        _orderReadRepository = orderReadRepository;
    }

    public async Task<List<GetAllOrdersQueryResponse>> Handle(GetAllOrdersQueryRequest request,
        CancellationToken cancellationToken)
    {
        var orders = await _orderReadRepository.GetAll().ToListAsync(cancellationToken: cancellationToken);

        return orders.Select(order => new GetAllOrdersQueryResponse()
        {
            Id = order.Id,
            Description = order.Description
        }).ToList();
    }
}