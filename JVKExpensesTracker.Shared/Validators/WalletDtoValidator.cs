using FluentValidation;
using JVKExpensesTracker.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVKExpensesTracker.Shared.Validators;

public class WalletDtoValidator : AbstractValidator<WalletDto>
{
    public WalletDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(100)
            .WithMessage("Name must be less than 100 characters");

        RuleFor(p => p.Currency)
            .NotEmpty()
            .WithMessage("Currency is required")
            .Length(3)
            .WithMessage("Curreny most be 3 characters");

        RuleFor(p => p.Swift)
            .Length(8, 11)
            .When(p => !string.IsNullOrEmpty(p.Swift))
            .WithMessage("Sqift ,ust ne netween 8 and 11 characters");

        RuleFor(p => p.Iban)
            .MaximumLength(34)
            .When(p => !string.IsNullOrEmpty(p.Iban))
            .WithMessage("IBAN must be less than 34 chaarcters");

    }
}
