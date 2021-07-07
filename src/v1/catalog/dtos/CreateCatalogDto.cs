namespace Catalog.Dtos
{
    public record createItemDto
    {
        public string name { get; init; }

        public decimal price { get; init; }
    }
}