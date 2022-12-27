using ECommerceSample.Application.CQRS.Users.Commands.CreateUser;
using ECommerceSample.Application.CQRS.Users.Commands.DeleteUser;
using ECommerceSample.Application.CQRS.Users.Commands.UpdateBalance;
using ECommerceSample.Application.CQRS.Users.Commands.UpdateUser;
using ECommerceSample.Application.CQRS.Users.Queries.GetAllUsers;
using ECommerceSample.Application.CQRS.Users.Queries.GetUserById;
using ECommerceSample.Application.Requests.Users;
using ECommerceSample.Application.Responses.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSample.WebAPI.Controllers;

public class UsersController : BaseController
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<Result<List<GetAllUsersQueryResponse>>> GetAllUsers(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllUsersQueryRequest(), cancellationToken);
        return new Result<List<GetAllUsersQueryResponse>>(ResultStatus.Success, response);
    }

    [HttpGet("{id}")]
    public async Task<Result<GetUserByIdQueryResponse>> GetUserById([FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var request = new GetUserByIdQueryRequest()
        {
            Id = id
        };

        var response = await _mediator.Send(request, cancellationToken);
        return new Result<GetUserByIdQueryResponse>(ResultStatus.Success, response);
    }

    [HttpPost]
    public async Task<Result<CreateUserCommandResponse>> CreateUser([FromBody] CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        var handlerRequest = new CreateUserCommandRequest()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Address = request.Address,
            BirthDate = request.BirthDate,
            PhoneNumber = request.PhoneNumber,
            EmailAddress = request.EmailAddress,
            PasswordText = request.PasswordText
        };

        var response = await _mediator.Send(handlerRequest, cancellationToken);
        return new Result<CreateUserCommandResponse>(ResultStatus.Success, response);
    }

    [HttpPut("{id}")]
    public async Task<Result<UpdateUserCommandResponse>> UpdateUser([FromRoute] long id,
        [FromBody] UpdateUserRequest request,
        CancellationToken
            cancellationToken)
    {
        var handlerRequest = new UpdateUserCommandRequest()
        {
            Id = id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Address = request.Address,
            BirthDate = request.BirthDate,
            PhoneNumber = request.PhoneNumber,
            EmailAddress = request.EmailAddress,
            PasswordText = request.PasswordText
        };

        var response = await _mediator.Send(handlerRequest, cancellationToken);
        return new Result<UpdateUserCommandResponse>(ResultStatus.Success, response);
    }

    [HttpDelete("{id}")]
    public async Task<Result<DeleteUserCommandResponse>> DeleteUser([FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var request = new DeleteUserCommandRequest()
        {
            Id = id
        };

        var response = await _mediator.Send(request, cancellationToken);
        return new Result<DeleteUserCommandResponse>(ResultStatus.Success, response);
    }

    [HttpPut]
    public async Task<Result<UpdateUserBalanceCommandResponse>> UpdateUserBalance([FromRoute] long id,
        [FromBody] UpdateUserBalanceRequest request,
        CancellationToken
            cancellationToken)
    {
        var handlerRequest = new UpdateUserBalanceCommandRequest()
        {
            Id = id,
            Amount = request.Amount
        };
        var response = await _mediator.Send(handlerRequest, cancellationToken);
        return new Result<UpdateUserBalanceCommandResponse>(ResultStatus.Success, response);
    }
}