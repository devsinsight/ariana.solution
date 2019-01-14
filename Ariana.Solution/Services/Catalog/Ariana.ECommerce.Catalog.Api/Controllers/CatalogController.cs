using Ariana.ECommerce.Catalog.Api.Models;
using Ariana.ECommerce.Catalog.Application.Request;
using Ariana.ECommerce.Catalog.Domain;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ariana.ECommerce.Catalog.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class CatalogController : Controller
    {
        private readonly IMediator _mediator;

        public CatalogController(IMediator mediator) {
            _mediator = mediator;
        }

        /// <summary>
        /// Get a list of Catalog Items.
        /// </summary>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="200">Success Return</response>
        /// <response code="400">Unexpected Error</response>            
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() {

            var catalogItems = await _mediator.Send(new GetCatalogItemsRequest());

            return Json(catalogItems);
        }

        /// <summary>
        /// Creates a Catalog Item.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="200">Success Created</response>
        /// <response code="400">Unexpected Error</response>            
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CatalogItemModel model)
        {
            var request = new CreateCatalogItemRequest
            {
                CatalogItem = Mapper.Map<CatalogItem>(model)
            };

            await _mediator.Send(request);

            return Json(new { Success = true });
        }

    }
}