namespace Bug_Ticketing_System.DAL.Repositories.ProjectRepo
{
	public class ProjectRepo : GenericRepository<Project>, IProjectRepo
	{
		public ProjectRepo(BugDbContext context) : base(context)
		{
		}
	}
}
