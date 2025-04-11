namespace Bug_Ticketing_System.BL.DTOs
{
	public class AttachmentDto
	{
		public Guid Id { get; set; }
		public string Url { get; set; }
		public Guid BugId { get; set; }
	}
}
