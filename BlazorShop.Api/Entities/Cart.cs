namespace BlazorShop.Api.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public ICollection<CartItem> Items { get; set; }
        = new List<CartItem>();
    }
}
