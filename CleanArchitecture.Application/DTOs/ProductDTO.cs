using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The description is required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "The price is required")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The stock is required")]
        [Range(1, 9999)]
        [DisplayName("Stock")]
        public int Stock { get; set; }
        [MaxLength(250)]
        [DisplayName("Product Image")]
        public string Image { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
    }
}