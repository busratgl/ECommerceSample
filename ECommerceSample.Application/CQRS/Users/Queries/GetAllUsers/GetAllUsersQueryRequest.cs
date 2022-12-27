using MediatR;

namespace ECommerceSample.Application.CQRS.Users.Queries.GetAllUsers;

public class GetAllUsersQueryRequest : IRequest<List<GetAllUsersQueryResponse>>
{
}