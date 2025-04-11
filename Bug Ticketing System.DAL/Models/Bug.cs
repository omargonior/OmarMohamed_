using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bug_Ticketing_System.DAL;

public class Bug
{
	[Key]
	public Guid Id { get; set; }
	public string Name { get; set; }
	[ForeignKey("Project")]
	public Guid ProjectId { get; set; }
	public virtual ICollection<Attachment> Attachments { get; set; } = new HashSet<Attachment>();
	public virtual ICollection<Bug_User> assignees { get; set; } = new HashSet<Bug_User>();

	public virtual Project Project { get; set; }

}
