using System.ComponentModel.DataAnnotations.Schema;

namespace GetEmployed;

public class User
{
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TelephoneNumber { get; set; }
    public string Password { get; set; }

    public bool IsUserOnAPlan { get; set; }
    
    public Guid? JobApplicationPlanId { get; set; }
    [ForeignKey("JobApplicationPlanId")] 
    public JobApplicationPlan? JobApplicationPlan { get; set; }

    public int TotalJobsApplied { get; set; }
    public int TotalOffersReceived { get; set; }
    public int TotalUpcomingInterviews { get; set; }
    public int TotalNumberOfRejections { get; set; }
    
    public bool IsUserAMentor { get; set; }
}