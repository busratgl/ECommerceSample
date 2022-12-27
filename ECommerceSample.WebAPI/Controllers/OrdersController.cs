using ECommerceSample.Application.CQRS.Orders.Commands.CreateOrder;
using ECommerceSample.Application.CQRS.Orders.Commands.DeleteOrder;
using ECommerceSample.Application.CQRS.Orders.Commands.UpdateOrder;
using ECommerceSample.Application.CQRS.Orders.Queries.GetAllOrders;
using ECommerceSample.Application.CQRS.Orders.Queries.GetOrderById;
using ECommerceSample.Application.Requests.Orders;
using ECommerceSample.Application.Responses.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSample.WebAPI.Controllers;

public class OrdersController : BaseController
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<Result<List<GetAllOrdersQueryResponse>>> GetAllOrders(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllOrdersQueryRequest(), cancellationToken);
        return new Result<List<GetAllOrdersQueryResponse>>(ResultStatus.Success, response);
    }

    [HttpGet("{id}")]
    public async Task<Result<GetOrderByIdQueryResponse>> GetOrderById([FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var request = new GetOrderByIdQueryRequest()
        {
            Id = id
        };

        var response = await _mediator.Send(request, cancellationToken);
        return new Result<GetOrderByIdQueryResponse>(ResultStatus.Success, response);
    }

    [HttpPost]
    public async Task<Result<CreateOrderCommandResponse>> CreateOrder([FromBody] CreateOrderRequest request,
        CancellationToken cancellationToken)
    {
        var handlerRequest = new CreateOrderCommandRequest()
        {
            Description = request.Description,
            Address = request.Address,
            UserId = request.UserId
        };

        var response = await _mediator.Send(handlerRequest, cancellationToken);
        return new Result<CreateOrderCommandResponse>(ResultStatus.Success, response);
    }

    [HttpPut("{id}")]
    public async Task<Result<UpdateOrderCommandResponse>> UpdateOrder([FromRoute] long id,
        [FromBody] UpdateOrderRequest request,
        CancellationToken
            cancellationToken)
    {
        var handlerRequest = new UpdateOrderCommandRequest()
        {
            Id = id,
            Description = request.Description,
            Address = request.Address
        };

        var response = await _mediator.Send(handlerRequest, cancellationToken);
        return new Result<UpdateOrderCommandResponse>(ResultStatus.Success, response);
    }

    [HttpDelete("{id}")]
    public async Task<Result<DeleteOrderCommandResponse>> DeleteOrder([FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var request = new DeleteOrderCommandRequest()
        {
            Id = id
        };

        var response = await _mediator.Send(request, cancellationToken);
        return new Result<DeleteOrderCommandResponse>(ResultStatus.Success, response);
    }
}