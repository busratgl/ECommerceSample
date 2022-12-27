using MediatR;

namespace ECommerceSample.Application.CQRS.BasketItems.Queries.GetAllBasketItems;

public class GetAllBasketItemsQueryRequest : IRequest<List<GetAllBasketItemsQueryResponse>>
{
}