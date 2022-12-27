using ECommerceSample.Application.CQRS.Categories.Commands.CreateCategory;
using ECommerceSample.Application.CQRS.Categories.Commands.DeleteCategory;
using ECommerceSample.Application.CQRS.Categories.Commands.UpdateCategory;
using ECommerceSample.Application.CQRS.Categories.Queries.GetAllCategories;
using ECommerceSample.Application.CQRS.Categories.Queries.GetCategoryById;
using ECommerceSample.Application.Requests.Categories;
using ECommerceSample.Application.Responses.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSample.WebAPI.Controllers;

public class CategoriesController : BaseController
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<Result<List<GetAllCategoriesQueryResponse>>> GetAllCategories(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllCategoriesQueryRequest(), cancellationToken);
        return new Result<List<GetAllCategoriesQueryResponse>>(ResultStatus.Success, response);
    }

    [HttpGet("{id}")]
    public async Task<Result<GetCategoryByIdQueryResponse>> GetCategoryById([FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var request = new GetCategoryByIdQueryRequest()
        {
            Id = id
        };

        var response = await _mediator.Send(request, cancellationToken);
        return new Result<GetCategoryByIdQueryResponse>(ResultStatus.Success, response);
    }

    [HttpPost]
    public async Task<Result<CreateCategoryCommandResponse>> CreateCategory([FromBody] CreateCategoryRequest request,
        CancellationToken cancellationToken)
    {
        var handlerRequest = new CreateCategoryCommandRequest()
        {
            Name = request.Name,
            Description = request.Description
        };

        var response = await _mediator.Send(handlerRequest, cancellationToken);
        return new Result<CreateCategoryCommandResponse>(ResultStatus.Success, response);
    }

    [HttpPut("{id}")]
    public async Task<Result<UpdateCategoryCommandResponse>> UpdateCategory([FromRoute] long id,
        [FromBody] UpdateCategoryRequest request,
        CancellationToken
            cancellationToken)
    {
        var handlerRequest = new UpdateCategoryCommandRequest()
        {
            Id = id,
            Name = request.Name,
            Description = request.Description
        };

        var response = await _mediator.Send(handlerRequest, cancellationToken);
        return new Result<UpdateCategoryCommandResponse>(ResultStatus.Success, response);
    }

    [HttpDelete("{id}")]
    public async Task<Result<DeleteCategoryCommandResponse>> DeleteCategory([FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var request = new DeleteCategoryCommandRequest()
        {
            Id = id
        };

        var response = await _mediator.Send(request, cancellationToken);
        return new Result<DeleteCategoryCommandResponse>(ResultStatus.Success, response);
    }
}