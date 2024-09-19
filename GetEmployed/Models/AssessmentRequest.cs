using System.ComponentModel.DataAnnotations.Schema;

namespace GetEmployed;

public class AssessmentRequest
{
    public Guid AssessmentRequestId { get; set; }
    public Enum Industry { get; set; }
    public bool PriorExperience { get; set; }
    public int YearsOfExperience { get; set; }
    public string Skills { get; set; }
    public string PdfFilename { get; set; }
    public byte[] PdfFileContent { get; set; }
    
    public Guid UserId { get; set; }
    [ForeignKey("UserId")] 
    public User User { get; set; }
}