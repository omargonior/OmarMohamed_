using System.ComponentModel.DataAnnotations;

namespace Bug_Ticketing_System.DAL;

public class Project
{
	[Key]
	public Guid Id { get; set; }
	public string Name { get; set; }
	public virtual ICollection<Bug>? Bugs { get; set; } = new HashSet<Bug>();
}
