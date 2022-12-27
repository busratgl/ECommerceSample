using ECommerceSample.Application.Repositories.User;
using ECommerceSample.Domain.Entities;
using MediatR;

namespace ECommerceSample.Application.CQRS.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    private readonly IUserWriteRepository _userWriteRepository;

    public CreateUserCommandHandler(IUserWriteRepository userWriteRepository)
    {
        _userWriteRepository = userWriteRepository;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = new User()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            BirthDate = request.BirthDate,
            PhoneNumber = request.PhoneNumber,
            Address = request.Address,
            EmailAddress = request.EmailAddress,
            PasswordText = request.PasswordText
        };

        var isSuccess = await _userWriteRepository.CreateAsync(user);
        await _userWriteRepository.SaveAsync();

        return new CreateUserCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}