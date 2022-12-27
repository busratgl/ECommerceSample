using MediatR;

namespace ECommerceSample.Application.CQRS.Products.Queries.GetProductById;

public class GetProductByIdQueryRequest : IRequest<GetProductByIdQueryResponse>
{
    public long Id { get; set; }
}