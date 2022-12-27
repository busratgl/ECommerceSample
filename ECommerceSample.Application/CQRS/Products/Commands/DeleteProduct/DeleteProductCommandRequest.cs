using MediatR;

namespace ECommerceSample.Application.CQRS.Products.Commands.DeleteProduct;

public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
{
    public long Id { get; set; }

}