namespace assignmentSession5part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region part1
            //int input; 
            //Console.WriteLine("enter a day number (1–7)");
            //if (int.TryParse(Console.ReadLine(), out input) && input >= 0 && input <= 6)
            //{
            //    DayOfWeek day = (DayOfWeek)input;

            //    Console.WriteLine("Day: " + day);

            //    switch (day)
            //    {
            //        case DayOfWeek.Friday:
            //        case DayOfWeek.Saturday:
            //            Console.WriteLine("Weekend");
            //            break;

            //        default:
            //            Console.WriteLine("Workday");
            //            break;
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Invalid input!");
            //} 
            #endregion

            #region Part2Q1
            //int size;

            //Console.WriteLine("Enter array size");
            //size = int.Parse(Console.ReadLine());

            //int[] arr = new int[size];

            //int sum = 0;

            //Console.WriteLine("Enter element [0]");
            //arr[0] = int.Parse(Console.ReadLine());

            //sum = arr[0];
            //int max = arr[0];
            //int min = arr[0];

            //for (int i = 1; i < size; i++)
            //{
            //    Console.WriteLine($"Enter element [{i}]");
            //    arr[i] = int.Parse(Console.ReadLine());

            //    sum += arr[i];

            //    if (arr[i] > max)
            //        max = arr[i];

            //    if (arr[i] < min)
            //        min = arr[i];
            //}

            //double avg = (double)sum / size;

            //Console.WriteLine($"Sum: {sum}");
            //Console.WriteLine($"Average: {avg}");
            //Console.WriteLine($"Max: {max}");
            //Console.WriteLine($"Min: {min}");

            //Console.WriteLine("Reversed array:");

            //for (int i = size - 1; i >= 0; i--)
            //{
            //    Console.WriteLine($"Element [{i}] = {arr[i]}");
            //}

            #endregion

            #region Part2Q2
            //int students = 3;
            //int subjects = 4;

            //double[,] grades = new double[students, subjects];


            //for (int i = 0; i < students; i++)
            //{
            //    Console.WriteLine($"Enter grades for student {i + 1}:");
            //    for (int j = 0; j < subjects; j++)
            //    {
            //        Console.Write($"Subject {j + 1}: ");
            //        grades[i, j] = double.Parse(Console.ReadLine());
            //    }
            //}

            //double totalSum = 0;


            //for (int i = 0; i < students; i++)
            //{
            //    double sum = 0;
            //    for (int j = 0; j < subjects; j++)
            //    {
            //        sum += grades[i, j];
            //    }
            //    double avg = sum / subjects;
            //    Console.WriteLine($"Student {i + 1} average: {avg}");
            //    totalSum += sum;
            //}


            //double classAverage = totalSum / (students * subjects);
            //Console.WriteLine($"Overall class average: {classAverage}");

            #endregion
        }
    }
}
