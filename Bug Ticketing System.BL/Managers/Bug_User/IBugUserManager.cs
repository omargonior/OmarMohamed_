namespace Bug_Ticketing_System.BL.Managers.Bug_User
{
	public interface IBugUserManager
	{
		Task<bool> AddUserToBugAsync(Guid bugId,string userId);
		Task<bool> RemoveUserFromBugAsync(Guid bugId,string userId);
	}
}
