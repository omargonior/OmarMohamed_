using Bug_Ticketing_System.BL.DTOs;

namespace Bug_Ticketing_System.BL.Managers.Attachment
{
	public interface IAttachmentManager
	{
		Task<bool> AddAttachmentToBugAsync(Guid bugId,AttachmentDto attachmentDto);
		Task<List<AttachmentDto>> GetBugAttachmentsAsync(Guid bugId);
		Task<bool> RemoveAttachmentFromBugAsync(Guid bugId,Guid attachmentId);
	}
}
