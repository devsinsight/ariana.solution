using Ariana.ECommerce.EventBus.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ariana.ECommerce.Basket.Application.IntegrationEvents
{
    public class ProductCreatedIntegrationEvent : IntegrationEvent
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
