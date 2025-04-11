
using Bug_Ticketing_System.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bug_Ticketing_System.BL.Managers.Bug_User
{
	public class BugUserManager : IBugUserManager
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly UserManager<User> _userManager;

		public BugUserManager(IUnitOfWork unitOfWork
			,UserManager<User>userManager)
		{
			_unitOfWork=unitOfWork;
			_userManager=userManager;
		}
		public async Task<bool> AddUserToBugAsync(Guid bugId, string userId)
		{
			var bug=await _unitOfWork.Bug.GetByIdAsync(bugId);
			if (bug == null) 
			{ 
				return false;
			}
			var user=await _userManager.Users.Where(u=>u.Id==userId)
				.Include(u=>u.Bug_Users)
				.FirstOrDefaultAsync();
			if (user == null)
			{
				return false;
			}
			var aleadyExists=user.Bug_Users
				.Any(bu=>bu.BugId==bugId);
			if (aleadyExists)
			{
				return false;
			}
			var bug_user = new DAL.Bug_User
			{
				BugId = bugId,
				UserId = user.Id,
			};
			await _unitOfWork.Bug_User.AddAsync(bug_user);
			await _unitOfWork.CompleteAsync();
			return true;
		}
		////////////////////////////////////////////////////////////////////
		public async Task<bool> RemoveUserFromBugAsync(Guid bugId, string userId)
		{
			var bug = await _unitOfWork.Bug.GetByIdAsync(bugId);
			if (bug == null)
			{
				return false;
			}
			var user = await _userManager.Users.Where(u => u.Id == userId)
				.Include(u => u.Bug_Users)
				.FirstOrDefaultAsync();
			if (user == null)
			{
				return false;
			}
			
			var userToRemove=user.Bug_Users
				.FirstOrDefault(bu=>bu.BugId == bugId);
			if (userToRemove == null)
			{
				return false;
			}
			 _unitOfWork.Bug_User.Delete(userToRemove);
			await _unitOfWork.CompleteAsync();
			return true;
		}
	}
}
