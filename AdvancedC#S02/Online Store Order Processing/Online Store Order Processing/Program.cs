using Online_Store_Order_Processing.Models;

namespace Online_Store_Order_Processing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task 01 : Smart Product Search

            var repo = new ProductRepository();
            var products = repo.GetProducts();

            //var electronics = repo.SearchProducts(products, p => p.Category == "Electronics");
            //var under50 = repo.SearchProducts(products, p => p.Price < 50);
            //var inStock = repo.SearchProducts(products, p => p.Stock > 0);
            //var clothingUnder100 = repo.SearchProducts(products, p => p.Category == "Clothing" && p.Price < 100);

            //ProductRepository.PrintProducts("Electronics", electronics);
            //ProductRepository.PrintProducts("Under $50", under50);
            //ProductRepository.PrintProducts("In Stock", inStock);
            //ProductRepository.PrintProducts("Clothing Under $100", clothingUnder100);

            #endregion
            #region 3.1  Print Reports 
            //Console.WriteLine("--Short Report--");
            //ProductRepository.PrintReport(products, "Short");
            //Console.WriteLine("--Detailed Report--");
            //ProductRepository.PrintReport(products, "Long");

            #endregion

            #region 3.2. Transform Products 
            //// Scenario 3: Summary List
            //var summaryList = repo.TransformProducts(products, p => $"{p.Name} (${p.Price})");

            //Console.WriteLine("--- Scenario 3: Summary List ---");
            //summaryList.ForEach(Console.WriteLine);

            //// Scenario 4: Price Label
            //var priceLabels = repo.TransformProducts(products, p => p.Price > 100 ? "Expensive!" : "Affordable");

            //Console.WriteLine("--- Scenario 4: Price Labels ---");
            //for (int i = 0; i < products.Count; i++)
            //{
            //    Console.WriteLine($"{products[i].Name}: {priceLabels[i]}");
            //} 
            #endregion

            // Scenario 5: Low-stock alert
            var lowStockProducts = repo.FilterProducts(products, p => p.Stock < 20);

            Console.WriteLine("--- Scenario 5: Low-Stock Alert ---");
            foreach (var p in lowStockProducts)
            {
                Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!");
            }

        }
    }
}
