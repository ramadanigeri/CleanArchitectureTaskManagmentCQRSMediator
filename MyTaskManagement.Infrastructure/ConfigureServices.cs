using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyTaskManagement.Domain.Repository;
using MyTaskManagement.Infrastructure.Data;
using MyTaskManagement.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManagement.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyTaskDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MyTaskDbContext") ??
                    throw new InvalidOperationException("Connection to Database Failed, Check Connection String"))
            );
            services.AddTransient<IMyTaskRepository, MyTaskRepository>();
            return services;
        }
    }
}
