using GapInsurance.Entities;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Registrar
    {
        public static void RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            //Do your setup here
            //services.AddTransient();

            services.AddDbContext<Insurance>();
        }
    }
}
