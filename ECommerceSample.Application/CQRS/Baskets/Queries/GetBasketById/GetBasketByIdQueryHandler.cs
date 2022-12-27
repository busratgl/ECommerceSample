using ECommerceSample.Application.Repositories.Basket;
using MediatR;

namespace ECommerceSample.Application.CQRS.Baskets.Queries.GetBasketById;

public class GetBasketByIdQueryHandler : IRequestHandler<GetBasketByIdQueryRequest, GetBasketByIdQueryResponse>
{
    private readonly IBasketReadRepository _basketReadRepository;

    public GetBasketByIdQueryHandler(IBasketReadRepository basketReadRepository)
    {
        _basketReadRepository = basketReadRepository;
    }

    public async Task<GetBasketByIdQueryResponse> Handle(GetBasketByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var basket = await _basketReadRepository.GetByIdAsync(request.Id);
        return new GetBasketByIdQueryResponse()
        {
            Id = basket.Id,
        };
    }
}