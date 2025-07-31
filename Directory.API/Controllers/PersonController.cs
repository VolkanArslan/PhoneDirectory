using Directory.Application.Interfaces;
using Directory.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Directory.API.Controllers;

public class PersonController : ControllerBase
{
    private readonly IPersonRepository _personRepository;

    public PersonController(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePerson([FromBody] Person person)
    {
        var created = await _personRepository.CreateAsync(person);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var person = await _personRepository.GetByIdAsync(id);
        return person is null ? NotFound() : Ok(person);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var people = await _personRepository.GetAllAsync();
        return Ok(people);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _personRepository.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
}