using Directory.Application.Interfaces;
using Directory.Application.Interfaces.ContactInformation;
using Directory.Domain.Entities;
using Directory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Directory.Infrastructure.Repositories;

public class ContactInformationRepository(ApplicationDbContext context) : IContactInformationRepository
{
    public async Task<ContactInformation> CreateAsync(ContactInformation info, CancellationToken cancellationToken)
    {
        await context.ContactInformations.AddAsync(info, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return info;
    }

    public async Task<List<ContactInformation>> GetByPersonIdAsync(Guid personId, CancellationToken cancellationToken)
    {
        return await context.ContactInformations
            .Where(x => x.PersonId == personId)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var info = await context.ContactInformations.FindAsync(new object[] { id }, cancellationToken);
        if (info == null)
            return false;

        context.ContactInformations.Remove(info);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}