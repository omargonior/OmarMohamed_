namespace Bug_Ticketing_System.DAL.Repositories.Bug_UserRepo
{
	public class Bug_UserRepo : GenericRepository<Bug_User>, IBug_UserRepo
	{
		public Bug_UserRepo(BugDbContext context) : base(context)
		{
		}
	}
}
