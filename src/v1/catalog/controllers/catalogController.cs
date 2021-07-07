using System;
using Microsoft.AspNetCore.Mvc;
using Catalog.Services;
using System.Collections.Generic;
using Catalog.Entities;
using System.Linq;
using Catalog.Dtos;

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
        public IEnumerable<ItemDto> GetItems()
        {
            var items = this.catalogServices.GetItems().Select(item => item.AsDto());
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = this.catalogServices.GetItem(id);
            return item != null ? item.AsDto() : NotFound();
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(createItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                name = itemDto.name,
                price = itemDto.price,
                createdDate = DateTimeOffset.UtcNow,
            };
            this.catalogServices.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult<ItemDto> UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = this.catalogServices.GetItem(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with
            {
                name = itemDto.name,
                price = itemDto.price,
            };
            this.catalogServices.UpdateItem(updatedItem);
            // return NoContent();
            return updatedItem.AsDto();
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = this.catalogServices.GetItem(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            this.catalogServices.DeleteItem(existingItem.Id);
            return NoContent();
        }
    }
}