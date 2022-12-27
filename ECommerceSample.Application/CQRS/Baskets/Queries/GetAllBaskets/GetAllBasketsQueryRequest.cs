using MediatR;

namespace ECommerceSample.Application.CQRS.Baskets.Queries.GetAllBaskets;

public class GetAllBasketsQueryRequest : IRequest<List<GetAllBasketsQueryResponse>>
{
}