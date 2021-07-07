using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog
{
    public static class CatalogExtensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                name = item.name,
                price = item.price,
                createdDate = item.createdDate,
            };
        }
    }
}