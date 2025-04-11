using Bug_Ticketing_System.BL.DTOs;
using Bug_Ticketing_System.DAL;

namespace Bug_Ticketing_System.BL.Managers.Attachment
{
	public class AttachmentManager : IAttachmentManager
	{
		private readonly IUnitOfWork _unitOfWork;

		public AttachmentManager(IUnitOfWork unitOfWork)
		{
			_unitOfWork=unitOfWork;
		}
		/////////////////////////////////////////////////////////////////////
		public async Task<bool>
			AddAttachmentToBugAsync(Guid bugId,AttachmentDto attachmentDto)
		{
			var bug= await _unitOfWork.Bug.GetByIdAsync(bugId);
			if (bug == null)
			{
				return false;
			}
			var attachment = new DAL.Attachment
			{
				Url = attachmentDto.Url,
				BugId = bugId,
			};
			await _unitOfWork.Attachment.AddAsync(attachment);
			await _unitOfWork.CompleteAsync();
			return true;
		}
		/////////////////////////////////////////////////////////////////////
		public async Task<List<AttachmentDto>> GetBugAttachmentsAsync(Guid bugId)
		{
			var attachments=await _unitOfWork.Attachment.GetAllAsync();
			var bugAttachments= attachments.Where(a=>a.BugId==bugId).ToList();
			var bugAttachmentsDto=bugAttachments.Select(ba=>new AttachmentDto
			{
				Id =ba.Id,
				Url=ba.Url,
				BugId=ba.BugId
			}).ToList();
			return bugAttachmentsDto;
		}
		/////////////////////////////////////////////////////////////////////
		public async Task<bool>
			RemoveAttachmentFromBugAsync(Guid bugId, Guid attachmentId)
		{
			var attachments = await _unitOfWork.Attachment.GetAllAsync();
			var attachmentToRemove=attachments
				.Where(a=>a.Id==attachmentId&&a.BugId==bugId)
				.FirstOrDefault();
			if(attachmentToRemove == null)
			{
				return false;
			}	
			 _unitOfWork.Attachment.Delete(attachmentToRemove);
			await _unitOfWork.CompleteAsync();
			return true;
		}
	}
}
