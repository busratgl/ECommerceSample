using ECommerceSample.Application.Helpers;
using ECommerceSample.Application.Requests.Users;
using FluentValidation;

namespace ECommerceSample.Application.Validators.Users.CreateUser;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(u => u.FirstName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lütfen bir isim giriniz.")
            .MinimumLength(3)
            .WithMessage("Lütfen en az 3 karakterden oluşan bir isim giriniz.");

        RuleFor(u => u.LastName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lütfen bir soyisim giriniz.")
            .MinimumLength(2)
            .WithMessage("Lütfen en az 2 karakterden oluşan bir soyisim giriniz.");

        RuleFor(u => u.BirthDate)
            .NotEmpty()
            .NotNull()
            .LessThanOrEqualTo(System.DateTime.Now.AddYears(-18))
            .WithMessage("Lütfen doğum günü tarihinizi giriniz.");

        RuleFor(u => u.PhoneNumber)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lütfen telefon numaranızı giriniz.")
            .Must(ValidationHelper.CheckPhoneNumberValidation);

        RuleFor(u => u.EmailAddress)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lütfen bir E-mail adres giriniz.")
            .Must(ValidationHelper.CheckEmailValidation);

        RuleFor(u => u.Address)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lütfen adres bilginizi giriniz.")
            .Length(20, 250)
            .WithMessage("Adres bilginiz 20 ile 250 karakter olmalıdır.");

        RuleFor(u => u.PasswordText)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lütfen bir şifre giriniz.")
            .Must(ValidationHelper.CheckPasswordValidation);
    }
}