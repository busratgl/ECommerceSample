using ECommerceSample.Application.Repositories.Product;
using MediatR;

namespace ECommerceSample.Application.CQRS.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
{
    private readonly IProductWriteRepository _productWriteRepository;

    public DeleteProductCommandHandler(IProductWriteRepository productWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
    }

    public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request,
        CancellationToken cancellationToken)
    {
        var product = await _productWriteRepository.FindAsync(request.Id);
        product.IsDeleted = true;

        var isSuccess = _productWriteRepository.Update(product);
        await _productWriteRepository.SaveAsync();

        return new DeleteProductCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}

