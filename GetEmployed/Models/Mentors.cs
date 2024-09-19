using System.ComponentModel.DataAnnotations.Schema;

namespace GetEmployed;

public class Mentee
{
    public Guid MenteeId { get; set; }

    public Guid MentorId { get; set; }
    [ForeignKey("MentorId")]
    public User Mentor { get; set; }
}