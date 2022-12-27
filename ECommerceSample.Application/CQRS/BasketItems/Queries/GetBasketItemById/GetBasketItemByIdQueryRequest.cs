using MediatR;

namespace ECommerceSample.Application.CQRS.BasketItems.Queries.GetBasketItemById;

public class GetBasketItemByIdQueryRequest : IRequest<GetBasketItemByIdQueryResponse>
{
    public long Id { get; set; }
}