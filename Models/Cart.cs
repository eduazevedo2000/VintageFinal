using System.ComponentModel.DataAnnotations;

namespace Vintage.Models
{
    public class Cart
    {
        [Key]
        public int CartItemId { get; set; }
        public string UserId { get; set;}
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
