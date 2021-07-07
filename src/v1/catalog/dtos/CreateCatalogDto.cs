using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record createItemDto
    {
        [Required]
        public string name { get; init; }

        [Required]
        [Range(1, 1000)]
        public decimal price { get; init; }
    }
}