using ECommerceSample.Application.Requests.Baskets;
using FluentValidation;

namespace ECommerceSample.Application.Validators.Baskets.CreateBasket;

public class CreateBasketValidator : AbstractValidator<CreateBasketRequest>
{
    public CreateBasketValidator()
    {
        RuleFor(b => b.UserId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lütfen bir Kullanıcı Id giriniz.")
            .InclusiveBetween(1, 9)
            .WithMessage("Lütfen Kullanıcı Id alanını 1 ile 9 rakamı arasında giriniz.");
    }
}