using System;

namespace Catalog.Entities
{
    public record Item
    {
        public Guid Id { get; init; }

        public string name { get; set; }

        public decimal price { get; set; }

        public DateTimeOffset createdDate { get; init; }

    }
}