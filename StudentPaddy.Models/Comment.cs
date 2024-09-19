
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Comment
{
    public Guid CommentId { get; set; }
    public string CommentContent { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public List<Guid> UsersThatHaveLikedTheCommentId { get; set; }
    public int NumberOfLikes { get; set; }
    public List<User> UsersThatHaveLikedTheComment { get; set; }

    public Guid PostId { get; set; }
    [ForeignKey("PostId")] 
    public PostedContents Post { get; set; }
    
    public Guid PosterId { get; set; }
    [ForeignKey("PosterId")] 
    public User Poster { get; set; }
}