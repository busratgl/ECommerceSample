using MediatR;

namespace ECommerceSample.Application.CQRS.Categories.Commands.CreateCategory;

public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
}