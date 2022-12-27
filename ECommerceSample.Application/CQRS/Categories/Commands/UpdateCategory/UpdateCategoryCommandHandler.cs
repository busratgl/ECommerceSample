using ECommerceSample.Application.Repositories.Category;
using MediatR;

namespace ECommerceSample.Application.CQRS.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
{
    private readonly ICategoryWriteRepository _categoryWriteRepository;

    public UpdateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository)
    {
        _categoryWriteRepository = categoryWriteRepository;
    }

    public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request,
        CancellationToken cancellationToken)
    {
        var category = await _categoryWriteRepository.FindAsync(request.Id);

        category.Name = request.Name;
        category.Description = request.Description;

        var isSuccess = _categoryWriteRepository.Update(category);
        await _categoryWriteRepository.SaveAsync();

        return new UpdateCategoryCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}