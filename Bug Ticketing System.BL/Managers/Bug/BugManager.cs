using Bug_Ticketing_System.BL.DTOs;
using Bug_Ticketing_System.DAL;

namespace Bug_Ticketing_System.BL.Managers.Bug
{
	public class BugManager : IBugManager
	{
		private readonly IUnitOfWork _unitOfWork;

		public BugManager(IUnitOfWork unitOfWork)
		{
			_unitOfWork=unitOfWork;
		}
		////////////////////////////////////////////////////////////////////
		public async Task AddBugAsync(BugDto bugDto)
		{
			var bug = new DAL.Bug
			{
				Name = bugDto.Name,
				ProjectId = bugDto.ProjectId,
			};
			await _unitOfWork.Bug.AddAsync(bug);
			await _unitOfWork.CompleteAsync();
		}
		////////////////////////////////////////////////////////////////////
		public async Task<List<BugDto>> GetAllBugsAsync()
		{
			var bugs=await _unitOfWork.Bug.GetAllAsync();
			var bugsDto=bugs.Select(b=>new BugDto
			{
				Id = b.Id,
				Name = b.Name,
				ProjectId=b.ProjectId,
			}).ToList();
			return bugsDto;
		}
		////////////////////////////////////////////////////////////////////
		public async Task<BugDto?> GetBugByIdAsync(Guid id)
		{
			var bug=await _unitOfWork.Bug.GetByIdAsync(id);
			if (bug == null)
			{
				return null;
			}
			var bugDto = new BugDto
			{
				Id = bug.Id,
				Name = bug.Name,
				ProjectId = bug.ProjectId,
			};
			return bugDto;
		}
	}
}
