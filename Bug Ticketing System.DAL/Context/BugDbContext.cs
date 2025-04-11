using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bug_Ticketing_System.DAL
{
	public class BugDbContext:IdentityDbContext<User>
	{
		public DbSet<User> Users => Set<User>();
		public DbSet<Project> Projects => Set<Project>();
		public DbSet<Bug> Bugs => Set<Bug>();
		public DbSet<Bug_User> Bug_Users => Set<Bug_User>();
		public DbSet<Attachment> Attachments => Set<Attachment>();
		public BugDbContext(DbContextOptions<BugDbContext> options)
			: base(options)
		{
			
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<Bug_User>().HasKey(bu => new { bu.UserId, bu.BugId });
			builder.Entity<User>(e =>
			{
				e.ToTable("Users");
			});
		}
	}
}
