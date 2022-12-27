using MediatR;

namespace ECommerceSample.Application.CQRS.Orders.Queries.GetAllOrders;

public class GetAllOrdersQueryRequest : IRequest<List<GetAllOrdersQueryResponse>>
{
}