﻿using JVKExpensesTracker.Server.Data.Repositories;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVKExpensesTracker.Server.Data
{
    public static class DependencyInjectionExtensions
    {
        public static void AddCosmosDbClient(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton(sp => new CosmosClient(connectionString));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWalletsRepository, CosmosWalletsRepository>();
        }
    }

    
}
