using Ariana.ECommerce.Catalog.Domain.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ariana.ECommerce.Catalog.Domain
{
    [Table("CatalogBrand")]
    public class CatalogBrand
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
