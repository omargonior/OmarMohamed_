using Bug_Ticketing_System.BL.DTOs;
using Bug_Ticketing_System.DAL;

namespace Bug_Ticketing_System.BL.Managers.Project
{
	
	public class ProjectManager : IProjectManager
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProjectManager(IUnitOfWork unitOfWork)
		{
			_unitOfWork= unitOfWork;
		}
		public async Task AddProjectAsync(ProjectDto projectDto)
		{
			var project = new DAL.Project
			{
				Name = projectDto.Name,
				Bugs = projectDto.Bugs
			};
			await _unitOfWork.Project.AddAsync(project);
			await _unitOfWork.CompleteAsync();
		}
		/////////////////////////////////////////////////////////////
		public async Task<List<ProjectDto>> GetAllProjectsAsync()
		{
			var projects=await _unitOfWork.Project.GetAllAsync();
			var projectsDto = projects.Select(p => new ProjectDto
			{
				Id = p.Id,
				Name = p.Name,
				Bugs = p.Bugs
			}).ToList();
			return projectsDto;
		}
		/////////////////////////////////////////////////////////////
		public async Task<ProjectDto?> GetProjectByIdAsync(Guid id)
		{
			var project=await _unitOfWork.Project.GetByIdAsync(id);
			if (project != null)
			{
				var projectDto = new ProjectDto
				{
					Id = project.Id,
					Name = project.Name,
					Bugs = project.Bugs
				};
				return projectDto;
			}
			return null;
		}
	}
}
