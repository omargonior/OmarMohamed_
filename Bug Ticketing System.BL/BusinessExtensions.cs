using Bug_Ticketing_System.BL.Managers.Attachment;
using Bug_Ticketing_System.BL.Managers.Bug;
using Bug_Ticketing_System.BL.Managers.Bug_User;
using Bug_Ticketing_System.BL.Managers.Project;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Bug_Ticketing_System.BL;

public static class BusinessExtensions
{
    public static void AddBusinessServices(this IServiceCollection services,IConfiguration configuration)
    { 
         services.AddScoped<IProjectManager, ProjectManager>();
        services.AddScoped<IBugManager, BugManager>();
        services.AddScoped<IBugUserManager, BugUserManager>();
        services.AddScoped<IAttachmentManager, AttachmentManager>();
    }
}
