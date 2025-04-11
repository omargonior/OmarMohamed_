using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bug_Ticketing_System.DAL;

public class Attachment
{
	[Key]
	public Guid Id { get; set; }
	public string Url { get; set; }
	[ForeignKey("Bug")]
	public Guid BugId { get; set; }

	public virtual Bug Bug { get; set; }
}
