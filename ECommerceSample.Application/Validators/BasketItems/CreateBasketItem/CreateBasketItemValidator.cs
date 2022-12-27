using ECommerceSample.Application.Requests.BasketItems;
using FluentValidation;

namespace ECommerceSample.Application.Validators.BasketItems.CreateBasketItem;

public class CreateBasketItemValidator : AbstractValidator<CreateBasketItemRequest>
{
    public CreateBasketItemValidator()
    {
        RuleFor(bi => bi.ProductId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lütfen bir Ürün Id giriniz.")
            .InclusiveBetween(1, 9)
            .WithMessage("Lütfen Ürün Id alanını 1 ile 9 rakamı arasında giriniz.");

        RuleFor(bi => bi.BasketId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lütfen bir Sepet Id giriniz.")
            .InclusiveBetween(1, 9)
            .WithMessage("Lütfen Sepet Id alanını 1 ile 9 rakamı arasında giriniz.");
    }
}