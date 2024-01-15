using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDotNet.Models
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Product name is required")]

        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(999)")]
        public string Image { get; set; }

        [Column(TypeName = "float")]
        public float Price { get; set; }

        [Column(TypeName = "tinyint")]
        public byte Status { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
        public Categories Category { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
