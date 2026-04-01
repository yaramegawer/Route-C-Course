using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Online_Store_Order_Processing.Models
{
    public class ProductRepository
    {
        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
                new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
                new Product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
                new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
                new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
                new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
                new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
                new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
                new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
                new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 15 }
            };
        }

        public List<Product> SearchProducts(List<Product> products, Func<Product, bool> condition)
        {
            var result = new List<Product>();

            foreach (var product in products)
            {
                if (condition(product))
                {
                    result.Add(product);
                }
            }

            return result;
        }

        public static void PrintProducts(string title, List<Product> products)
        {
            Console.WriteLine($"--- {title} ---");
            foreach (var p in products)
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            Console.WriteLine();
        }

        public static void PrintReport(List<Product> products, string action)
        {
            foreach (var product in products)
            {
                if (action == "Short")
                {
                    Console.WriteLine($" {product.Name} - ${product.Price} ");

                }
                else if (action == "Detailed")
                {
                    Console.WriteLine($"[{product.Category}] {product.Name} | Price: ${product.Price} | Stock: {product.Stock} ");
                }
            }
        }

        public List<TResult> TransformProducts<TResult>(List<Product> products, Func<Product, TResult> transformer)
        {
            var result = new List<TResult>();

            foreach (var product in products)
            {
                result.Add(transformer(product));
            }

            return result;
        }

        public List<Product> FilterProducts(List<Product> products, Predicate<Product> condition)
        {
            var result = new List<Product>();
            foreach (var product in products)
            {
                if (condition(product)) // check the predicate
                    result.Add(product);
            }
            return result;
        }
    }
}
