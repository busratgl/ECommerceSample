namespace ECommerceSample.Application.CQRS.Users.Queries.GetUserById;

public class GetUserByIdQueryResponse
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}