using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectDotNet.Models
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "float(11)")]
        public float totalPrice { get; set; }

        [Column(TypeName = "int")]
        public float totalQuantity { get; set; }


        [Column(TypeName = "tinyint")]
        public byte Status { get; set; }

        public int AccountId { get; set; }
        public Accounts Account { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
