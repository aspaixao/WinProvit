using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinProvit.DTO;

namespace WinProvit.Api.Middleware
{
    public static class DataBaseConfiguration
    {

        public static void AddDataBaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration["ConnectionStrings:SqlServer"];
            services.AddDbContext<WPContext>(options => options.UseSqlServer(connection));
        }

        public static void UseDataBaseConfig(this IApplicationBuilder app)
        {
            //using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            //using var context = serviceScope.ServiceProvider.GetService<WPContext>();
            //context.Database.Migrate();
            //context.Database.EnsureCreated();
        }
    }
}
