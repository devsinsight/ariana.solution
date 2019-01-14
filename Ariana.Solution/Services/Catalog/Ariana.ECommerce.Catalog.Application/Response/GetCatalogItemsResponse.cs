using Ariana.ECommerce.Catalog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ariana.ECommerce.Catalog.Application.Response
{
    public class GetCatalogItemsResponse
    {
        public IEnumerable<CatalogItem> CatalogItems { get; set; }
    }
}
