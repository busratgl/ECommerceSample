using ECommerceSample.Application.Repositories.BasketItem;
using MediatR;

namespace ECommerceSample.Application.CQRS.BasketItems.Commands.DeleteBasketItem;

public class
    DeleteBasketItemCommandHandler : IRequestHandler<DeleteBasketItemCommandRequest, DeleteBasketItemCommandResponse>
{
    private readonly IBasketItemWriteRepository _basketItemWriteRepository;

    public DeleteBasketItemCommandHandler(IBasketItemWriteRepository basketItemWriteRepository)
    {
        _basketItemWriteRepository = basketItemWriteRepository;
    }

    public async Task<DeleteBasketItemCommandResponse> Handle(DeleteBasketItemCommandRequest request,
        CancellationToken cancellationToken)
    {
        var basketItem = await _basketItemWriteRepository.FindAsync(request.Id);
        basketItem.IsDeleted = true;

        var isSuccess = _basketItemWriteRepository.Update(basketItem);
        await _basketItemWriteRepository.SaveAsync();

        return new DeleteBasketItemCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}