using System;

namespace WinProvit.Core
{
    public static class MiddlewareConfigurationns
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
