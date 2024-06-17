using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vintage.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoriaId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }
    }
}
