using Domain.Learning.Model.Commands;
using Domain.Learning.Model.Queries;
using Domain.Learning.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Learning.Resources;
using Presentation.Learning.Transform;

namespace Presentation.Learning.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TutorialController(
    ITutorialQueryService tutorialQueryService,
    ITutorialCommandService tutorialCommandService)
    : ControllerBase
{
    // GET: api/tutorial
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllTutorialsQuery();
        var tutorials = await tutorialQueryService.Handle(query);

        if (!tutorials.Any())
            return NotFound();

        var resources = tutorials
            .Select(TutorialResourceFromEntityAssembler.ToResourceFromEntity)
            .ToList();

        return Ok(resources);
    }

    // GET: api/tutorial/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetTutorialByIdQuery(id);
        var tutorial = await tutorialQueryService.Handle(query);

        if (tutorial == null)
            return NotFound();

        var resource = TutorialResourceFromEntityAssembler.ToResourceFromEntity(tutorial);

        return Ok(resource);
    }

    // POST: api/tutorial
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTutorialResource createTutorialResource)
    {
        if (createTutorialResource == null)
            return BadRequest("Invalid resource data.");

        var command = CreateTutorialCommandFromResourceAssembler
            .ToCommandFromResource(createTutorialResource);

        var result = await tutorialCommandService.Handle(command);

        return CreatedAtAction(nameof(GetById), new { id = result }, new { data = result });
    }

    // PUT: api/tutorial/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTutorialResource updateTutorialResource)
    {
        if (updateTutorialResource == null)
            return BadRequest("Invalid resource data.");

        var command = UpdateTutorialCommandFromResourceAssembler
            .ToCommandFromResource(id, updateTutorialResource);

        var result = await tutorialCommandService.Handle(command);

        return result ? NoContent() : NotFound();
    }

    // DELETE: api/tutorial/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteTutorialCommand(id);
        var result = await tutorialCommandService.Handle(command);

        return result ? NoContent() : NotFound();
    }
}