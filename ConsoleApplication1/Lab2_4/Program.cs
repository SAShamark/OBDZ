using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Program
    {
        public static void Main()
        {
            var orders = new List<Order>
            {
                new Order { OrderId = 1, OrderDate = DateTime.Today, Products = new List<Product>
                    {
                        new Product { ProductId = 1, Name = "Товар 1", Price = 100 },
                        new Product { ProductId = 2, Name = "Товар 2", Price = 150 }
                    }
                },
                new Order { OrderId = 2, OrderDate = DateTime.Today.AddDays(-1), Products = new List<Product>
                    {
                        new Product { ProductId = 3, Name = "Товар 3", Price = 75 },
                        new Product { ProductId = 4, Name = "Товар 4", Price = 200 }
                    }
                }
            };

            foreach (var order in orders)
            {
                Console.WriteLine($"Замовлення ID: {order.OrderId}, Дата: {order.OrderDate}");
                Console.WriteLine("Товари в замовленні:");
                foreach (var product in order.Products)
                {
                    Console.WriteLine($"- {product.Name}, Ціна: {product.Price:C}");
                }
                Console.WriteLine();
            }
        }
    }
}