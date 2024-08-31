using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class PostedContents
{
    public Guid PostId { get; set; }
    
    public Guid PostedById { get; set; }
    [ForeignKey("PostedById")] 
    public User PostedBy { get; set; }

    public string PostTitle { get; set; }
    public string PostContent { get; set; }
    public string Tags { get; set; }
    
    public List<Guid> UsersThatHaveLikedAPostId { get; set; }
    public int NumberOfLikes { get; set; }
    public List<User> UsersThatHaveLikedAPost { get; set; }
    
    public List<Guid> UsersThatHaveCommentedId { get; set; }
    public int NumberOfComments { get; set; }
    public List<User> UsersThatHaveCommented { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}