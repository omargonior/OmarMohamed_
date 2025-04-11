using Bug_Ticketing_System.BL.DTOs;
using Bug_Ticketing_System.BL.Managers.Project;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Bug_Ticketing_System.Controllers.Projects
{
	[ApiController]
	[Route("api/projects")]
	public class ProjectController:ControllerBase
	{
		private readonly IProjectManager _projectManager;

		public ProjectController(IProjectManager projectManager)
		{
			_projectManager=projectManager;
		}
		/////////////////////////////////////////////////////////////////
		[HttpPost]
		public async Task<NoContent> AddAsync(ProjectDto projectDto)
		{
			await _projectManager.AddProjectAsync(projectDto);
			return TypedResults.NoContent();
		}
		/////////////////////////////////////////////////////////////////
		[HttpGet]
		public async Task<Results<Ok<List<ProjectDto>>,NotFound>> GetAllAsync()
		{
			var projects=await _projectManager.GetAllProjectsAsync();
			if (projects == null)
			{
				return TypedResults.NotFound();
			}
			return TypedResults.Ok(projects);
		}
		//////////////////////////////////////////////////////////////////

		[HttpGet("{id}")]
		public async Task<Results<Ok<ProjectDto>,NotFound>>
			GetByIdAsync(Guid id)
		{
			var project=await _projectManager.GetProjectByIdAsync(id);
			if (project == null)
			{
				return TypedResults.NotFound();
			}
			return TypedResults.Ok(project);
		}

	}
}
