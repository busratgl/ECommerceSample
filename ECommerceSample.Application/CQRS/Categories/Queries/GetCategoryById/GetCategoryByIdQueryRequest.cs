using MediatR;

namespace ECommerceSample.Application.CQRS.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryRequest : IRequest<GetCategoryByIdQueryResponse>
{
    public long Id { get; set; }
}