﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShop.Models
{
    [NotMapped]
    public class CartItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}
