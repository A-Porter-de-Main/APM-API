using Microsoft.Extensions.Options;
using APMApi.Config.Swagger;
using APMApi.Services.MainUsers.UserServices;
using APMApi.Services.Other.FileServices;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace APMApi;

public static class DependencyInjections
{
    public static void AddInjections(this IServiceCollection services)
    {
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        services.AddScoped<IFileService, FileService>();
        
        // user services
        services.AddScoped<IUserService, UserService>();
        
    }
}