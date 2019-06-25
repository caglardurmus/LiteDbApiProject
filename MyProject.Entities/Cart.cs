using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProject.Entities
{
    public class Cart : IEntity
    {
        public int Id { get; set; }
        public int CartNumber { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
