using Bug_Ticketing_System.BL.DTOs;
using Bug_Ticketing_System.BL.Managers.Attachment;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Bug_Ticketing_System.Controllers.Attachments
{
	[ApiController]
	[Route("api/bugs/{bugId}/attachments")]
	public class AttachmentController:ControllerBase
	{
		private readonly IAttachmentManager _attachmentManager;

		public AttachmentController(IAttachmentManager attachmentManager)
		{
			_attachmentManager=attachmentManager;
		}
		///////////////////////////////////////////////////////////////////
		[HttpPost]
		public async Task<Results<Ok<string>,NotFound>>
			AddAsync(Guid bugId,AttachmentDto attachmentDto)
		{
			var success=await _attachmentManager.AddAttachmentToBugAsync(bugId, attachmentDto);
			if (!success)
			{
				return TypedResults.NotFound();
			}
			return TypedResults.Ok("Attachment added");
		}
		///////////////////////////////////////////////////////////////////
		[HttpGet]
		public async Task<Results<Ok<List<AttachmentDto>>,NotFound>>
			GetAllAsync(Guid bugId)
		{
			var attachments=await _attachmentManager.GetBugAttachmentsAsync(bugId);
			if (attachments == null)
			{
				return TypedResults.NotFound();
			}
			return TypedResults.Ok(attachments);
		}
		///////////////////////////////////////////////////////////////////
		[HttpDelete("{attachmentId}")]
		public async Task<Results<Ok<string>,NotFound>>
			removeAsync(Guid bugId,Guid attachmentId)
		{
			var success=await _attachmentManager.RemoveAttachmentFromBugAsync(bugId, attachmentId);
			if (!success)
			{
				return TypedResults.NotFound();
			}
			return TypedResults.Ok("Attachment removed");
		}
	}
}
