namespace Models;

public class Institution
{
    public Guid InstitutionId { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdateAt { get; set; }
}