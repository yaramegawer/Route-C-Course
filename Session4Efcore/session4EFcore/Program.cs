using session4EFcore;

namespace session4EFcore
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BankService service = new();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("===== Bank Management System =====");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Open Account");
                Console.WriteLine("3. Update Account Status");
                Console.WriteLine("4. Remove Account From Customer");
                Console.WriteLine("5. List Customers");
                Console.WriteLine("0. Exit");

                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        service.AddCustomer();
                        break;

                    case "2":
                        service.OpenAccount();
                        break;

                    case "3":
                        service.UpdateAccountStatus();
                        break;

                    case "4":
                        service.RemoveAccountFromCustomer();
                        break;

                    case "5":
                        service.ListCustomers();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
