using Bug_Ticketing_System.BL.DTOs;

namespace Bug_Ticketing_System.BL.Managers.Bug
{
	public interface IBugManager
	{
		Task AddBugAsync(BugDto bugDto);
		Task<List<BugDto>> GetAllBugsAsync();
		Task<BugDto> GetBugByIdAsync(Guid id);
	}
}
