using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectController: ControllerBase
{
	public ProjectController()
	{
	}
	
	[HttpGet]
	public IActionResult Get()
	{
		return Ok();
	}
	
	[HttpGet("{id}")]
	public IActionResult GetById(int id)
	{
		return Ok();
	}
	
	[HttpPost]
	public IActionResult Post([FromBody] string inputModel)
	{
		return CreatedAtAction("Get", new { id = 1 }, inputModel);
	}
	
	[HttpPut("{id}")]
	public IActionResult Put(int id, [FromBody] string inputModel)
	{
		return NoContent();
	}
	
	[HttpDelete("{id}")]
	public IActionResult Put(int id)
	{
		return NoContent();
	}
}