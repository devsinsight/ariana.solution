using Ariana.ECommerce.Catalog.Application.Request;
using Ariana.ECommerce.Catalog.Application.Response;
using Ariana.ECommerce.Catalog.Domain.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ariana.ECommerce.Catalog.Application.Handler
{
    public class GetCatalogItemsHandler : IRequestHandler<GetCatalogItemsRequest, GetCatalogItemsResponse>
    {
        private readonly ICatalogRepository _repository;

        public GetCatalogItemsHandler(ICatalogRepository repository)
        {
            _repository = repository;
        }

        public Task<GetCatalogItemsResponse> Handle(GetCatalogItemsRequest request, CancellationToken cancellationToken)
        {
            var response = new GetCatalogItemsResponse
            {
                CatalogItems = _repository.GetAll()
            };

            return Task.FromResult(response);
        }
    }
}
