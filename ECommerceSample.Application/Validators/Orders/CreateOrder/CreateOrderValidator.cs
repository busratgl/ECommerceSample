using ECommerceSample.Application.Requests.Orders;
using FluentValidation;

namespace ECommerceSample.Application.Validators.Orders.CreateOrder;

public class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderValidator()
    {
        RuleFor(o => o.Description)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lütfen bir açıklama giriniz.")
            .MinimumLength(10)
            .MaximumLength(150)
            .WithMessage("Lütfen sipariş açıklamasını 10 ile 150 karakter arasında giriniz.");

        RuleFor(o => o.Address)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lütfen sipariş adres bilgisini giriniz.")
            .MaximumLength(250)
            .WithMessage("Sipariş adres bilgisi en fazla 150 karakter olmalıdır.");
    }
}