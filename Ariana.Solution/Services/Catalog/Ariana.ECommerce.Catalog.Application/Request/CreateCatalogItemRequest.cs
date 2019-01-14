using Ariana.ECommerce.Catalog.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ariana.ECommerce.Catalog.Application.Request
{
    public class CreateCatalogItemRequest : IRequest
    {
        public CatalogItem CatalogItem { get; set; }
    }
}
