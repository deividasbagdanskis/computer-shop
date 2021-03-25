namespace ComputerShop.Models
{
    public class Computer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double? ScreenSize { get; set; }
        public string ScreenType { get; set; }
        public string CPU { get; set; }
        public int Cores { get; set; }
        public double ClockSpeed { get; set; }
        public int RAM { get; set; }
        public int Storage { get; set; }
        public string GPU { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
