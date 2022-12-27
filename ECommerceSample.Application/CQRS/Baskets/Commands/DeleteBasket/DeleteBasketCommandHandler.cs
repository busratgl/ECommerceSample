using ECommerceSample.Application.Repositories.Basket;
using MediatR;

namespace ECommerceSample.Application.CQRS.Baskets.Commands.DeleteBasket;

public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommandRequest, DeleteBasketCommandResponse>
{
    private readonly IBasketWriteRepository _basketWriteRepository;

    public DeleteBasketCommandHandler(IBasketWriteRepository basketWriteRepository)
    {
        _basketWriteRepository = basketWriteRepository;
    }

    public async Task<DeleteBasketCommandResponse> Handle(DeleteBasketCommandRequest request,
        CancellationToken cancellationToken)
    {
        var basket = await _basketWriteRepository.FindAsync(request.Id);
        basket.IsDeleted = true;

        var isSuccess = _basketWriteRepository.Update(basket);
        await _basketWriteRepository.SaveAsync();

        return new DeleteBasketCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}