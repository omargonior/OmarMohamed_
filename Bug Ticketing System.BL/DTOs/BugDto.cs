using Bug_Ticketing_System.DAL;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bug_Ticketing_System.BL.DTOs
{
	public class BugDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid ProjectId { get; set; }
		
	}
}
