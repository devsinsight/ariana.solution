using Ariana.ECommerce.Catalog.Application.Request;
using Ariana.ECommerce.Catalog.Domain.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ariana.ECommerce.Catalog.Application.Handler
{
    public class CreateCatalogItemHandler : AsyncRequestHandler<CreateCatalogItemRequest>
    {
        private readonly ICatalogRepository _repository;
        private readonly IUnitOfWork _uof;
        public CreateCatalogItemHandler(ICatalogRepository repository, IUnitOfWork uof) {
            _repository = repository;
            _uof = uof;
        }

        protected override async Task Handle(CreateCatalogItemRequest request, CancellationToken cancellationToken)
        {
            await _repository.Create(request.CatalogItem);

            await _uof.CommitAsync();

        }
    }
}
