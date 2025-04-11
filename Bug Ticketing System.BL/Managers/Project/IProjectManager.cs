using Bug_Ticketing_System.BL.DTOs;

namespace Bug_Ticketing_System.BL.Managers.Project
{
	public interface IProjectManager
	{
		Task<List<ProjectDto>> GetAllProjectsAsync();
		Task<ProjectDto> GetProjectByIdAsync(Guid id);
		Task AddProjectAsync(ProjectDto projectDto);
	}
}
