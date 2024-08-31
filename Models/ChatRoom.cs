using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class ChatRoom
{
    public Guid RoomId { get; set; }
    public string RoomName { get; set; }
    public string RoomCode { get; set; } //to invite other participants to room
    
    public Guid CreatedById { get; set; }
    [ForeignKey("CreatedById")] 
    public User CreatedBy { get; set; }

    public List<Guid> ParticipantsId { get; set; }
    public List<User> Participants { get; set; }

    public Enum Visibility { get; set; }
    public string Topic { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}