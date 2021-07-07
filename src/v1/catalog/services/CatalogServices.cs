using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Item> GetItems()
        {
            return this.items;
        }

        public Item GetItem(Guid id)
        {
            return this.items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            this.items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(e => e.Id == item.Id);
            this.items[index] = item;
        }
    }
}