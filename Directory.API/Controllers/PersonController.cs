using Directory.Application.DTOs;
using Directory.Application.Interfaces;
using Directory.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Directory.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController(
    ICreatePersonUseCase createPersonUseCase,
    IDeletePersonUseCase deletePersonUseCase,
    IGetPersonUseCase getPersonUseCase)
    : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Create(CreatePersonRequest request)
    {
        var result = await createPersonUseCase.ExecuteAsync(request);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var person = await getPersonUseCase.GetByIdPerson(id, cancellationToken);
        return person is null ? NotFound() : Ok(person);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var people = await getPersonUseCase.GetAllPersons(cancellationToken);
        return Ok(people);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var success = await deletePersonUseCase.ExecuteAsync(id, cancellationToken);
        return success ? NoContent() : NotFound();
    }
}