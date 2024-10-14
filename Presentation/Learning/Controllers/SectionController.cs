using Microsoft.AspNetCore.Mvc;

namespace Presentation.Learning.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SectionController : ControllerBase
{
    // GET: api/<SectionController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new[] { "value1", "value2" };
    }

    // GET api/<SectionController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<SectionController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<SectionController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<SectionController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}