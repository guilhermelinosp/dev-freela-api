using DevFreela.Domain.DTOs.Requests.Projects;
using DevFreela.Domain.DTOs.Responses.Projects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectController : ControllerBase
{
	private readonly IMediator _mediator;

	public ProjectController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	[Authorize(Roles = "client, freelancer")]
	public async Task<IActionResult> Get(string query)
	{
		var getAllProjectsQuery = new GetAllProjectsQuery();

		var projects = await _mediator.Send(getAllProjectsQuery);

		return Ok(projects);
	}

	[HttpGet("{id}")]
	[Authorize(Roles = "client, freelancer")]
	public async Task<IActionResult> GetById(int id)
	{
		var query = new GetProjectByIdQuery();

		var project = await _mediator.Send(query);

		if (project == null)
		{
			return NotFound();
		}

		return Ok(project);
	}

	[HttpPost]
	public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
	{
		var id = await _mediator.Send(command);

		return CreatedAtAction(nameof(GetById), new { id = id }, command);
	}

	[HttpPut("{id}")]
	[Authorize(Roles = "client")]
	public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
	{
		await _mediator.Send(command);

		return NoContent();
	}

	[HttpDelete("id")]
	[Authorize(Roles = "client")]
	public async Task<IActionResult> Delete(int id)
	{
		var command = new DeleteProjectCommand();

		await _mediator.Send(command);

		return NoContent();
	}

	[HttpPost("comments")]
	[Authorize(Roles = "client, freelancer")]
	public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand command)
	{
		await _mediator.Send(command);

		return NoContent();
	}

	[HttpPut("{id}/start")]
	[Authorize(Roles = "client")]
	public async Task<IActionResult> Start(int id)
	{
		var command = new StartProjectCommand();

		await _mediator.Send(command);

		return NoContent();
	}

	[HttpPut("{id}/finish")]
	public async Task<IActionResult> Finish(int id, FinishProjectCommand command)
	{
		//command.Id = id;

		var result = await _mediator.Send(command);

		//if (!result)
		//{
		//	return BadRequest("O pagamento não pode ser processado");
		//}
		return Accepted();
	}
}