using Ariana.ECommerce.EventBus.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ariana.ECommerce.Basket.Api.Demo
{
    public class DemoIntegrationEvent : IntegrationEvent
    {
        public int MagicNumber { get; set; }
    }
}
