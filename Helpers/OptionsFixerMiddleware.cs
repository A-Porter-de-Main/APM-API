namespace APMApi.Helpers;

public class OptionsFixerMiddleware
{
    private readonly RequestDelegate _next;

    public OptionsFixerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Method == "OPTIONS")
            context.Response.StatusCode = 200;
        else
            await _next(context);
    }
}