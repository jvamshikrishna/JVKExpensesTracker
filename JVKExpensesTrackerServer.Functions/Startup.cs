using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JVKExpensesTracker.Server.Data;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using JVKExpensesTracker.Shared;

[assembly: FunctionsStartup(typeof(JVKExpensesTracker.Server.Functions.Startup))]
namespace JVKExpensesTracker.Server.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = builder.GetContext().Configuration;

            builder.Services.AddCosmosDbClient(config["CosmosDbConnectionstring"]);
            builder.Services.AddRepositories();
            builder.Services.AddValidators();
        }
    }
}
