using ECommerceSample.Application.CQRS.Products.Commands.CreateProduct;
using ECommerceSample.Application.CQRS.Products.Commands.DeleteProduct;
using ECommerceSample.Application.CQRS.Products.Commands.UpdateProduct;
using ECommerceSample.Application.CQRS.Products.Queries.GetAllProducts;
using ECommerceSample.Application.CQRS.Products.Queries.GetProductById;
using ECommerceSample.Application.Requests.Products;
using ECommerceSample.Application.Responses.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSample.WebAPI.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<Result<List<GetAllProductsQueryResponse>>> GetAllProducts(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllProductsQueryRequest(), cancellationToken);
            return new Result<List<GetAllProductsQueryResponse>>(ResultStatus.Success, response);
        }

        [HttpGet("{id}")]
        public async Task<Result<GetProductByIdQueryResponse>> GetProductById([FromRoute] long id,
            CancellationToken cancellationToken)
        {
            var request = new GetProductByIdQueryRequest()
            {
                Id = id
            };

            var response = await _mediator.Send(request, cancellationToken);
            return new Result<GetProductByIdQueryResponse>(ResultStatus.Success, response);
        }

        [HttpPost]
        public async Task<Result<CreateProductCommandResponse>> CreateProduct([FromBody] CreateProductRequest request,
            CancellationToken cancellationToken)
        {
            var handlerRequest = new CreateProductCommandRequest()
            {
                Name = request.Name,
                UnitsInStock = request.UnitsInStock,
                Price = request.Price,
                CategoryId = request.CategoryId
            };

            var response = await _mediator.Send(handlerRequest, cancellationToken);
            return new Result<CreateProductCommandResponse>(ResultStatus.Success, response);
        }

        [HttpPut("{id}")]
        public async Task<Result<UpdateProductCommandResponse>> UpdateProduct([FromRoute] long id,
            [FromBody] UpdateProductRequest request,
            CancellationToken
                cancellationToken)
        {
            var handlerRequest = new UpdateProductCommandRequest()
            {
                Id = id,
                Name = request.Name,
                UnitsInStock = request.UnitsInStock,
                Price = request.Price,
                CategoryId = request.CategoryId
            };

            var response = await _mediator.Send(handlerRequest, cancellationToken);
            return new Result<UpdateProductCommandResponse>(ResultStatus.Success, response);
        }

        [HttpDelete("{id}")]
        public async Task<Result<DeleteProductCommandResponse>> DeleteProduct([FromRoute] long id,
            CancellationToken cancellationToken)
        {
            var request = new DeleteProductCommandRequest()
            {
                Id = id
            };

            var response = await _mediator.Send(request, cancellationToken);
            return new Result<DeleteProductCommandResponse>(ResultStatus.Success, response);
        }
    }
}