using ECommerceSample.Application;
using ECommerceSample.Infrastructure;
using ECommerceSample.Persistence;
using ECommerceSample.WebAPI.Middlewares;
using FluentValidation.AspNetCore;
using MediatR;
using ServiceRegistration = ECommerceSample.Application.ServiceRegistration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();



builder.Services.AddControllers().AddFluentValidation(validationConfiguration =>
{
    validationConfiguration.RegisterValidatorsFromAssemblyContaining(typeof(ServiceRegistration));
});


builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();