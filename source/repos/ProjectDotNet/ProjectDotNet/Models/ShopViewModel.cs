namespace ProjectDotNet.Models
{
    public class ShopViewModel
    {

        public ICollection<Products> Products { get; set; }
        public ICollection<Categories> Categories { get; set; }

    }
}
