namespace ProjectDotNet.Models
{
    public class ProductViewModel
    {
        public Products Product { get; set; }
        public ICollection<Products> Recommendations { get; set; }
    }
}
