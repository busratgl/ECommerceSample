using ECommerceSample.Application.Repositories.BasketItem;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSample.Application.CQRS.BasketItems.Queries.GetAllBasketItems;

public class
    GetAllBasketItemsQueryHandler : IRequestHandler<GetAllBasketItemsQueryRequest, List<GetAllBasketItemsQueryResponse>>
{
    private readonly IBasketItemReadRepository _basketItemReadRepository;

    public async Task<List<GetAllBasketItemsQueryResponse>> Handle(GetAllBasketItemsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var basketItems = await _basketItemReadRepository.GetAll().ToListAsync(cancellationToken: cancellationToken);

        return basketItems.Select(p => new GetAllBasketItemsQueryResponse()
        {
            //bind
        }).ToList();
    }
}