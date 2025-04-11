namespace Bug_Ticketing_System.DAL.Repositories.BugRepo
{
	public class BugRepo : GenericRepository<Bug>, IBugRepo
	{
		public BugRepo(BugDbContext context) : base(context)
		{
		}
	}
}
