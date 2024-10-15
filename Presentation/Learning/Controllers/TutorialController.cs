using Application.Learning.QueryServices;
using Domain.Learning.Model.Entities;
using Domain.Learning.Model.Queries;
using Domain.Learning.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Learning.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TutorialController : ControllerBase
{
    private readonly ITutorialQueryService _tutorialQueryService;
    public TutorialController(ITutorialQueryService tutorialQueryService)
    {
        _tutorialQueryService = tutorialQueryService;
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
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<Tutorial>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<Tutorial>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}