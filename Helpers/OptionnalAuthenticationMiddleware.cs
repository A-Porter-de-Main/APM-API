using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace APMApi.Helpers;

public class OptionalAuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public OptionalAuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var result = await context.AuthenticateAsync("Bearer");
        if (result is { Succeeded: true, Principal: not null })
        {
            context.User = result.Principal;
        }
        await _next(context);
    }
}

public static class OptionalAuthenticationMiddlewareExtensions
{
    public static IApplicationBuilder UseOptionalAuthentication(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<OptionalAuthenticationMiddleware>();
    }
}