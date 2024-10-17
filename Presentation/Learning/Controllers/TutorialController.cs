using Application.Learning.QueryServices;
using Domain.Learning.Model.Commands;
using Domain.Learning.Model.Entities;
using Domain.Learning.Model.Queries;
using Domain.Learning.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Learning.Resources;

namespace Presentation.Learning.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TutorialController : ControllerBase
{
    private readonly ITutorialQueryService _tutorialQueryService;
    private readonly ITutorialCommandService _tutorialCommandService;
    public TutorialController(ITutorialQueryService tutorialQueryService,ITutorialCommandService tutorialCommandService)
    {
        _tutorialQueryService = tutorialQueryService;
        _tutorialCommandService = tutorialCommandService;
    }
    
    
    // GET: api/<Tutorial>
    [HttpGet]
    public  async Task<IEnumerable<Tutorial>> Get()
    {
        var query = new GetAllTutorialsQuery();
      return  await _tutorialQueryService.Handle(query);
    }

    // GET api/<Tutorial>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<Tutorial>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTutorialResource data)
    {
        try
        {
            var command = new CreateTutorialCommand(data.Title, data.Summary);

            await _tutorialCommandService.Handle(command);

            return StatusCode(201);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    // PUT api/<Tutorial>/5
    [HttpPut("{id}")]
    public async Task<IActionResult>  Put(int id, [FromBody] string value)
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
    public async Task<IActionResult>  Delete(int id)
    {    
        return Ok();
    }
}