using ECommerceSample.Application.Requests.Categories;
using FluentValidation;

namespace ECommerceSample.Application.Validators.Categories.CreateCategory;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lütfen bir kategori adı giriniz.")
            .MinimumLength(3)
            .MaximumLength(75)
            .WithMessage("Lütfen kategori adını 3 ile 75 karakter arasında giriniz.");
        
        RuleFor(c => c.Description)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lütfen bir açıklama giriniz.")
            .MinimumLength(10)
            .MaximumLength(150)
            .WithMessage("Lütfen kategori açıklamasını 10 ile 150 karakter arasında giriniz.");
    }
}
