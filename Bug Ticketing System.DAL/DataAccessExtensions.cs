using Bug_Ticketing_System.DAL.Repositories.AttachmentRepo;
using Bug_Ticketing_System.DAL.Repositories.Bug_UserRepo;
using Bug_Ticketing_System.DAL.Repositories.BugRepo;
using Bug_Ticketing_System.DAL.Repositories.ProjectRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Bug_Ticketing_System.DAL;

public static class DataAccessExtensions
{
    public static void AddDataAccessServices(this IServiceCollection services,IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");
        Console.WriteLine("CONN STRING: " + connectionString);
        services.AddDbContext<BugDbContext>(options => options.UseSqlServer(connectionString));


        
        
        services.AddScoped<IAttachmentRepo, AttachmentRepo>();
        services.AddScoped<IBugRepo, BugRepo>();
        services.AddScoped<IBug_UserRepo, Bug_UserRepo>();
        services.AddScoped<IProjectRepo, ProjectRepo>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
