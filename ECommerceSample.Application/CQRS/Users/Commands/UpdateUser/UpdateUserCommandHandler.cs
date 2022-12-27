using ECommerceSample.Application.Repositories.User;
using MediatR;

namespace ECommerceSample.Application.CQRS.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
{
    private readonly IUserWriteRepository _userWriteRepository;

    public UpdateUserCommandHandler(IUserWriteRepository userWriteRepository)
    {
        _userWriteRepository = userWriteRepository;
    }

    public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _userWriteRepository.FindAsync(request.Id);

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.BirthDate = request.BirthDate;
        user.PhoneNumber = request.PhoneNumber;
        user.Address = request.Address;
        user.EmailAddress = request.EmailAddress;
        user.PasswordText = request.PasswordText;

        var isSuccess = _userWriteRepository.Update(user);
        await _userWriteRepository.SaveAsync();

        return new UpdateUserCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}