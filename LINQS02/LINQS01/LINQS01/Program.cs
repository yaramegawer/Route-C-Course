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
    new Order { OrderID = 1, CustomerID = "ALFKI", OrderDate = new DateTime(1996, 7, 4), Total=200 },
    new Order { OrderID = 2, CustomerID = "ANATR", OrderDate = new DateTime(1997, 8, 25) ,Total=400},
    new Order { OrderID = 3, CustomerID = "ANTON", OrderDate = new DateTime(1998, 3, 10),Total=600 }
};

            List<Customer> customers = new List<Customer>
{
    new Customer
    {
        CustomerID = "ALFKI",
        CompanyName = "Alfreds Futterkiste",
        Country = "Germany"
    },
    new Customer
    {
        CustomerID = "ANATR",
        CompanyName = "Ana Trujillo Emparedados",
        Country = "Mexico"
    },
    new Customer
    {
        CustomerID = "ANTON",
        CompanyName = "Antonio Moreno Taquería",
        Country = "Mexico"
    },
    new Customer
    {
        CustomerID = "BERGS",
        CompanyName = "Berglunds snabbköp",
        Country = "Sweden"
    }
};
            #region Question 1 - Top 3 most expensive ProductList
            var top3 = ProductList
                .OrderByDescending(p => p.UnitPrice)
                .Take(3);
            #endregion

            #region Question 2 - Page 2 (page size = 5)
            var page2 = ProductList
                .Skip(5)
                .Take(5);
            #endregion

            #region Question 3 - Take while price < 25
            var cheapProducts = ProductList
                .OrderBy(p => p.UnitPrice)
                .TakeWhile(p => p.UnitPrice < 25);
            #endregion

            #region Question 4 - Check ALL Seafood in stock
            bool allSeafoodInStock = ProductList
                .Where(p => p.Category == "Seafood")
                .All(p => p.UnitsInStock > 0);
            #endregion

            #region Question 5 - Check if IDs contain 9
            int[] ids = { 3, 9, 13, 18 };
            bool contains9 = ids.Contains(9);
            #endregion

            #region Question 6 - Group by Category + count
            var grouped = ProductList.GroupBy(p => p.Category);

            foreach (var group in grouped)
            {
                Console.WriteLine($"{group.Key} - Count: {group.Count()}");
            }
            #endregion

            #region Question 7 - Group by Category (only names)
            var groupedNames = ProductList
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Names = g.Select(p => p.ProductName)
                });
            #endregion

            #region Question 8 - Categories with MORE THAN 3 ProductList
            var categories = ProductList
                .GroupBy(p => p.Category)
                .Where(g => g.Count() > 3)
                .Select(g => g.Key);
            #endregion

            #region Question 9 - QUERY SYNTAX Group customers by Country
            var result =
                from c in customers
                group c by c.Country into g
                select new
                {
                    Country = g.Key,
                    Count = g.Count(),
                    TotalOrderValue = g.Sum(c => c.Orders.Sum(o => o.Total))
                };
            #endregion

            #region Question 10 - Total units in stock
            int totalUnits = ProductList.Sum(p => p.UnitsInStock);
            #endregion

            #region Question 11 - Cheapest & Most Expensive prices
            var minPrice = ProductList.Min(p => p.UnitPrice);
            var maxPrice = ProductList.Max(p => p.UnitPrice);
            #endregion

            #region Question 12 - Distinct categories
            var distinctCategories = ProductList
                .Select(p => p.Category)
                .Distinct();
            #endregion

            #region Question 13 - In setA but NOT in setB
            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
            int[] setB = { 3, 6, 9, 12, 15, 13 };

            var resultSet = setA.Except(setB);
            #endregion

            #region Question 14 - Countries NOT in list2 (case-insensitive)
            string[] list1 = { "Germany", "France", "UK", "Spain" };
            string[] list2 = { "france", "SPAIN", "Italy" };

            var resultCountries = list1
                .Where(c => !list2
                    .Any(x => x.Equals(c, StringComparison.OrdinalIgnoreCase)));
            #endregion

            #region Question 15 - Dictionary + get product ID = 18
            var dict = ProductList.ToDictionary(p => p.ProductID);

            if (dict.TryGetValue(18, out var product))
            {
                Console.WriteLine(product.ProductName);
            }
            #endregion

            #region Question 16 - First product price > 50
            var product50 = ProductList.First(p => p.UnitPrice > 50);
            #endregion

            #region Question 17 - First product price > 500 (safe)
            var product500 = ProductList.FirstOrDefault(p => p.UnitPrice > 500);
            #endregion

            #region Question 18 - Multiplication table row for 7
            var table7 = Enumerable.Range(1, 10)
                .Select(i => 7 * i);
            #endregion

            #region Question 19 - Even numbers between 1 and 30
            var evens = Enumerable.Range(1, 30)
                .Where(n => n % 2 == 0);
            #endregion

            #region Question 20 - Concatenate first 3 ProductList + customers
            var combined = ProductList.Take(3).Select(p => p.ProductName)
                .Concat(customers.Take(3).Select(c => c.CompanyName));
            #endregion

            #region Question 21 - Pair product with customer
            var pairs = ProductList.Zip(customers,
                (p, c) => $"{p.ProductName} sold to {c.CompanyName}");
            #endregion

        }
    }
}
