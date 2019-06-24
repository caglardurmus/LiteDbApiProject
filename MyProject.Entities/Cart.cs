﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProject.Entities
{
    public class Cart
    {
        public Cart()
        {
            CartLines = new List<CartLine>();
        }
        public List<CartLine> CartLines { get; set; }
        public decimal Total
        {
            get { return CartLines.Sum(c => c.Product.Price * c.Quantity); }
        }
    }
}
