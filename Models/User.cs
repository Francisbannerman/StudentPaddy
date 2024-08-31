using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class User
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ProfilePicture { get; set; }
    
    public Guid InstitutionId { get; set; }
    [ForeignKey("InstitutionId")] 
    public Institution Institution { get; set; }

    public Enum AcademicStatus { get; set; }
    public string Bio { get; set; }
    public List<string> Interests { get; set; }

    public List<Guid> FollowersId { get; set; }
    public List<User> Followers { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdateAt { get; set; }
}