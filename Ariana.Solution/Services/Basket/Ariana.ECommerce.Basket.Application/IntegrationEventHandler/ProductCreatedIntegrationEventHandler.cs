using Ariana.ECommerce.Basket.Application.IntegrationEvents;
using Ariana.ECommerce.EventBus.EventBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ariana.ECommerce.Basket.Application.IntegrationEventHandler
{
    public class ProductCreatedIntegrationEventHandler : IIntegrationEventHandler<ProductCreatedIntegrationEvent>
    {
        public Task Handle(ProductCreatedIntegrationEvent @event)
        {
            //Do something

            return Task.CompletedTask;
        }
    }
}
