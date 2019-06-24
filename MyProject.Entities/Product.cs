using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
