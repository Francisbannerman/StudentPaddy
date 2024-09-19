using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace GetEmployed;

public class AppliedJobs
{
    public Guid AppliedJobId { get; set; }
    public DateTimeOffset DateApplied { get; set; }

    public Guid JobId { get; set; }
    [ForeignKey("JobId")] 
    public Jobs Job { get; set; }
    
    public Guid UserId { get; set; }
    [ForeignKey("UserId")] 
    public User User { get; set; }

    public Enum ApplicationStatus { get; set; }
    public List<DateTimeOffset>? ApplicationsAppointmentDates { get; set; }
    public Enum ApplicationsAppointmentType { get; set; }
}