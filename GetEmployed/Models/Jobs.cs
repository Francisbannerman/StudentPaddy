namespace GetEmployed;

public class Jobs
{
    public Guid JobId { get; set; }
    public string JobTitle { get; set; }
    public string CompanyOfferingJobName { get; set; }
    public decimal? TentativePay { get; set; }
    public Enum ExperienceLevel { get; set; }
    public string? JobDescription { get; set; }
}