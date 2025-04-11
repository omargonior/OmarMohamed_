using Bug_Ticketing_System.DAL.Repositories.AttachmentRepo;
using Bug_Ticketing_System.DAL.Repositories.Bug_UserRepo;
using Bug_Ticketing_System.DAL.Repositories.BugRepo;
using Bug_Ticketing_System.DAL.Repositories.ProjectRepo;

namespace Bug_Ticketing_System.DAL;

public interface IUnitOfWork : IDisposable
{
    IAttachmentRepo Attachment { get; }
    IBugRepo Bug { get; }  
    IBug_UserRepo Bug_User { get; }
    IProjectRepo Project { get; }

    Task<int> CompleteAsync();
 
}
