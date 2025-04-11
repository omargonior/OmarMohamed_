using Bug_Ticketing_System.BL.Managers.Bug_User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Bug_Ticketing_System.Controllers.Bug_Users
{
	[ApiController]
	[Route("api/bugs")]
	public class BugUserController:ControllerBase
	{
		private readonly IBugUserManager _bugUserManager;

		public BugUserController(IBugUserManager bugUserManager)
		{
			_bugUserManager=bugUserManager;
		}
		////////////////////////////////////////////////////////////
		[HttpPost("{bugId}/assignees/{userId}")]
		public async Task<Results<Ok<string>,NotFound>>
			AddAsync(Guid bugId, string userId)
		{
			var success=await _bugUserManager.AddUserToBugAsync(bugId, userId);
			if (!success)
			{
				return TypedResults.NotFound();
			}
			return TypedResults.Ok("user added to bug successfully");
		}
		////////////////////////////////////////////////////////////
		[HttpDelete("{bugId}/assignees/{userId}")]
		public async Task<Results<Ok<string>,NotFound>>
			RemoveAsync(Guid bugId, string userId)
		{
			var success=await _bugUserManager.RemoveUserFromBugAsync(bugId, userId);
			if (!success)
			{
				return TypedResults.NotFound();
			}
			return TypedResults.Ok("user removed from bug successfully");
		}

	}
}
