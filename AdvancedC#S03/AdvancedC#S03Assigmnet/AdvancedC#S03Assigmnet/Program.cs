namespace AdvancedC_S03Assigmnet
{
    internal class Program
    {
        static void Main()
        {
            Exercise1();
            Exercise2();
            Exercise3();
            Exercise4();
            Exercise5();
            Exercise6();
        }

        // =========================
        // Exercise 1
        // =========================
        static void Exercise1()
        {
            Console.WriteLine("\n=== Exercise 1: Student Grades ===");

            List<int> grades = new List<int> { 85, 92, 78, 95, 88, 70, 100, 65 };

            Console.WriteLine("Grades: " + string.Join(", ", grades));
            Console.WriteLine($"Count: {grades.Count}");
            Console.WriteLine($"First: {grades.First()}");
            Console.WriteLine($"Last: {grades.Last()}");

            grades.Sort();
            Console.WriteLine("Sorted: " + string.Join(", ", grades));

            var above90 = grades.FirstOrDefault(g => g > 90);
            Console.WriteLine($"First > 90: {above90}");

            var failing = grades.Where(g => g < 75).ToList();
            Console.WriteLine("Failing: " + string.Join(", ", failing));

            grades.RemoveAll(g => g < 75);
            Console.WriteLine("After Remove: " + string.Join(", ", grades));

            Console.WriteLine($"Has 100? {grades.Any(g => g == 100)}");

            var gradeStrings = grades.Select(g => $"Grade: {g}").ToList();
            Console.WriteLine(string.Join(", ", gradeStrings));
        }

        // =========================
        // Exercise 2
        // =========================
        static void Exercise2()
        {
            Console.WriteLine("\n=== Exercise 2: Leaderboard ===");

            SortedDictionary<int, string> leaderboard = new SortedDictionary<int, string>
        {
            {500, "Ahmed"},
            {200, "Sara"},
            {800, "Ali"},
            {350, "Mona"}
        };

            foreach (var entry in leaderboard)
                Console.WriteLine($"{entry.Key} = {entry.Value}");

            Console.WriteLine($"First Key: {leaderboard.First().Key}");
            Console.WriteLine($"First Value: {leaderboard.First().Value}");

            Console.WriteLine($"Contains 500? {leaderboard.ContainsKey(500)}");

            if (leaderboard.TryGetValue(999, out string player))
                Console.WriteLine(player);
            else
                Console.WriteLine("Score 999 not found");

            leaderboard.Remove(200);

            Console.WriteLine("After removal:");
            foreach (var entry in leaderboard)
                Console.WriteLine($"{entry.Key} = {entry.Value}");
        }

        // =========================
        // Exercise 3
        // =========================
        static void Exercise3()
        {
            Console.WriteLine("\n=== Exercise 3: Phone Book ===");

            Dictionary<string, string> phoneBook = new Dictionary<string, string>
        {
            {"Ahmed", "010"},
            {"Sara", "011"},
            {"Ali", "012"},
            {"Mona", "015"}
        };

            phoneBook["Yara"] = "099";

            try
            {
                phoneBook.Add("Ahmed", "000");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            bool added = phoneBook.TryAdd("Ahmed", "000");
            Console.WriteLine($"TryAdd success? {added}");

            Console.WriteLine($"Contains Omar? {phoneBook.ContainsKey("Omar")}");

            if (phoneBook.TryGetValue("Omar", out string number))
                Console.WriteLine(number);
            else
                Console.WriteLine("Not Found");

            Console.WriteLine("Keys: " + string.Join(", ", phoneBook.Keys));
            Console.WriteLine("Values: " + string.Join(", ", phoneBook.Values));
        }

        // =========================
        // Exercise 4
        // =========================
        static void Exercise4()
        {
            Console.WriteLine("\n=== Exercise 4: HashSet ===");

            HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "ahmed@test.com",
            "AHMED@test.com",
            "sara@test.com",
            "Sara@Test.Com"
        };

            Console.WriteLine($"Count: {emails.Count}");

            HashSet<int> A = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<int> B = new HashSet<int> { 4, 5, 6, 7, 8 };

            var union = new HashSet<int>(A);
            union.UnionWith(B);
            Console.WriteLine("Union: " + string.Join(", ", union));

            var intersect = new HashSet<int>(A);
            intersect.IntersectWith(B);
            Console.WriteLine("Intersect: " + string.Join(", ", intersect));

            var except = new HashSet<int>(A);
            except.ExceptWith(B);
            Console.WriteLine("Except: " + string.Join(", ", except));

            var smallSet = new HashSet<int> { 1, 2 };
            Console.WriteLine($"Is subset? {smallSet.IsSubsetOf(A)}");
        }

        // =========================
        // Exercise 5
        // =========================
        static void Exercise5()
        {
            Console.WriteLine("\n=== Exercise 5: Queue ===");

            Queue<string> queue = new Queue<string>();

            queue.Enqueue("Report.pdf");
            queue.Enqueue("Invoice.pdf");
            queue.Enqueue("Letter.docx");
            queue.Enqueue("Resume.pdf");
            queue.Enqueue("Photo.jpg");

            Console.WriteLine("Queue: " + string.Join(", ", queue));
            Console.WriteLine($"Count: {queue.Count}");

            Console.WriteLine($"Next: {queue.Peek()}");

            while (queue.Count > 0)
            {
                Console.WriteLine("Printing: " + queue.Dequeue());
            }

            if (queue.TryDequeue(out string doc))
                Console.WriteLine(doc);
            else
                Console.WriteLine("Queue is empty");
        }

        // =========================
        // Exercise 6
        // =========================
        static void Exercise6()
        {
            Console.WriteLine("\n=== Exercise 6: Stack ===");

            Stack<string> history = new Stack<string>();

            history.Push("google.com");
            history.Push("github.com");
            history.Push("stackoverflow.com");
            history.Push("youtube.com");
            history.Push("claude.ai");

            Console.WriteLine($"Current: {history.Peek()}");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Leaving: " + history.Pop());
            }

            Console.WriteLine($"Now at: {history.Peek()}");

            history.Clear();

            if (history.TryPop(out string page))
                Console.WriteLine(page);
            else
                Console.WriteLine("History is empty");
        }
    }
}
