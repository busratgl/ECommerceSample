using ECommerceSample.Application.Repositories.User;
using MediatR;

namespace ECommerceSample.Application.CQRS.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
{
    private readonly IUserReadRepository _userReadRepository;

    public GetUserByIdQueryHandler(IUserReadRepository userReadRepository)
    {
        _userReadRepository = userReadRepository;
    }

    public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _userReadRepository.GetByIdAsync(request.Id);
        return new GetUserByIdQueryResponse()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
    }
}