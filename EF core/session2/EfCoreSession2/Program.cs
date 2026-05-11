namespace EfCoreSession2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new EventHubContext();

            context.Database.EnsureCreated();

            Console.WriteLine("Database Created Successfully!");
        }
    }
}
