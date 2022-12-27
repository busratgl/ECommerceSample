using ECommerceSample.Application.Repositories.Category;
using ECommerceSample.Domain.Entities;
using MediatR;

namespace ECommerceSample.Application.CQRS.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
{
    private readonly ICategoryWriteRepository _categoryWriteRepository;

    public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository)
    {
        _categoryWriteRepository = categoryWriteRepository;
    }

    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request,
        CancellationToken cancellationToken)
    {
        var category = new Category()
        {
            Name = request.Name,
            Description = request.Description
        };

        var isSuccess = await _categoryWriteRepository.CreateAsync(category);
        await _categoryWriteRepository.SaveAsync();

        return new CreateCategoryCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}