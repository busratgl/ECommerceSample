using System.Net;
using ECommerceSample.Application.Responses.Base;
using Newtonsoft.Json;

namespace ECommerceSample.WebAPI.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }

        catch (Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = new Result<object>(ResultStatus.Error, ex.Message);
            var resultAsJsonString = JsonConvert.SerializeObject(result);
            await httpContext.Response.WriteAsync(resultAsJsonString);
        }
    }
}