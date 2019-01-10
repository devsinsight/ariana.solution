﻿using Ariana.ECommerce.Catalog.Domain;
using Ariana.ECommerce.Catalog.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ariana.ECommerce.Catalog.Api.Seed
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        {
            var context = (CatalogContext)applicationBuilder
                .ApplicationServices.GetService(typeof(CatalogContext));
            using (context)
            {
                context.Database.Migrate();
                if (!context.CatalogBrand.Any())
                {
                    context.CatalogBrand.AddRange(
                        GetPreconfiguredCatalogBrands());
                    await context.SaveChangesAsync();
                }
                if (!context.CatalogType.Any())
                {
                    context.CatalogType.AddRange(
                        GetPreconfiguredCatalogTypes());
                    await context.SaveChangesAsync();
                }
            }
        }

        static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>()
       {
           new CatalogBrand() { Name = "Azure"},
           new CatalogBrand() { Name = ".NET" },
           new CatalogBrand() { Name = "Visual Studio" },
           new CatalogBrand() { Name = "SQL Server" }
       };
        }

        static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new CatalogType() { Name = "Mug"},
                new CatalogType() { Name = "T-Shirt" },
                new CatalogType() { Name = "Backpack" },
                new CatalogType() { Name = "USB Memory Stick" }
            };
        }
    }
}
