using ECommerceSample.Application.Repositories.BasketItem;
using MediatR;

namespace ECommerceSample.Application.CQRS.BasketItems.Queries.GetBasketItemById;

public class
    GetBasketItemByIdQueryHandler : IRequestHandler<GetBasketItemByIdQueryRequest, GetBasketItemByIdQueryResponse>
{
    private readonly IBasketItemReadRepository _basketItemReadRepository;

    public GetBasketItemByIdQueryHandler(IBasketItemReadRepository basketItemReadRepository)
    {
        _basketItemReadRepository = basketItemReadRepository;
    }

    public async Task<GetBasketItemByIdQueryResponse> Handle(GetBasketItemByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var basketItem = await _basketItemReadRepository.GetByIdAsync(request.Id);
        return new GetBasketItemByIdQueryResponse()
        {
            Id = basketItem.Id,
        };
    }
}