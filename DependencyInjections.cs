using APMApi.Config.Swagger;
using APMApi.Services.MainChats.ChatServices;
using APMApi.Services.MainFeedBacks.FeedBackApplicationServices;
using APMApi.Services.MainFeedBacks.FeedBackServices;
using APMApi.Services.MainFeedBacks.IssueServices;
using APMApi.Services.MainRequests.RequestServices;
using APMApi.Services.MainRequests.ResponseServices;
using APMApi.Services.MainRequests.ResponseStatusServices;
using APMApi.Services.MainRequests.StatusServices;
using APMApi.Services.MainSkills.ObjectCategoryServices;
using APMApi.Services.MainSkills.ObjectServices;
using APMApi.Services.MainSkills.SkillServices;
using APMApi.Services.MainUsers.AddressServices;
using APMApi.Services.MainUsers.PreferenceServices;
using APMApi.Services.MainUsers.RoleServices;
using APMApi.Services.MainUsers.UserServices;
using APMApi.Services.Other.FileServices;
using Microsoft.Extensions.Options;
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
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IPreferenceService, PreferenceService>();
        services.AddScoped<IAddressService, AddressService>();

        // chat services
        services.AddScoped<IChatService, ChatService>();

        // feedback services
        services.AddScoped<IFeedBackService, FeedBackService>();
        services.AddScoped<IFeedBackApplicationService, FeedBackApplicationService>();
        services.AddScoped<IIssueService, IssueService>();

        // skill services
        services.AddScoped<ISkillService, SkillService>();
        services.AddScoped<IObjectService, ObjectService>();
        services.AddScoped<IObjectCategoryService, ObjectCategoryService>();

        // request services
        services.AddScoped<IRequestService, RequestService>();
        services.AddScoped<IResponseService, ResponseService>();
        services.AddScoped<IStatusService, StatusService>();
        services.AddScoped<IResponseStatusService, ResponseStatusService>();
    }
}