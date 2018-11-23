﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.DataAccess.EF
{
    public static class EFInstaller
    {
        public static IServiceCollection AddEFConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var useInMemoryDatabase = configuration.GetSection("Settings").GetValue<bool>("UseInMemoryDatabase");

            services.AddDbContext<ProductDbContext>(options =>
            {
                if (useInMemoryDatabase)
                {
                    options.UseInMemoryDatabase("Products");
                }
                else
                {
                    options.UseSqlServer(configuration.GetConnectionString("Products"));
                }
            });
            return services;
        }       
    }
}