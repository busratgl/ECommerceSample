using ECommerceSample.Application.Repositories.BasketItem;
using MediatR;

namespace ECommerceSample.Application.CQRS.BasketItems.Commands.UpdateBasketItem;

public class
    UpdateBasketItemCommandHandler : IRequestHandler<UpdateBasketItemCommandRequest, UpdateBasketItemCommandResponse>
{
    private readonly IBasketItemWriteRepository _basketItemWriteRepository;

    public UpdateBasketItemCommandHandler(IBasketItemWriteRepository basketItemWriteRepository)
    {
        _basketItemWriteRepository = basketItemWriteRepository;
    }

    public async Task<UpdateBasketItemCommandResponse> Handle(UpdateBasketItemCommandRequest request,
        CancellationToken cancellationToken)
    {
        var basketItem = await _basketItemWriteRepository.FindAsync(request.Id);

        var isSuccess = _basketItemWriteRepository.Update(basketItem);
        await _basketItemWriteRepository.SaveAsync();

        return new UpdateBasketItemCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}