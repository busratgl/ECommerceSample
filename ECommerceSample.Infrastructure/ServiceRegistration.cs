using Microsoft.Extensions.DependencyInjection;

namespace ECommerceSample.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddCap(options =>
        {
            options.UseInMemoryStorage();
            options.UseRabbitMQ(options =>
            {
                options.ConnectionFactoryOptions = options =>
                {
                    options.Ssl.Enabled = false;
                    options.HostName = "localhost";
                    options.UserName = "guest";
                    options.Password = "guest";
                    options.Port = 5672;
                };
            });
        });
    }
}