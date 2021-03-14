using System.Collections.Generic;

namespace ComputerShop.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Computer> Computers { get; set; }
    }
}
