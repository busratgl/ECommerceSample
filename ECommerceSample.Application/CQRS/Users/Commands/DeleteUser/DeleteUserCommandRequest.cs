using MediatR;

namespace ECommerceSample.Application.CQRS.Users.Commands.DeleteUser;

public class DeleteUserCommandRequest : IRequest<DeleteUserCommandResponse>
{
    public long Id { get; set; }
}