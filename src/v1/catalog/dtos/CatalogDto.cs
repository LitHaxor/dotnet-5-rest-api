using System;

namespace Catalog.Dtos
{
    public record ItemDto
    {
        public Guid Id { get; init; }

        public string name { get; set; }

        public decimal price { get; set; }

        public DateTimeOffset createdDate { get; init; }

    }
}