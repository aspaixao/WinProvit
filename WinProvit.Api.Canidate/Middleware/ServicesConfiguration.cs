using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WinProvit.CandidateServices;
using WinProvit.Core.Interfaces;
using WinProvit.DTO.Repositories.Interfaces;

namespace WinProvit.Api.Middleware
{
    public static class ServicesConfiguration
    {
        
        public static void AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddTransient<ICandidateServices, CandidateServices.CandidateServices>();

        }

        public static void UseServicesConfiguration(this IApplicationBuilder app)
        {

        }
    }
}
