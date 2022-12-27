using ECommerceSample.Application.Repositories.User;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSample.Application.CQRS.Users.Queries.GetAllUsers;

public class
    GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryRequest, List<GetAllUsersQueryResponse>>
{
    private readonly IUserReadRepository _userReadRepository;

    public GetAllUsersQueryHandler(IUserReadRepository userReadRepository)
    {
        _userReadRepository = userReadRepository;
    }

    public async Task<List<GetAllUsersQueryResponse>> Handle(GetAllUsersQueryRequest request,
        CancellationToken cancellationToken)
    {
        var users = await _userReadRepository.GetAll().ToListAsync(cancellationToken: cancellationToken);

        return users.Select(c => new GetAllUsersQueryResponse()
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName
        }).ToList();
    }
}