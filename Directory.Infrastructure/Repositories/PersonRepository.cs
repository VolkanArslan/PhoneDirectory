using Directory.Application.Interfaces;
using Directory.Domain.Entities;
using Directory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Directory.Infrastructure.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly ApplicationDbContext _context;

    public PersonRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Person> CreateAsync(Person person)
    {
        _context.People.Add(person);
        await _context.SaveChangesAsync();
        return person;
    }

    public async Task<Person?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.People.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<List<Person>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.People.ToListAsync(cancellationToken);
    }
    
    public async Task AddAsync(Person person, CancellationToken cancellationToken)
    {
        await _context.People.AddAsync(person, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var person = await _context.People
            .Include(p => p.ContactInformations)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        
        if (person == null) return false;
        
        _context.People.Remove(person);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}