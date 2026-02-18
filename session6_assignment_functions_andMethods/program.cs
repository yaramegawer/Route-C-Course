using static System.Runtime.InteropServices.JavaScript.JSType;

namespace assigmnet_session6_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 3: Functions (Methods)
            #region Q1: Basic Calculator Functions

            //Console.WriteLine("Please enter two numbers");
            //Console.Write("Number 1: ");
            //double num1 = Convert.ToDouble(Console.ReadLine());
            //Console.Write("Number 2: ");
            //double num2 = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine("Please enter the operation +,-,/,*");
            //string operation = Console.ReadLine();

            //double result = 0;
            //switch (operation)
            //{
            //    case "+":
            //        result = Add(num1, num2);
            //        break;
            //    case "-":
            //        result = Subtract(num1, num2);
            //        break;
            //    case "*":
            //        result = Multiply(num1, num2);
            //        break;
            //    case "/":
            //        if (num2 == 0)
            //        {
            //            Console.WriteLine("Cannot divide by zero.");
            //            return;
            //        }
            //        result = Divide(num1, num2);
            //        break;
            //    default:
            //        Console.WriteLine("Invalid operation.");
            //        return;
            //}
            //Console.WriteLine(result);


            #endregion

            #region Q2: Circle calculator
            //Console.WriteLine("Please enter the radius of the circle:");
            //double radius = Convert.ToDouble(Console.ReadLine());
            //CalculateArea(radius, out double area, out double circumference);
            //Console.WriteLine($"area {area} ,circumference:{circumference}");
            #endregion
            #endregion


            int[] arr = new int[5];

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter score for student {i + 1}: ");
                arr[i] = Convert.ToInt32(Console.ReadLine());


            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Student {i + 1}: {arr[i]} -> Grade: {GetGrade(arr[i])}");
            }

            Console.WriteLine($"Average: {CalculateAverage(arr)}");

            GetMinMax(arr, out int min, out int max);

            Console.WriteLine($"Min: {min}, Max: {max}"); 


        }

        static double Add(double a, double b)
        {
            return a + b;
        }

        static double Subtract(double a, double b)
        {
            return a - b;
        }

        static double Multiply(double a, double b)
        {
            return a * b;
        }

        static double Divide(double a, double b)
        {


            return a / b;

        }

        static void CalculateArea(double radius, out double area, out double circumference)
        {
            area = Math.PI * radius * radius;
            circumference = 2 * Math.PI * radius;
            
        }

        static Grade GetGrade(int score)
        {
            if (score >= 90)
                return Grade.A;
            else if (score >= 80)
                return Grade.B;
            else if (score >= 70)
                return Grade.C;
            else if (score >= 60)
                return Grade.D;
            else
                return Grade.F;
        }

        static double CalculateAverage(int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            return (double)sum / numbers.Length;
        }

        static void GetMinMax(int[] numbers, out int min, out int max)
        {
            min = numbers[0];
            max = numbers[0];
            foreach (int num in numbers)
            {
                if (num < min)
                    min = num;
                if (num > max)
                    max = num;
            }
             

        }
    }
}

