using MediatR;

namespace ECommerceSample.Application.CQRS.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandRequest : IRequest<DeleteCategoryCommandResponse>
{
    public long Id { get; set; }
}