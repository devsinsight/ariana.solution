using Ariana.ECommerce.EventBus.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ariana.ECommerce.Catalog.Application.IntegrationEvents
{
    public class DemoIntegrationEvent : IntegrationEvent
    {
        public int MagicNumber { get; set; }
    }
}
