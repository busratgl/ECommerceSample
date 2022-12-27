using Microsoft.Extensions.Configuration;

namespace ECommerceSample.Persistence;

static class Configuration
{
    public static string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),
                "../ECommerceSample.WebAPI"));
            configurationManager
                .AddJsonFile("appsettings.json");

            return configurationManager.GetConnectionString("MsSQL");
        }
    }
}