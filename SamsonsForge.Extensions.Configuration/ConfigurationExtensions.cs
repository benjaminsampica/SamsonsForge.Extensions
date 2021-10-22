using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace SamsonsForge.Extensions.Configuration
{
    /// <summary>
    ///     Common extensions for <see cref="IServiceCollection"/> when handling patterns for <see cref="IConfiguration"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     <para>
        ///         Registers a configuration instance which TOptions will bind against. 
        ///         Additionally, registers the <see cref="IOptions{TOptions}.Value"/> as a scoped service to the service collection.
        ///     </para>
        ///     
        ///     Allows dependency injection of the given options directly rather than through an <see cref="IOptions{TOptions}"/>.
        /// </summary>
        /// <example>
        /// </example>
        /// <returns>A <see cref="IServiceCollection"/> so calls that additional calls be chained.</returns>
        public static IServiceCollection ConfigureAsScoped<TOptions>(this IServiceCollection services, IConfiguration configuration, string key)
            where TOptions : class
        {
            return services.Configure<TOptions>(configuration.GetSection(key))
                .AddScoped(s => s.GetRequiredService<IOptions<TOptions>>().Value);
        }
    }
}
