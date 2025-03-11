using MediatorPattern1.Mediator;

namespace MediatorPattern1.Service
{
    public class PolicyService : BaseService
    {
        public PolicyService(IInsuranceMediator mediator) : base(mediator) { }

        public void CreatePolicy()
        {
            Console.WriteLine("PolicyService: Creating a new policy...");
            _mediator.Notify(this, "PolicyCreated");
        }
    }

    public class ClaimService : BaseService
    {
        public ClaimService(IInsuranceMediator mediator) : base(mediator) { }

        public void ProcessClaim()
        {
            Console.WriteLine("ClaimService: Processing claim...");
        }

        public void RequestClaim()
        {
            Console.WriteLine("ClaimService: Customer requested a claim...");
            _mediator.Notify(this, "ClaimRequested");
        }
    }

    public class PremiumService
    {
        public void CalculatePremium()
        {
            Console.WriteLine("PremiumService: Calculating premium based on policy details...");
        }
    }

    public class NotificationService
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"NotificationService: {message}");
        }
    }

}
