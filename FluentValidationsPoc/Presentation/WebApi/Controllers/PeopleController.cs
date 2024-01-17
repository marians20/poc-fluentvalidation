using Contracts.Dtos;
using Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase
{
    private readonly IPeopleService peopleService;

    public PeopleController(IPeopleService peopleService)
    {
        this.peopleService = peopleService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var people = await peopleService.GetAllAsync();

        return Ok(people);
    }

    [HttpPost]
    public IActionResult Post(CreatePersonDto person)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var id = peopleService.Create(person);

        return Ok(id);
    }
}
