using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Notification
{
    public Guid NotificationId { get; set; }
    
    public Guid UserId { get; set; }
    [ForeignKey("UserId")] 
    public User NotificationReceiver { get; set; }

    public string NotificationMassage { get; set; }
    public bool IsRead { get; set; }
    public Enum NotificationType { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}