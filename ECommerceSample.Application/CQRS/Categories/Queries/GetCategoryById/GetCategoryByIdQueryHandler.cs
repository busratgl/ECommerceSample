using ECommerceSample.Application.Repositories;
using ECommerceSample.Application.Repositories.Category;
using MediatR;

namespace ECommerceSample.Application.CQRS.Categories.Queries.GetCategoryById;

public class
    GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, GetCategoryByIdQueryResponse>
{
    private readonly ICategoryReadRepository _categoryReadRepository;

    public GetCategoryByIdQueryHandler(ICategoryReadRepository categoryReadRepository)
    {
        _categoryReadRepository = categoryReadRepository;
    }

    public async Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var category = await _categoryReadRepository.GetByIdAsync(request.Id);
        return new GetCategoryByIdQueryResponse()
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}