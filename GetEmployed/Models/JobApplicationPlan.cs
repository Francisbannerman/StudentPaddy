using System.ComponentModel.DataAnnotations.Schema;

namespace GetEmployed;

public class JobApplicationPlan
{
    public Guid ApplicationPlanId { get; set; }

    public Guid PlanId { get; set; }
    [ForeignKey("PlanId")] 
    public Plan Plan { get; set; }

    public bool HasUserPaidForPlan { get; set; }
    public bool WasPaymentSuccessful { get; set; }
    public string TransactionId { get; set; }
}