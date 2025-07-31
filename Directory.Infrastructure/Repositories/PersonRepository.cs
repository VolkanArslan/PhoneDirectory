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

    public async Task<Person?> GetByIdAsync(Guid id)
    {
        return await _context.People.FindAsync(id);
    }

    public async Task<List<Person>> GetAllAsync()
    {
        return await _context.People.ToListAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var person = await _context.People.FindAsync(id);
        if (person == null) return false;
        _context.People.Remove(person);
        await _context.SaveChangesAsync();
        return true;
    }
}