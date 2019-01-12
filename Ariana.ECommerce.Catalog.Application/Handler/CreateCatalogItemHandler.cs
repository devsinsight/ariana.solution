using Ariana.ECommerce.Catalog.Application.IntegrationEvents;
using Ariana.ECommerce.Catalog.Application.Request;
using Ariana.ECommerce.Catalog.Domain.Repository;
using Ariana.ECommerce.EventBus.EventBus.Abstractions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ariana.ECommerce.Catalog.Application.Handler
{
    public class CreateCatalogItemHandler : AsyncRequestHandler<CreateCatalogItemRequest>
    {
        private readonly ICatalogRepository _repository;
        private readonly IUnitOfWork _uof;
        private readonly IEventBus _eventBus;

        public CreateCatalogItemHandler(ICatalogRepository repository, IUnitOfWork uof, IEventBus eventBus) {
            _repository = repository;
            _uof = uof;
            _eventBus = eventBus;
        }

        protected override async Task Handle(CreateCatalogItemRequest request, CancellationToken cancellationToken)
        {
            await _repository.Create(request.CatalogItem);

            await _uof.CommitAsync();

            _eventBus.Publish(new DemoIntegrationEvent() { MagicNumber = 777 });
        }
    }
}
