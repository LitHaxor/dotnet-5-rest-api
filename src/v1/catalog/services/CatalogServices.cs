using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Entities;


namespace Catalog.Services
{

    class CatalogServices : ICatalogServices
    {
        private readonly List<Item> items = new()
        {
            new Item
            {
                Id = Guid.NewGuid(),
                name = "Test 1",
                price = 10,
                createdDate = DateTimeOffset.UtcNow
            },
            new Item
            {
                Id = Guid.NewGuid(),
                name = "Test 2",
                price = 10,
                createdDate = DateTimeOffset.UtcNow
            },
            new Item
            {
                Id = Guid.NewGuid(),
                name = "Test 3",
                price = 2,
                createdDate = DateTimeOffset.UtcNow
            },
            new Item
            {
                Id = Guid.NewGuid(),
                name = "Test 4",
                price = 3,
                createdDate = DateTimeOffset.UtcNow
            },
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(this.items);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            return await Task.FromResult(this.items.Where(item => item.Id == id).SingleOrDefault());
        }

        public async Task CreateItemAsync(Item item)
        {
            this.items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            var index = items.FindIndex(e => e.Id == item.Id);
            this.items[index] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var index = this.items.FindIndex(e => e.Id == id);
            this.items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}