using Directory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Directory.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Person> People => Set<Person>();
}