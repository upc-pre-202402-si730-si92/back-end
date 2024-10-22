using Domain.Learning.Model.Queries;
using Domain.Learning.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Learning.Resources;
using Presentation.Learning.Transform;

namespace Presentation.Learning.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TutorialController : ControllerBase
{
    private readonly ITutorialCommandService _tutorialCommandService;
    private readonly ITutorialQueryService _tutorialQueryService;

    public TutorialController(ITutorialQueryService tutorialQueryService,
        ITutorialCommandService tutorialCommandService)
    {
        _tutorialQueryService = tutorialQueryService;
        _tutorialCommandService = tutorialCommandService;
    }


    // GET: api/<Tutorial>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllTutorialsQuery();
        var result = await _tutorialQueryService.Handle(query);

        if (result.Count() == 0) return NotFound();

        return Ok(result);
    }

    // GET api/<Tutorial>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok();
    }

    // POST api/<Tutorial>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTutorialResource createTutorialResource)
    {
        try
        {
            var createTutorialCommand =
                CreateTutorialCommandFromResourceAssembler.ToCommandFromResource(createTutorialResource);

            await _tutorialCommandService.Handle(createTutorialCommand);

            return StatusCode(201);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    // PUT api/<Tutorial>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] string value)
    {
        return Ok();
    }

    // PUT api/<Tutorial>/5
    // [HttpPatch("{id}")]
    // public void Patch(int id, [FromBody] string value)
    // {
    // }


    // DELETE api/<Tutorial>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok();
    }
}