

using Bug_Ticketing_System.DAL.Repositories.AttachmentRepo;
using Bug_Ticketing_System.DAL.Repositories.Bug_UserRepo;
using Bug_Ticketing_System.DAL.Repositories.BugRepo;
using Bug_Ticketing_System.DAL.Repositories.ProjectRepo;

namespace Bug_Ticketing_System.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly BugDbContext _context;

    public IAttachmentRepo Attachment { get; }
	public IBugRepo Bug { get; }
	public IBug_UserRepo Bug_User { get; }
	public IProjectRepo Project { get; }

	

	public UnitOfWork(BugDbContext context)
    {
        _context = context;

        
		Attachment=new AttachmentRepo(context);
        Bug=new BugRepo(context);
        Bug_User=new Bug_UserRepo(context);
        Project=new ProjectRepo(context);

	}

    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();

    
}
