using ECommerceSample.Application.Repositories.Basket;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSample.Application.CQRS.Baskets.Queries.GetAllBaskets;

public class GetAllBasketsQueryHandler : IRequestHandler<GetAllBasketsQueryRequest, List<GetAllBasketsQueryResponse>>
{
    private readonly IBasketReadRepository _basketReadRepository;

    public GetAllBasketsQueryHandler(IBasketReadRepository basketReadRepository)
    {
        _basketReadRepository = basketReadRepository;
    }

    public async Task<List<GetAllBasketsQueryResponse>> Handle(GetAllBasketsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var baskets = await _basketReadRepository.GetAll().ToListAsync(cancellationToken: cancellationToken);

        return baskets.Select(p => new GetAllBasketsQueryResponse()
        {
           //bind
        }).ToList();
    }
}