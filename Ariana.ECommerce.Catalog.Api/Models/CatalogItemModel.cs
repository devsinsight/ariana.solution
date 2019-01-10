using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ariana.ECommerce.Catalog.Api.Models
{
    public class CatalogItemModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureFileName { get; set; }
        public string PictureUrl { get; set; }
        public int CatalogTypeId { get; set; }
        public int CatalogBrandId { get; set; }
        public int AvailableStock { get; set; }
        public int RestockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }
    }
}
