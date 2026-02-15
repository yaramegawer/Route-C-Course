using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Intrinsics.X86;
using System.Text;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignmnet_session4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Q1

            //Question 01 : A junior developer wrote this code to build a comma - separated list of 5,000 product IDs:

            //Tasks:
            //(a)Explain why this code is inefficient.Reference what happens in memory.

            //Answer: This code is inefficient because strings in C# are immutable
            //, meaning that every time you concatenate a new string using the += operator,
            //a new string object is created in memory. This results in multiple allocations a
            //nd deallocations of memory as the loop iterates, leading to increased memory usage and
            //slower performance. As the number of iterations increases, the time taken to concatenate
            //strings grows exponentially, making it inefficient for large numbers of product IDs.
            //(b) Rewrite this code using StringBuilder to be more efficient.
            //StringBuilder productList = new StringBuilder();
            //for (int i = 1; i <= 5000; i++)
            //{
            //    productList += "prod-"+i+",";
            //}
            //(c) Add timing code(using Stopwatch) to both versions and report the time difference.
            // Timing the original code
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //string productListOriginal = "";
            //for (int i = 1; i <= 5000; i++)
            //{
            //    productListOriginal += "prod-" + i + ",";
            //}
            //stopwatch.Stop();
            //Console.WriteLine("Time taken for original code: " + stopwatch.ElapsedMilliseconds + " ms");


            //// Timing the StringBuilder code
            //stopwatch.Restart();
            //StringBuilder productList = new StringBuilder();
            //for (int i = 1; i <= 5000; i++)
            //{
            //    productList.Append("prod-");
            //    productList.Append(i);
            //    productList.Append(",");
            //}
            //stopwatch.Stop();
            //Console.WriteLine("Time taken for stringbuilder code: " + stopwatch.ElapsedMilliseconds + " ms");

            #endregion

            #region Q2
            //int age;
            //int dayOfWeek;
            //bool hasStudentID;
            //Console.WriteLine("Enter your age:");
            //age = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter the day of the week (1-7, where 6 = Fri, 7 = Sat):");
            //dayOfWeek = int.Parse(Console.ReadLine());
            //Console.WriteLine("Do you have a student ID? (yes/no):");
            //hasStudentID = Console.ReadLine().ToLower() == "yes";

            //int price = 0;
            //if (age < 5)
            //{
            //    price = 0;
            //}
            //else if (age >= 5 && age <= 12)
            //{
            //    price = 30;
            //}
            //else if (age >= 13 && age <= 59)
            //{
            //    price = 50;
            //}
            //else
            //{
            //    price = 25;
            //}
            //if (dayOfWeek == 6 || dayOfWeek == 7)
            //{
            //    price += 10;
            //}
            //if (hasStudentID)
            //{
            //    price = (int)(price * 0.8);
            //}



            //            (b) The program should ask for: age, day of week(1 - 7, where 6 = Fri, 7 = Sat), and whether they have a student ID(yes / no)
            //            (c) Display the final price with a breakdown of how it was calculated
            //Answer:It was calculated based on the age of the customer, the day of the week, and whether they have a student ID.
            //The base price is determined by the age group, with children under 5 being free, children between 5 and 12 costing $30,
            //adults between 13 and 59 costing $50, and seniors 60 and above costing $25. If the visit is on a weekend (Friday or Saturday),
            //an additional $10 is added to the price. Finally, if the customer has a student ID, they receive a 20% discount on the total price.

            //Console.WriteLine($"The ticket price is {price}");

            #endregion

            #region Q3
            //(a)A traditional switch statement
            // string fileExtension = ".gzif";
            //string fileType;

            //switch (fileExtension)
            //{
            //    case ".pdf":
            //        fileType = "pdf";
            //        break;
            //    case ".docx" or ".doc":
            //        fileType = "word document";
            //        break;
            //    case ".xlsx" or "xls":
            //        fileType = "Excel SpreadSheet";
            //        break;
            //    case ".png" or ".gif" or ".jif":
            //        fileType = "Image type";
            //        break;
            //    default:
            //        fileType = "Unkown file type";
            //        break;
            //}

            //Console.WriteLine($"File type is :{fileType}");


            //(b) A switch expression
            //string fileType = fileExtension switch
            //{
            //    ".pdf" => "pdf",
            //    ".docx" or ".doc" => "word document",
            //    ".xlsx" or "xls" => "Excel SpreadSheet",
            //    ".png" or ".gif" or ".jif" => "Image type",
            //    _ => "Unkown file type"
            //};
            //Console.WriteLine("File Type is:"+fileType);

            #endregion

            #region Q4

            //Rewrite the following using only ternary operators(no if statements):

            //int temp = 25;

            //string weatherAdvice= temp<0?"Freezing":temp<15?"Cold":temp<25?"Pleasent":temp<35?"Warm":"Hot";

            //Console.WriteLine(weatherAdvice);

            //Then answer: Is the ternary version more readable? When would you choose one over the other?
            //Answer: No the normal if condition is more readable ,I would choose ternary condition if there is only one condition (not nested)
            //but if the condition is nested i would choose if condition instead to be more readable

            #endregion

            #region Q5
            //Create a password validation program with these requirements:
            //Password Rules:
            //Minimum 8 characters
            //At least one uppercase letter
            //At least one digit
            //No spaces allowed
            //Program Behavior:
            //            Use a do -while loop to keep asking until a valid password is entered
            //            After each invalid attempt, tell the user which specific rules they violated
            //Limit attempts to 5.After 5 failed attempts, display "Account locked" and exit
            //On success, display "Password accepted!"
            //Hint: Use foreach to iterate through characters and check conditions.

            //    int attempts = 0;
            //    bool isValid = false;

            //    do
            //    {
            //        Console.Write("Enter your password: ");
            //        string password = Console.ReadLine();

            //        bool hasMinLength = password.Length >= 8;
            //        bool hasUppercase = false;
            //        bool hasDigit = false;
            //        bool hasNoSpaces = !password.Contains(" ");

            //        // Check characters using foreach
            //        foreach (char c in password)
            //        {
            //            if (char.IsUpper(c))
            //                hasUppercase = true;

            //            if (char.IsDigit(c))
            //                hasDigit = true;
            //        }

            //        // Validate all rules
            //        isValid = hasMinLength && hasUppercase && hasDigit && hasNoSpaces;

            //        if (!isValid)
            //        {
            //            Console.WriteLine("Invalid password. Issues:");

            //            if (!hasMinLength)
            //                Console.WriteLine("- Must be at least 8 characters.");

            //            if (!hasUppercase)
            //                Console.WriteLine("- Must contain at least one uppercase letter.");

            //            if (!hasDigit)
            //                Console.WriteLine("- Must contain at least one digit.");

            //            if (!hasNoSpaces)
            //                Console.WriteLine("- Must not contain spaces.");

            //            attempts++;
            //            Console.WriteLine($"Attempts left: {5 - attempts}");
            //            Console.WriteLine();
            //        }

            //    } while (!isValid && attempts < 5);

            //    if (isValid)
            //        Console.WriteLine("Password accepted!");
            //    else
            //        Console.WriteLine("Account locked."); 
            #endregion

            #region Q6

            //int[] scores = { 95, 82, 47, 60, 39, 74, 91, 88, 53, 67, 29, 100, 45 };

            //// (a) Find and display all failing scores (below 50)
            //Console.WriteLine("Failing Scores (below 50):");
            //foreach (int score in scores)
            //{
            //    if (score < 50)
            //        Console.WriteLine(score);
            //}

            //Console.WriteLine();

            //// (b) Find first score above 90 and stop searching
            //Console.WriteLine("First score above 90:");
            //foreach (int score in scores)
            //{
            //    if (score > 90)
            //    {
            //        Console.WriteLine(score);
            //        break; // stop immediately
            //    }
            //}

            //Console.WriteLine();

            //// (c) Calculate class average excluding scores below 40
            //int sum = 0;
            //int count = 0;

            //foreach (int score in scores)
            //{
            //    if (score >= 40) // exclude absent students
            //    {
            //        sum += score;
            //        count++;
            //    }
            //}

            //double average = count > 0 ? (double)sum / count : 0;
            //Console.WriteLine($"Class average (excluding below 40): {average:F2}");

            //Console.WriteLine();

            //// (d) Count students in each grade range
            //int gradeA = 0, gradeB = 0, gradeC = 0, gradeD = 0, gradeF = 0;

            //foreach (int score in scores)
            //{
            //    if (score >= 90 && score <= 100)
            //        gradeA++;
            //    else if (score >= 80)
            //        gradeB++;
            //    else if (score >= 70)
            //        gradeC++;
            //    else if (score >= 60)
            //        gradeD++;
            //    else
            //        gradeF++;
            //}

            //Console.WriteLine("Grade Distribution:");
            //Console.WriteLine($"A (90-100): {gradeA}");
            //Console.WriteLine($"B (80-89): {gradeB}");
            //Console.WriteLine($"C (70-79): {gradeC}");
            //Console.WriteLine($"D (60-69): {gradeD}");
            //Console.WriteLine($"F (Below 60): {gradeF}");


            #endregion        
            }
        }
}
