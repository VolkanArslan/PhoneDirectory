using Directory.Application.DTOs.ContactInformation;
using Directory.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Directory.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactInformationController(
    IDeleteContactInformationUseCase deleteUseCase,
    ICreateContactInformationUseCase createUseCase,
    IGetContactInformationUseCase getUseCase)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateContactInformationRequest request, CancellationToken cancellationToken)
    {
        var result = await createUseCase.ExecuteAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("person/{personId}")]
    public async Task<IActionResult> GetByPersonId(Guid personId, CancellationToken cancellationToken)
    {
        var infos = await getUseCase.ExecuteAsync(personId, cancellationToken);
        return Ok(infos);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await deleteUseCase.ExecuteAsync(id, cancellationToken);
        return result ? NoContent() : NotFound();
    }
}