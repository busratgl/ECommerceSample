using MediatR;

namespace ECommerceSample.Application.CQRS.Products.Commands.UpdateProduct;

public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int UnitsInStock { get; set; }
    public decimal Price { get; set; }
    public long CategoryId { get; set; }
}