using MediatR;

namespace ECommerceSample.Application.CQRS.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQueryRequest : IRequest<List<GetAllCategoriesQueryResponse>>
{
}