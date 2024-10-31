using Domain.Learning.Model.Commands;
using Domain.Learning.Model.Entities;
using Domain.Learning.Model.Queries;
using Domain.Learning.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Learning.Resources;
using Presentation.Learning.Transform;

namespace Presentation.Learning.Controllers;

/// <summary>
/// 
/// </summary>
/// <param name="tutorialQueryService"></param>
/// <param name="tutorialCommandService"></param>
[Route("api/[controller]")]
[ApiController]
public class TutorialController(
    ITutorialQueryService tutorialQueryService,
    ITutorialCommandService tutorialCommandService)
    : ControllerBase
{
    /// <summary>
    /// Gets all active tutorials.
    /// </summary>
    /// <returns>Returns a list of all active tutorials.</returns>
    /// <response code="200">Returns all the tutorials without filter</response>
    /// <response code="404">No tutorials found</response>
    /// <response code="500">An error occurred on the server</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Tutorial>), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [Produces("application/json")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var query = new GetAllTutorialsQuery();
            var tutorials = await tutorialQueryService.Handle(query);

            if (tutorials != null && !tutorials.Any())
                return NotFound();

            var resources = tutorials
                .Select(TutorialResourceFromEntityAssembler.ToResourceFromEntity)
                .ToList();

            return Ok(resources);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    /// <summary>
    /// Gets a tutorial by its unique ID.
    /// </summary>
    /// <param name="id">The unique identifier of the tutorial.</param>
    /// <returns>Returns the tutorial if found.</returns>
    /// <response code="200">Returns the tutorial with the specified ID</response>
    /// <response code="404">Tutorial not found</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Tutorial), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetTutorialByIdQuery(id);
        var tutorial = await tutorialQueryService.Handle(query);

        if (tutorial == null)
            return NotFound();

        var resource = TutorialResourceFromEntityAssembler.ToResourceFromEntity(tutorial);

        return Ok(resource);
    }


    /// <summary>
    /// Creates a new tutorial.
    /// </summary>
    /// <param name="createTutorialResource">The details of the tutorial to create.</param>
    /// <returns>Returns the newly created tutorial.</returns>
    /// <response code="201">Tutorial created successfully</response>
    /// <response code="400">Invalid tutorial data</response>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/tutorial
    ///     {
    ///        "title": "New tutorial",
    ///        "summary": "Description of tutorial"
    ///     }
    ///
    /// </remarks>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] CreateTutorialResource createTutorialResource)
    {
        if (!ModelState.IsValid) return BadRequest("Invalid resource data.");

        var command = CreateTutorialCommandFromResourceAssembler
            .ToCommandFromResource(createTutorialResource);

        var result = await tutorialCommandService.Handle(command);

        return CreatedAtAction(nameof(GetById), new { id = result }, new { data = result });
    }

    /// <summary>
    /// Updates an existing tutorial by ID.
    /// </summary>
    /// <param name="id">The ID of the tutorial to update.</param>
    /// <param name="updateTutorialResource">The updated tutorial details.</param>
    /// <response code="204">Tutorial updated successfully</response>
    /// <response code="400">Invalid tutorial data</response>
    /// <response code="404">Tutorial not found</response>
    [HttpPut("{id:int}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTutorialResource updateTutorialResource)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid resource data.");

        var command = UpdateTutorialCommandFromResourceAssembler
            .ToCommandFromResource(id, updateTutorialResource);

        var result = await tutorialCommandService.Handle(command);

        return result ? NoContent() : NotFound();
    }

    /// <summary>
    /// Deletes a tutorial by ID.
    /// </summary>
    /// <param name="id">The ID of the tutorial to delete.</param>
    /// <response code="204">Tutorial deleted successfully</response>
    /// <response code="404">Tutorial not found</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteTutorialCommand(id);
        var result = await tutorialCommandService.Handle(command);

        return result ? NoContent() : NotFound();
    }
}