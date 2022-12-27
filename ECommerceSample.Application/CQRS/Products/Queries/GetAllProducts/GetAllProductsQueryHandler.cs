using ECommerceSample.Application.Repositories.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSample.Application.CQRS.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<GetAllProductsQueryResponse>>
{
    private readonly IProductReadRepository _productReadRepository;

    public GetAllProductsQueryHandler(IProductReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }

    public async Task<List<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var products = await _productReadRepository.GetAll().ToListAsync(cancellationToken: cancellationToken);

        return products.Select(p => new GetAllProductsQueryResponse()
        {
            Id = p.Id,
            Name = p.Name,
            UnitsInStock = p.UnitsInStock,
            Price = p.Price,
            CategoryId = p.CategoryId
        }).ToList();
    }
}