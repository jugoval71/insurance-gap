using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Registrar
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Do your setup here
            //services.AddTransient();
        }
    }
}
