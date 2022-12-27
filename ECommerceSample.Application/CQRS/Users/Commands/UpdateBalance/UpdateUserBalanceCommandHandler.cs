using ECommerceSample.Application.Repositories.User;
using MediatR;

namespace ECommerceSample.Application.CQRS.Users.Commands.UpdateBalance;

public class
    UpdateUserBalanceCommandHandler : IRequestHandler<UpdateUserBalanceCommandRequest, UpdateUserBalanceCommandResponse>
{
    private readonly IUserWriteRepository _userWriteRepository;

    public UpdateUserBalanceCommandHandler(IUserWriteRepository userWriteRepository)
    {
        _userWriteRepository = userWriteRepository;
    }

    public async Task<UpdateUserBalanceCommandResponse> Handle(UpdateUserBalanceCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _userWriteRepository.FindAsync(request.Id);
        user.Balance = user.Balance - request.Amount;
        
        var isSuccess = _userWriteRepository.Update(user);
        await _userWriteRepository.SaveAsync();

        return new UpdateUserBalanceCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}