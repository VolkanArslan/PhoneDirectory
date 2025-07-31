using Directory.Application.DTOs.ContactInformation;
using Directory.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Directory.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactInformationController : ControllerBase
{
    private readonly ICreateContactInformationUseCase _createUseCase;
    private readonly IDeleteContactInformationUseCase _deleteUseCase;
    private readonly IContactInformationRepository _repository;

    public ContactInformationController(
        IContactInformationRepository repository, 
        IDeleteContactInformationUseCase deleteUseCase, 
        ICreateContactInformationUseCase createUseCase)
    {
        _repository = repository;
        _deleteUseCase = deleteUseCase;
        _createUseCase = createUseCase;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateContactInformationRequest request, CancellationToken cancellationToken)
    {
        var result = await _createUseCase.ExecuteAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("person/{personId}")]
    public async Task<IActionResult> GetByPersonId(Guid personId, CancellationToken cancellationToken)
    {
        var infos = await _repository.GetByPersonIdAsync(personId, cancellationToken);
        return Ok(infos);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await _deleteUseCase.ExecuteAsync(id, cancellationToken);
        return result ? NoContent() : NotFound();
    }
}