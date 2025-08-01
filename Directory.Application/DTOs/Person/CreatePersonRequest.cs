namespace Directory.Application.DTOs.Person;

public class CreatePersonRequest
{
    public required string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Company { get; set; }
}