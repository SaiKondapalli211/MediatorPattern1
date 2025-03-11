using MediatorPattern1.Mediator;

namespace MediatorPattern1.Service
{
    public class BaseService
    {
        protected readonly IInsuranceMediator _mediator;

        public BaseService(IInsuranceMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
