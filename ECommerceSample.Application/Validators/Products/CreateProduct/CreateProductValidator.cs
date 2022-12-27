using ECommerceSample.Application.Requests.Products;
using FluentValidation;

namespace ECommerceSample.Application.Validators.Products.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lütfen bir ürün adı giriniz.")
            .MinimumLength(3)
            .MaximumLength(75)
            .WithMessage("Lütfen ürün adını 3 ile 75 karakter arasında giriniz.");

        RuleFor(p => p.UnitsInStock)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lütfen ürünün stok bilgisini giriniz.")
            .Must(stock => stock >= 0)
            .WithMessage("Lütfen ürünün stok bilgisini 0 dan büyük giriniz.");
        
        RuleFor(p => p.Price)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lütfen ürünün fiyat bilgisini giriniz.")
            .Must(price => price >= 0)
            .WithMessage("Lütfen ürünün fiyat bilgisini 0 dan büyük giriniz.");
        
        RuleFor(p => p.CategoryId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Lütfen bir Kategori Id giriniz.")
            .InclusiveBetween(1, 6)
            .WithMessage("Lütfen Kategori Id alanını 1 ile 6 rakamı arasında giriniz.");
    }
}