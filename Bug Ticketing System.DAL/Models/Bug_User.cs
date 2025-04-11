using System.ComponentModel.DataAnnotations.Schema;

namespace Bug_Ticketing_System.DAL;

public class Bug_User
{
	[ForeignKey("User")]
	public string UserId { get; set; }
	[ForeignKey("Bug")]
	public Guid BugId { get; set; }

	public virtual User User { get; set; }
	public virtual Bug Bug { get; set; }

}
