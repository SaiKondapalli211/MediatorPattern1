namespace MediatorPattern1.Mediator
{
    public interface IInsuranceMediator
    {
        void Notify(object sender, string eventType);
    }
}
