using ECommerceSample.Application.Repositories.Basket;
using MediatR;

namespace ECommerceSample.Application.CQRS.Baskets.Commands.UpdateBasket;

public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommandRequest, UpdateBasketCommandResponse>
{
    private readonly IBasketWriteRepository _basketWriteRepository;

    public UpdateBasketCommandHandler(IBasketWriteRepository basketWriteRepository)
    {
        _basketWriteRepository = basketWriteRepository;
    }

    public async Task<UpdateBasketCommandResponse> Handle(UpdateBasketCommandRequest request,
        CancellationToken cancellationToken)
    {
        var basket = await _basketWriteRepository.FindAsync(request.Id);

        var isSuccess = _basketWriteRepository.Update(basket);
        await _basketWriteRepository.SaveAsync();

        return new UpdateBasketCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}