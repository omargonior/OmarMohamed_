using Bug_Ticketing_System.DAL;

namespace Bug_Ticketing_System.BL.DTOs
{
	public class ProjectDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public ICollection<Bug>? Bugs { get; set; } = new List<Bug>();
	}
}
