using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectDotNet.Models
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Products Product { get; set; }

        public int OrderId { get; set; }
        public Orders Order { get; set; }
    }
}
