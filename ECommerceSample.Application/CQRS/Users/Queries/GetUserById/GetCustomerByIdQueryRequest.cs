using MediatR;

namespace ECommerceSample.Application.CQRS.Users.Queries.GetUserById;

public class GetUserByIdQueryRequest : IRequest<GetUserByIdQueryResponse>
{
    public long Id { get; set; }
}