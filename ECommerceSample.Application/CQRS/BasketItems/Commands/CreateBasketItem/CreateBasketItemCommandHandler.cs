using ECommerceSample.Application.Repositories.BasketItem;
using ECommerceSample.Domain.Entities;
using MediatR;

namespace ECommerceSample.Application.CQRS.BasketItems.Commands.CreateBasketItem;

public class
    CreateBasketItemCommandHandler : IRequestHandler<CreateBasketItemCommandRequest, CreateBasketItemCommandResponse>
{
    private readonly IBasketItemWriteRepository _basketItemWriteRepository;

    public CreateBasketItemCommandHandler(IBasketItemWriteRepository basketItemWriteRepository)
    {
        _basketItemWriteRepository = basketItemWriteRepository;
    }

    public async Task<CreateBasketItemCommandResponse> Handle(CreateBasketItemCommandRequest request,
        CancellationToken cancellationToken)
    {
        var basketItem = new BasketItem()
        {
            ProductId = request.ProductId,
            BasketId = request.BasketId
        };

        var isSuccess = await _basketItemWriteRepository.CreateAsync(basketItem);
        await _basketItemWriteRepository.SaveAsync();

        return new CreateBasketItemCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}