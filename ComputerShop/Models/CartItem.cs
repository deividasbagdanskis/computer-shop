namespace ComputerShop.Models
{
    public class CartItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
