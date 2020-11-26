namespace ComputerShop.Stock.Api.Models
{
    public class StockItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AmountInStock { get; set; }
    }
}
