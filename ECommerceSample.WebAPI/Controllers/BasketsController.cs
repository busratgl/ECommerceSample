using ECommerceSample.Application.CQRS.Baskets.Commands.CreateBasket;
using ECommerceSample.Application.CQRS.Baskets.Commands.DeleteBasket;
using ECommerceSample.Application.CQRS.Baskets.Commands.UpdateBasket;
using ECommerceSample.Application.CQRS.Baskets.Queries.GetAllBaskets;
using ECommerceSample.Application.CQRS.Baskets.Queries.GetBasketById;
using ECommerceSample.Application.Requests.Baskets;
using ECommerceSample.Application.Responses.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSample.WebAPI.Controllers;

public class BasketsController : BaseController
{
    private readonly IMediator _mediator;

    public BasketsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<Result<List<GetAllBasketsQueryResponse>>> GetAllBaskets(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllBasketsQueryRequest(), cancellationToken);
        return new Result<List<GetAllBasketsQueryResponse>>(ResultStatus.Success, response);
    }

    [HttpGet("{id}")]
    public async Task<Result<GetBasketByIdQueryResponse>> GetBasketById([FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var request = new GetBasketByIdQueryRequest()
        {
            Id = id
        };

        var response = await _mediator.Send(request, cancellationToken);
        return new Result<GetBasketByIdQueryResponse>(ResultStatus.Success, response);
    }

    [HttpPost]
    public async Task<Result<CreateBasketCommandResponse>> CreateBasket([FromBody] CreateBasketRequest request,
        CancellationToken cancellationToken)
    {
        var handlerRequest = new CreateBasketCommandRequest()
        {
            UserId = request.UserId
        };

        var response = await _mediator.Send(handlerRequest, cancellationToken);
        return new Result<CreateBasketCommandResponse>(ResultStatus.Success, response);
    }

    [HttpPut("{id}")]
    public async Task<Result<UpdateBasketCommandResponse>> UpdateBasket([FromRoute] long id,
        [FromBody] UpdateBasketRequest request,
        CancellationToken
            cancellationToken)
    {
        var handlerRequest = new UpdateBasketCommandRequest()
        {
            Id = id
        };

        var response = await _mediator.Send(handlerRequest, cancellationToken);
        return new Result<UpdateBasketCommandResponse>(ResultStatus.Success, response);
    }

    [HttpDelete("{id}")]
    public async Task<Result<DeleteBasketCommandResponse>> DeleteBasket([FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var request = new DeleteBasketCommandRequest()
        {
            Id = id
        };

        var response = await _mediator.Send(request, cancellationToken);
        return new Result<DeleteBasketCommandResponse>(ResultStatus.Success, response);
    }
}