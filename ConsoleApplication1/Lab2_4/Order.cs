using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Product> Products { get; set; }
    }
}