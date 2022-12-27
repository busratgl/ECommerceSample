using MediatR;

namespace ECommerceSample.Application.CQRS.Orders.Queries.GetOrderById;

public class GetOrderByIdQueryRequest : IRequest<GetOrderByIdQueryResponse>
{
    public long Id { get; set; }
}