namespace assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q1 - Casting double to int
            double d = 9.99;
            int x1 = (int)d; // truncates decimal
            Console.WriteLine("Q1: " + x1); // Output: 9
            #endregion

            #region Q2 - Fix integer division
            int n = 5;
            double d2 = n / 2.0; // ensure double division
            Console.WriteLine("Q2: " + d2); // Output: 2.5
            #endregion

            #region Q3 - Read int from user
            // Console.Write("Enter your age: ");
            // int age = int.Parse(Console.ReadLine()!); // unsafe if invalid input
            // Console.WriteLine("Q3: " + age);
            #endregion

            #region Q4 - int.Parse exception
            string s4 = "12a";
            // int x4 = int.Parse(s4); // throws FormatException
            #endregion

            #region Q5 - Safe parsing
            string s5 = "12a";
            if (int.TryParse(s5, out int x5))
                Console.WriteLine("Q5: " + x5);
            else
                Console.WriteLine("Q5: Invalid"); // Output: Invalid
            #endregion

            #region Q6 - Object to int unboxing
            object o6 = 10;
            int a6 = (int)o6; // unboxing works
            Console.WriteLine("Q6: " + (a6 + 1)); // Output: 11
            #endregion

            #region Q7 - Object to long unboxing problem
            object o7 = 10;
            // long x7 = (long)o7; // InvalidCastException
            long x7_fixed = (int)o7; // unbox as int, convert to long
            Console.WriteLine("Q7: " + x7_fixed); // Output: 10
            #endregion

            #region Q8 - Safe object to long
            object o8 = 10;
            long x8 = o8 is int i8 ? i8 : -1;
            Console.WriteLine("Q8: " + x8); // Output: 10
            #endregion

            #region Q9 - Null-conditional
            string? name9 = null;
            Console.WriteLine("Q9: " + name9?.Length); // Output: blank
            #endregion

            #region Q10 - Null-coalescing with length
            string? name10 = null;
            int length10 = name10?.Length ?? 0;
            Console.WriteLine("Q10: " + length10); // Output: 0
            #endregion

            #region Q11 - Safe parsing with ?? operator
            string? s11 = null;
            int x11 = int.Parse(s11 ?? "0");
            Console.WriteLine("Q11: " + x11); // Output: 0
            #endregion

            #region Q12 - Null-forgiving operator problem
            string? s12 = null;
            // Console.WriteLine(s12!.Length); // NullReferenceException
            Console.WriteLine("Q12: " + (s12?.Length ?? -1)); // Output: -1
            #endregion

            #region Q13 - Convert.ToInt32 with null
            string? s13 = null;
            int x13 = Convert.ToInt32(s13);
            Console.WriteLine("Q13: " + x13); // Output: 0
            #endregion

            #region Q14 - int.Parse vs Convert.ToInt32
            string? s14 = null;
            // int a14 = int.Parse(s14); // throws FormatException
            int b14 = Convert.ToInt32(s14); // returns 0
            Console.WriteLine("Q14: " + b14); // Output: 0
            #endregion

            #region Q15 - Print Guest if null, else uppercase
            string? user15 = null;
            Console.WriteLine("Q15: " + (user15?.ToUpper() ?? "Guest")); // Output: Guest
            #endregion
        
    }
    }
}
