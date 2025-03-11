using MediatorPattern1.Mediator;
using MediatorPattern1.Service;

namespace MediatorPattern1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register Mediator and Services
            builder.Services.AddSingleton<IInsuranceMediator, InsuranceMediator>();
            builder.Services.AddTransient<PolicyService>();
            builder.Services.AddTransient<ClaimService>();
            builder.Services.AddTransient<PremiumService>();
            builder.Services.AddTransient<NotificationService>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var policyService = scope.ServiceProvider.GetRequiredService<PolicyService>();
                var claimService = scope.ServiceProvider.GetRequiredService<ClaimService>();

                // Create a policy
                policyService.CreatePolicy();

                Console.WriteLine("\n--------------------------------\n");

                // Request a claim
                claimService.RequestClaim();
            }

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}