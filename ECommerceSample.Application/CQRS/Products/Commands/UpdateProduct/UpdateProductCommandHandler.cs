using ECommerceSample.Application.Repositories.Product;
using MediatR;

namespace ECommerceSample.Application.CQRS.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
{
    private readonly IProductWriteRepository _productWriteRepository;

    public UpdateProductCommandHandler(IProductWriteRepository productWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
    }

    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request,
        CancellationToken cancellationToken)
    {
        var product = await _productWriteRepository.FindAsync(request.Id);
        
        product.Name = request.Name;
        product.Price = request.Price;
        product.UnitsInStock = request.UnitsInStock;
        product.CategoryId = request.CategoryId;

        var isSuccess = _productWriteRepository.Update(product);
        await _productWriteRepository.SaveAsync();
        
        return new UpdateProductCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}