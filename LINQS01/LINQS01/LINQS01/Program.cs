namespace LINQS01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Product> ProductList = new List<Product>
    {
        new Product { ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18, UnitsInStock = 39 },
        new Product { ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19, UnitsInStock = 17 },
        new Product { ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10, UnitsInStock = 13 },
        new Product { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22, UnitsInStock = 0 },
        new Product { ProductID = 5, ProductName = "Grandma's Boysenberry Spread", Category = "Condiments", UnitPrice = 25, UnitsInStock = 120 },
        new Product { ProductID = 6, ProductName = "Ikura", Category = "Seafood", UnitPrice = 31, UnitsInStock = 20 },
        new Product { ProductID = 7, ProductName = "Konbu", Category = "Seafood", UnitPrice = 6, UnitsInStock = 24 },
        new Product { ProductID = 8, ProductName = "Tofu", Category = "Produce", UnitPrice = 23, UnitsInStock = 35 },
        new Product { ProductID = 9, ProductName = "Cheese", Category = "Dairy", UnitPrice = 15, UnitsInStock = 10 },
        new Product { ProductID = 10, ProductName = "Butter", Category = "Dairy", UnitPrice = 12, UnitsInStock = 0 }
    };


            List<Order> Orders = new List<Order>
{
    new Order { OrderID = 1, CustomerID = "ALFKI", OrderDate = new DateTime(1996, 7, 4) },
    new Order { OrderID = 2, CustomerID = "ANATR", OrderDate = new DateTime(1997, 8, 25) },
    new Order { OrderID = 3, CustomerID = "ANTON", OrderDate = new DateTime(1998, 3, 10) }
};

            #region Q1
            //var seaFood = ProductList.Where(p => p.Category == "Seafood");

            //foreach(var s in seaFood)
            //{
            //    Console.WriteLine($"{ s.ProductName} And { s.UnitPrice}");
            //} 
            #endregion

            #region Q2
            //var names = ProductList.Select(p => p.ProductName);
            //foreach (var n in names)
            //{
            //    Console.WriteLine($"{n}");
            //} 
            #endregion

            #region Q3
            //var sortedProducts=ProductList.OrderBy(p => p.ProductID);
            //foreach (var product in sortedProducts)
            //{
            //    Console.WriteLine($"{product.ProductName} {product.UnitPrice}");

            //} 
            #endregion

            #region Q4
            //var filteredProducts = ProductList
            //.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);

            //        foreach (var p in filteredProducts)
            //        {
            //            Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");
            //        } 
            #endregion

            #region Q5
            //var condimentsInStock = ProductList
            //    .Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");

            //foreach (var p in condimentsInStock)
            //{
            //    Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");
            //} 
            #endregion

            #region Q6
            //var result = ProductList.Select(p => 
            //    new
            //    {
            //        name = p.ProductName,
            //        price = p.UnitPrice,
            //        stock = p.UnitsInStock > 0 ? "Available" : "Out of stock"
            //    }
            //);

            //foreach ( var item in result )
            //{
            //    Console.WriteLine($"{item.name} {item.price} {item.stock}");
            //} 
            #endregion

            #region Q7

            //var result7 = ProductList
            //    .Select((p, index) => new { Index = index + 1, Name = p.ProductName });

            //foreach (var item in result7)
            //{
            //    Console.WriteLine($"{item.Index}. {item.Name}");
            //} 
            #endregion

            #region Q8
            //var sorted = ProductList.OrderBy(p => p.Category)
            //    .ThenByDescending(p => p.UnitPrice);

            //foreach(var product in sorted)
            //{
            //    Console.WriteLine($"{product.Category} {product.UnitPrice}");
            //} 
            #endregion

            #region Q9
            //var products = ProductList.Where(p => p.Category == "Beverages")
            //    .OrderByDescending(p => p.UnitsInStock);

            //foreach(var product in products)
            //{
            //    Console.WriteLine($"{product.ProductName} {product.UnitsInStock}");
            //} 
            #endregion

            #region Q10
            //var result10 =
            //    from o in Orders
            //    from x in new[] { o }
            //    where x.OrderDate.Year >=1997
            //    select new {x.CustomerID, x.OrderDate};

            //foreach (var item in result10)
            //{
            //    Console.WriteLine($"{item.CustomerID} - {item.OrderDate}");
            //} 
            #endregion

            #region Q11
            //var result = ProductList.Select((p, i) => new { position = i, name = p.ProductName });

            //foreach(var p in result)
            //{
            //    Console.WriteLine($"{p.position} {p.name}");
            //} 
            #endregion

            #region Q12
            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            //var result12 = Arr
            //    .OrderBy(w => w.Length)
            //    .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);

            //foreach (var word in result12)
            //{
            //    Console.WriteLine(word);
            //}
            #endregion

            #region Q13
            //string[] digits =
            //    {
            //        "zero","one","two","three","four",
            //        "five","six","seven","eight","nine"
            //    };

            //var result13 = digits
            //    .Where(d => d.Length > 1 && d[1] == 'i')
            //    .Reverse();

            //foreach (var d in result13)
            //{
            //    Console.WriteLine(d);
            //} 
            #endregion
        }
    }
}
