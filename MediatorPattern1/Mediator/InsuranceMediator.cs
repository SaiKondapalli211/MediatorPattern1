using MediatorPattern1.Service;

namespace MediatorPattern1.Mediator
{
    public class InsuranceMediator : IInsuranceMediator
    {
        private readonly IServiceProvider _serviceProvider;
        public InsuranceMediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Notify(object sender, string eventType)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var premiumService = scope.ServiceProvider.GetRequiredService<PremiumService>();
                var notificationService = scope.ServiceProvider.GetRequiredService<NotificationService>();
                var claimService = scope.ServiceProvider.GetRequiredService<ClaimService>();


                if (eventType == "PolicyCreated")
                {
                    Console.WriteLine("Mediator: Notifying premium and notification services...");

                    premiumService.CalculatePremium();
                    notificationService.SendNotification("Policy has been created successfully.");
                }
                else if (eventType == "ClaimRequested")
                {
                    Console.WriteLine("Mediator: Notifying claim and notification services...");
                    claimService.ProcessClaim();
                    notificationService.SendNotification("Claim request is being processed.");
                }
            }

        }
    }
}
