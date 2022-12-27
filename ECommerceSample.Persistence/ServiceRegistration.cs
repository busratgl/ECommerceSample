using ECommerceSample.Application.Repositories.Basket;
using ECommerceSample.Application.Repositories.BasketItem;
using ECommerceSample.Application.Repositories.Category;
using ECommerceSample.Application.Repositories.Order;
using ECommerceSample.Application.Repositories.OrderItem;
using ECommerceSample.Application.Repositories.Product;
using ECommerceSample.Application.Repositories.User;
using ECommerceSample.Persistence.Contexts;
using ECommerceSample.Persistence.Repositories.Basket;
using ECommerceSample.Persistence.Repositories.BasketItem;
using ECommerceSample.Persistence.Repositories.Category;
using ECommerceSample.Persistence.Repositories.Order;
using ECommerceSample.Persistence.Repositories.OrderItem;
using ECommerceSample.Persistence.Repositories.Product;
using ECommerceSample.Persistence.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceSample.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<ECommerceSampleDbContext>(options =>
            options.UseSqlServer(Configuration.ConnectionString));
        services.AddScoped<IBasketReadRepository, BasketReadRepository>();
        services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();
        services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
        services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();
        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
        services.AddScoped<IUserReadRepository, UserReadRepository>();
        services.AddScoped<IUserWriteRepository, UserWriteRepository>();
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        services.AddScoped<IOrderItemReadRepository, OrderItemReadRepository>();
        services.AddScoped<IOrderItemWriteRepository, OrderItemWriteRepository>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

        //DbContextimiz hangi lifecycle a aitse Repositorylerimizi aynı lifecycle ile register etmek daha sağlıklı olabilir.
    }
}