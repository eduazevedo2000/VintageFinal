using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vintage.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        public string? ImageUrl { get; set; }

        public string FirstImageUrl
        {
            get
            {
                return ImageUrl?.Split(',').FirstOrDefault();
            }
        }

        public string SecondImageUrl
        {
            get
            {
                return ImageUrl?.Split(',').ElementAtOrDefault(1);
            }
        }

        public string ThirdImageUrl
        {
            get
            {
                return ImageUrl?.Split(',').ElementAtOrDefault(2);
            }
        }
    }
}