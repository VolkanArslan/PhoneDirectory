namespace Directory.Application.DTOs.Statistics;

public class LocationStatisticsDto
{
    public string Location { get; set; } = string.Empty;
    public int PersonCount { get; set; }
    public int PhoneNumberCount { get; set; }
    public int EmailCount { get; set; }
}