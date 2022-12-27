using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceSample.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(typeof(ServiceRegistration));
    }
}