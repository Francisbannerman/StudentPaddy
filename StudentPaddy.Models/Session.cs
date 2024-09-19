using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Session
{
    public Guid SessionId { get; set; }
    
    public Guid RoomId { get; set; }
    [ForeignKey("RoomId")] 
    public ChatRoom Room { get; set; }

    public string SessionTitle { get; set; }
    public string Description { get; set; }
    public DateTimeOffset ScheduledAt { get; set; }

    public Guid HostId { get; set; }
    [ForeignKey("HostId")] 
    public User Host { get; set; }

    public List<Guid> ParticipantsId { get; set; }
    public List<User> Participants { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}