using MediatR;

namespace ECommerceSample.Application.CQRS.Baskets.Queries.GetBasketById;

public class GetBasketByIdQueryRequest : IRequest<GetBasketByIdQueryResponse>
{
    public long Id { get; set; }
}