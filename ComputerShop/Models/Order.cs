using ComputerShop.Enums;
using System;
using System.Collections.Generic;

namespace ComputerShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<CartItem> CartItems { get; set; }
        public double Total { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public Status Status { get; set; }
    }
}
