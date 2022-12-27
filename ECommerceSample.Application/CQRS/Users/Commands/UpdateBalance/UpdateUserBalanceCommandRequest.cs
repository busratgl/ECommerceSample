using MediatR;

namespace ECommerceSample.Application.CQRS.Users.Commands.UpdateBalance;

public class UpdateUserBalanceCommandRequest : IRequest<UpdateUserBalanceCommandResponse>
{
    public long Id { get; set; }
    public decimal Amount { get; set; }
}