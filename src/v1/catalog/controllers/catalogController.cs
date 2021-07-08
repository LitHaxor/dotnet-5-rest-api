using System;
using Microsoft.AspNetCore.Mvc;
using Catalog.Services;
using System.Collections.Generic;
using Catalog.Entities;
using System.Linq;
using Catalog.Dtos;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            var items = (await this.catalogServices.GetItemsAsync()).Select(item => item.AsDto());
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
        {
            var item = await this.catalogServices.GetItemAsync(id);
            return item != null ? item.AsDto() : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(createItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                name = itemDto.name,
                price = itemDto.price,
                createdDate = DateTimeOffset.UtcNow,
            };
            await this.catalogServices.CreateItemAsync(item);

            return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ItemDto>> UpdateItemAsync(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = await this.catalogServices.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with
            {
                name = itemDto.name,
                price = itemDto.price,
            };
            await this.catalogServices.UpdateItemAsync(updatedItem);
            // return NoContent();
            return updatedItem.AsDto();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            var existingItem = await this.catalogServices.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            await this.catalogServices.DeleteItemAsync(existingItem.Id);
            return NoContent();
        }
    }
}