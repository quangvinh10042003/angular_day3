namespace ProjectDotNet.Models
{
    public class HomeViewModel
    {
        public ICollection<Products> Products { get; set; }
        public ICollection<Products> GucciProducts { get; set; }
        public ICollection<Products> ChannelProducts { get; set; }
        public ICollection<Products> DiorProducts { get; set; }
    }
}
