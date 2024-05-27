using DVar.PList.Domain.Entities;
using FluentValidation;

namespace DVar.PList.Domain.Validation;

public class PricelistValidator : AbstractValidator<Pricelist>
{
    public PricelistValidator()
    {
        RuleFor(p => p.PricelistName)
            .NotNull()
            .WithMessage("Прайслист не может быть пустым")
            .NotEmpty()
            .WithMessage("Прайслист не может быть пустым");

        RuleFor(p => p.CustomColumns)
            .NotNull();

        RuleFor(p => p.Products)
            .NotNull();
    }
}