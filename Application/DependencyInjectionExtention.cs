using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EmployeeCensus.Application
{
    public static class DependencyInjectionExtention
    {
        public static IServiceCollection AddMediatRWithAssembly(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return serviceCollection;
        }
    }
}
