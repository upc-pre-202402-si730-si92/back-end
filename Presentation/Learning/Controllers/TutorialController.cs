using Domain.Learning.Model.Commands;
using Domain.Learning.Model.Entities;
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
    /// <summary>
    /// method for get all active tutorials
    /// </summary>
    /// <response code="200">Returns all the tutorials without filter</response>
    /// <response code="404">Tutorial not found</response>
    /// <response code="500">Error with server</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Tutorial>),200 )]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [Produces("application/json")]
    public async Task<IActionResult> GetAll()
    {
        try
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
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    // GET: api/tutorial/5
    /// <summary>
    /// This method is to get tutorial by Id
    /// </summary>
    /// <param name="id">the id is the identifier of the tutorial </param>
    /// <returns></returns>
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
    /// <summary>
    /// method for create new Tutorial
    /// </summary>
    /// <remarks>
    ///     sample Request
    ///     POST /api/tutorial
    ///     {
    ///        "title": "New tutorial",
    ///        "summary": "Description of tutorial"
    ///     }
    ///
    /// </remarks>
    [HttpPost]
    
    public async Task<IActionResult> Create([FromBody] CreateTutorialResource createTutorialResource)
    {
        try
        {
            if ( createTutorialResource == null || !ModelState.IsValid) return BadRequest("Invalid resource data.");
            
            var command = CreateTutorialCommandFromResourceAssembler
                .ToCommandFromResource(createTutorialResource);
            
            var result = await tutorialCommandService.Handle(command);

            return CreatedAtAction(nameof(GetById), new { id = result }, new { data = result });
        }
        catch (Exception ex)
        {
            //Guardarlo - loggearlo
          throw  ex;
        }
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