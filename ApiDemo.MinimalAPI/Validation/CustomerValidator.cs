using ApiDemo.MinimalAPI.Models;
using FluentValidation;

namespace ApiDemo.MinimalAPI.Validation;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(c => c.Fullname).NotEmpty().MinimumLength(2);
    }
}
