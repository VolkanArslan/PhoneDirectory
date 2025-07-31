using Directory.Application.Interfaces;
using Directory.Domain.Entities;
using Directory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Directory.Infrastructure.Repositories;

public class ContactInformationRepository : IContactInformationRepository
{
    private readonly ApplicationDbContext _context;

    public ContactInformationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ContactInformation> CreateAsync(ContactInformation info, CancellationToken cancellationToken)
    {
        await _context.ContactInformations.AddAsync(info, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return info;
    }

    public async Task<List<ContactInformation>> GetByPersonIdAsync(Guid personId, CancellationToken cancellationToken)
    {
        return await _context.ContactInformations
            .Where(x => x.PersonId == personId)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var info = await _context.ContactInformations.FindAsync(new object[] { id }, cancellationToken);
        if (info == null)
            return false;

        _context.ContactInformations.Remove(info);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}