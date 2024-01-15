using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDotNet.Models
{
    [Table("Accounts")]
    public class Accounts
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Your Name is required")]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Your Email is required")]
        [EmailAddress(ErrorMessage = "Your Email is not valid")]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Your Password is required")]
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }

        public ICollection<Orders> Orders { get; set; }
 
    }
}
