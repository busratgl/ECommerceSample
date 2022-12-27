using MediatR;

namespace ECommerceSample.Application.CQRS.Users.Commands.UpdateUser;

public class UpdateUserCommandRequest : IRequest<UpdateUserCommandResponse>
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string EmailAddress { get; set; }
    public string PasswordText { get; set; }
}