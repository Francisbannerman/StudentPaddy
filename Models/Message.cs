using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Message
{
    public Guid MessageId { get; set; }

    public Guid SessionId { get; set; }
    [ForeignKey("SessionId")] 
    public Session Session { get; set; }
    
    public Guid SenderId { get; set; }
    [ForeignKey("SenderId")] 
    public User Sender { get; set; }

    public string MessageContent { get; set; }
    public Enum MessageType { get; set; }
    public DateTimeOffset TimeMessageIsSpent { get; set; }

    public List<Guid> SeenByUsersIds { get; set; }
    public List<User> SeenByUsers { get; set; }

    public bool IsEdited { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdateAt { get; set; }
}