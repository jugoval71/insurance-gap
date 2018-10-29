using Microsoft.Extensions.DependencyInjection;
using System;

namespace GapInsurance.Services.DependencyInjection
{
    public static class BusinessLogicServiceCollectionExtensions
    {
        public static IServiceCollection AddScopedService<TFrom, TTo>(this IServiceCollection services) where TTo : TFrom
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            Type typeFrom = typeof(TFrom);
            Type typeTo = typeof(TTo);
            services.AddScoped(typeFrom, typeTo);
            return services;
        }
    }
}
