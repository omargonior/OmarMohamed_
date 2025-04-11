namespace Bug_Ticketing_System.DAL.Repositories.AttachmentRepo
{
	public class AttachmentRepo : GenericRepository<Attachment>, IAttachmentRepo
	{
		public AttachmentRepo(BugDbContext context) : base(context)
		{
		}
	}
}
