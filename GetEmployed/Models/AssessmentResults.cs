using System.ComponentModel.DataAnnotations.Schema;

namespace GetEmployed;

public class AssessmentResults
{
    public Guid AssessmentResultsId { get; set; }

    public Guid AssessmentRequestId { get; set; }
    [ForeignKey("AssessmentRequestId")]
    public AssessmentRequest AssessmentRequest { get; set; }

    public int RelevancyScore { get; set; }
    public string RelevanceScoreContext { get; set; }
    public int OverallResumeScore { get; set; }
    public string OverallResumeScoreContext { get; set; }

    public string ImpactContent { get; set; }
    public string BrevityContent { get; set; }
    public string StyleContent { get; set; }
    public string SectionsContent { get; set; }
    public string SkillsContent { get; set; }
    
    public Guid UserId { get; set; }
    [ForeignKey("UserId")] 
    public User User { get; set; }

    public bool WasAutoFixAllUsed { get; set; }
}