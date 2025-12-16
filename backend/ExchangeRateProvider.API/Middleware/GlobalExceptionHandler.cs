using Microsoft.AspNetCore.Mvc;

namespace ExchangeRateProvider.API.Middleware
{
    internal sealed class GlobalExceptionHandler(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = e switch
                {
                    ApplicationException => StatusCodes.Status400BadRequest,
                    _ => StatusCodes.Status500InternalServerError
                };

                await context.Response.WriteAsJsonAsync(
                    new ProblemDetails
                    {
                        Type = e.GetType().Name,
                        Title = "An error occured",
                        Detail = e.Message
                    });
            }
        }
    }
}
