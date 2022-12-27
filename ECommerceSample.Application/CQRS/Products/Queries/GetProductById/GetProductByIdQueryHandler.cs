using ECommerceSample.Application.Repositories.Product;
using MediatR;

namespace ECommerceSample.Application.CQRS.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
{
    private readonly IProductReadRepository _productReadRepository;

    public GetProductByIdQueryHandler(IProductReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }

    public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var product = await _productReadRepository.GetByIdAsync(request.Id);
        return new GetProductByIdQueryResponse()
        {
            Id = product.Id,
            Name = product.Name,
            UnitsInStock = product.UnitsInStock,
            Price = product.Price,
            CategoryId = product.CategoryId
        };
    }
}