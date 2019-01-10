using Ariana.ECommerce.Catalog.Api.Models;
using Ariana.ECommerce.Catalog.Domain;
using AutoMapper;

namespace Ariana.ECommerce.Catalog.Api.Mappings
{
    public class CatalogMappingProfile : Profile
    {

        public CatalogMappingProfile()
        {
            CreateMap<CatalogItemModel, CatalogItem>();
        }
    }
        
}
