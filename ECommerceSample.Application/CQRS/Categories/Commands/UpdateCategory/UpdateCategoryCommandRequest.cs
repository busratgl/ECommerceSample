using MediatR;

namespace ECommerceSample.Application.CQRS.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}