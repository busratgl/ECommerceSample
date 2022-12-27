namespace ECommerceSample.Application.CQRS.Users.Queries.GetAllUsers;

public class GetAllUsersQueryResponse
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}