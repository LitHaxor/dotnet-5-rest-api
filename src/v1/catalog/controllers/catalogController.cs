using System;
using Microsoft.AspNetCore.Mvc;
using Catalog.Services;
using System.Collections.Generic;
using Catalog.Entities;


namespace Catalog.Controllers
{
    [ApiController]
    [Route("v1/items")]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogServices catalogServices;

        public CatalogController(ICatalogServices catalogServices)
        {
            this.catalogServices = catalogServices;
        }


        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return this.catalogServices.GetItems();
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = this.catalogServices.GetItem(id);
            return item != null ? item : NotFound();
        }
    }
}