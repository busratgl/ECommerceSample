using ECommerceSample.Application.Repositories;
using ECommerceSample.Application.Repositories.Category;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSample.Application.CQRS.Categories.Queries.GetAllCategories;

public class
    GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, List<GetAllCategoriesQueryResponse>>
{
    private readonly ICategoryReadRepository _categoryReadRepository;

    public GetAllCategoriesQueryHandler(ICategoryReadRepository categoryReadRepository)
    {
        _categoryReadRepository = categoryReadRepository;
    }

    public async Task<List<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var categories = await _categoryReadRepository.GetAll().ToListAsync(cancellationToken: cancellationToken);

        return categories.Select(c => new GetAllCategoriesQueryResponse()
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();
    }
}