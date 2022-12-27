using ECommerceSample.Application.Repositories.Product;
using ECommerceSample.Domain.Entities;
using MediatR;

namespace ECommerceSample.Application.CQRS.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    private readonly IProductWriteRepository _productWriteRepository;

    public CreateProductCommandHandler(IProductWriteRepository productWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
    }

    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request,
        CancellationToken cancellationToken)
    {
        var product = new Product()
        {
            Name = request.Name,
            Price = request.Price,
            UnitsInStock = request.UnitsInStock,
            CategoryId = request.CategoryId
        };
        
        var isSuccess = await _productWriteRepository.CreateAsync(product);
        await _productWriteRepository.SaveAsync();

        return new CreateProductCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}