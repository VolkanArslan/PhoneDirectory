namespace Directory.Domain.Entities;

public class Person
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
}