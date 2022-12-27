using ECommerceSample.Application.CQRS.BasketItems.Commands.CreateBasketItem;
using ECommerceSample.Application.CQRS.BasketItems.Commands.DeleteBasketItem;
using ECommerceSample.Application.CQRS.BasketItems.Commands.UpdateBasketItem;
using ECommerceSample.Application.CQRS.BasketItems.Queries.GetAllBasketItems;
using ECommerceSample.Application.CQRS.BasketItems.Queries.GetBasketItemById;
using ECommerceSample.Application.CQRS.Products.Commands.DeleteProduct;
using ECommerceSample.Application.Requests.BasketItems;
using ECommerceSample.Application.Responses.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSample.WebAPI.Controllers;

public class BasketItemsController : BaseController
{
    private readonly IMediator _mediator;

    public BasketItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<Result<List<GetAllBasketItemsQueryResponse>>> GetAllBasketItems(
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllBasketItemsQueryRequest(), cancellationToken);
        return new Result<List<GetAllBasketItemsQueryResponse>>(ResultStatus.Success, response);
    }

    [HttpGet("{id}")]
    public async Task<Result<GetBasketItemByIdQueryResponse>> GetBasketItemById([FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var request = new GetBasketItemByIdQueryRequest()
        {
            Id = id
        };

        var response = await _mediator.Send(request, cancellationToken);
        return new Result<GetBasketItemByIdQueryResponse>(ResultStatus.Success, response);
    }

    [HttpPost]
    public async Task<Result<CreateBasketItemCommandResponse>> CreateBasketItem(
        [FromBody] CreateBasketItemRequest request,
        CancellationToken cancellationToken)
    {
        var handlerRequest = new CreateBasketItemCommandRequest()
        {
            ProductId = request.ProductId,
            BasketId = request.BasketId
        };

        var response = await _mediator.Send(handlerRequest, cancellationToken);
        return new Result<CreateBasketItemCommandResponse>(ResultStatus.Success, response);
    }

    [HttpPut("{id}")]
    public async Task<Result<UpdateBasketItemCommandResponse>> UpdateBasketItem([FromRoute] long id,
        [FromBody] UpdateBasketItemRequest request,
        CancellationToken
            cancellationToken)
    {
        var handlerRequest = new UpdateBasketItemCommandRequest()
        {
            Id = id
        };

        var response = await _mediator.Send(handlerRequest, cancellationToken);
        return new Result<UpdateBasketItemCommandResponse>(ResultStatus.Success, response);
    }

    [HttpDelete("{id}")]
    public async Task<Result<DeleteBasketItemCommandResponse>> DeleteBasketItem([FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var request = new DeleteBasketItemCommandRequest()
        {
            Id = id
        };

        var response = await _mediator.Send(request, cancellationToken);
        return new Result<DeleteBasketItemCommandResponse>(ResultStatus.Success, response);
    }
}