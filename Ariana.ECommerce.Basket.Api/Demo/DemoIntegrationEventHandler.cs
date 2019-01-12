using System.Threading.Tasks;
using Ariana.ECommerce.EventBus.EventBus.Abstractions;

namespace Ariana.ECommerce.Basket.Api.Demo
{
    public class DemoIntegrationEventHandler : IIntegrationEventHandler<DemoIntegrationEvent>
    {
        public Task Handle(DemoIntegrationEvent @event)
        {
            //Todo
            return Task.CompletedTask;
        }
    }
}
