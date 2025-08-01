using Directory.Application.Interfaces;
using Directory.Application.Interfaces.Person;
using Directory.Domain.Entities;
using Directory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Directory.Infrastructure.Repositories;

public class PersonRepository(ApplicationDbContext context) : IPersonRepository
{
    public async Task<Person> CreateAsync(Person person)
    {
        context.People.Add(person);
        await context.SaveChangesAsync();
        return person;
    }

    public async Task<Person?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.People.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<List<Person>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.People.ToListAsync(cancellationToken);
    }
    
    public async Task AddAsync(Person person, CancellationToken cancellationToken)
    {
        await context.People.AddAsync(person, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var person = await context.People
            .Include(p => p.ContactInformations)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        
        if (person == null) return false;
        
        context.People.Remove(person);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
    
    public async Task<List<Person>> GetAllWithContactInfosAsync(CancellationToken cancellationToken)
    {
        return await context.People
            .Include(p => p.ContactInformations)
            .ToListAsync(cancellationToken);
    }
}