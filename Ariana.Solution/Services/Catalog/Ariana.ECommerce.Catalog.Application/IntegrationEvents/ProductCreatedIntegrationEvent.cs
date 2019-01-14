using Ariana.ECommerce.EventBus.EventBus.Events;

namespace Ariana.ECommerce.Catalog.Application.IntegrationEvents
{
    public class ProductCreatedIntegrationEvent : IntegrationEvent
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ProductCreatedIntegrationEvent(int id, string name, string description, decimal price)
        {
            ProductId = id;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
