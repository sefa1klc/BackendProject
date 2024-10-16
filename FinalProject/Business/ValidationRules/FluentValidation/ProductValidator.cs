using Business.Concrete;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.ProductName).NotEmpty().WithMessage("Product name cannot be empty");
        RuleFor(p => p.ProductName).MinimumLength(2).WithMessage("Product name must be at least 2 characters long");
        RuleFor(p => p.UnitPrice).NotEmpty().WithMessage("Unit price cannot be empty");
        RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage("Unit price must be greater than 0");
        RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryID == 1)
            .WithMessage("Unit price must be greater than 10");
        //RuleFor(p => p.ProductName).Must(StartWithA);//normally this rule is not exist
    }

    private bool StartWithA(string arg)
    {
        return arg.StartsWith("A");
    }
}