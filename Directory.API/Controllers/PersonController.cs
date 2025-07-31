using Directory.Application.DTOs;
using Directory.Application.Interfaces;
using Directory.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Directory.API.Controllers;

public class PersonController : ControllerBase
{
    public readonly ICreatePersonUseCase _createPersonUseCase;
    public readonly IDeletePersonUseCase _deletePersonUseCase;
    public readonly IGetPersonUseCase _getPersonUseCase;

    public PersonController(
        ICreatePersonUseCase createPersonUseCase, 
        IDeletePersonUseCase deletePersonUseCase, 
        IGetPersonUseCase getPersonUseCase)
    {
        _createPersonUseCase = createPersonUseCase;
        _deletePersonUseCase = deletePersonUseCase;
        _getPersonUseCase = getPersonUseCase;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreatePersonRequest request)
    {
        var result = await _createPersonUseCase.ExecuteAsync(request);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var person = await _getPersonUseCase.GetByIdPerson(id, cancellationToken);
        return person is null ? NotFound() : Ok(person);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var people = await _getPersonUseCase.GetAllPersons(cancellationToken);
        return Ok(people);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var success = await _deletePersonUseCase.ExecuteAsync(id, cancellationToken);
        return success ? NoContent() : NotFound();
    }
}