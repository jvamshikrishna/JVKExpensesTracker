using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JVKExpensesTracker.Shared.Validators;

namespace JVKExpensesTracker.Shared;

public static class DependencyInjectionExtensions
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<WalletDtoValidator>();
    }
}
