using ECommerceSample.Application.Repositories.User;
using MediatR;

namespace ECommerceSample.Application.CQRS.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
{
    private readonly IUserWriteRepository _userWriteRepository;

    public DeleteUserCommandHandler(IUserWriteRepository userWriteRepository)
    {
        _userWriteRepository = userWriteRepository;
    }

    public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _userWriteRepository.FindAsync(request.Id);
        user.IsDeleted = true;

        var isSuccess = _userWriteRepository.Update(user);
        await _userWriteRepository.SaveAsync();

        return new DeleteUserCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}