using Bug_Ticketing_System.BL.DTOs;
using Bug_Ticketing_System.BL.Managers.Bug;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Bug_Ticketing_System.Controllers.Bugs
{
	[ApiController]
	[Route("api/bugs")]
	public class BugController:ControllerBase
	{
		private readonly IBugManager _bugManager;

		public BugController(IBugManager bugManager)
		{
			_bugManager=bugManager;
		}
		///////////////////////////////////////////////////////////////
		[HttpPost]
		public async Task<NoContent>AddAsync(BugDto bugDto)
		{
			await _bugManager.AddBugAsync(bugDto);
			return TypedResults.NoContent();
		}
		///////////////////////////////////////////////////////////////
		[HttpGet]
		public async Task<Results<Ok<List<BugDto>>, NotFound>> GetAllAsync()
		{
			var bugs=await _bugManager.GetAllBugsAsync();
			if (bugs == null)
			{
				return TypedResults.NotFound();
			}
			return TypedResults.Ok(bugs);
		}
		///////////////////////////////////////////////////////////////
		[HttpGet("{id}")]
		public async Task<Results<Ok<BugDto>, NotFound>>
			GetByIdAsync(Guid id)
		{
			var bug=await _bugManager.GetBugByIdAsync(id);
			if (bug == null)
			{
				return TypedResults.NotFound();
			}
			return TypedResults.Ok(bug);
		}
	}
}
