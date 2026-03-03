using System;

namespace assigmnetOOPS01
{
    #region Part 01 - Q1 Class vs Struct Example

    class Person
    {
        public string Name;
    }

    struct Point
    {
        public int X;
        public int Y;
    }

    #endregion

    #region Part 01 - Q2 Public vs Private Access Modifiers

    class Student
    {
        public string Name;
        private int Grade;

        public void SetGrade(int grade)
        {
            Grade = grade;
        }

        public int GetGrade()
        {
            return Grade;
        }
    }

    #endregion

    #region Part 01 - Q4 Class Library Explanation

    /*
     What is a class library?
     A class library is a separate project that contains reusable classes and logic
     that can be referenced and used in other projects.

     Why do we use it?
     1. Code reuse
     2. Better organization
     3. Separation of concerns
     4. Easier maintenance
    */

    #endregion

    #region Part 02 - Movie Ticket Booking System

    public enum TicketType
    {
        Standard,
        VIP,
        IMAX
    }

    public struct Seat
    {
        public char Row;
        public int Number;

        public Seat(char row, int number)
        {
            Row = row;
            Number = number;
        }

        public override string ToString()
        {
            return $"Row {Row}, Seat {Number}";
        }
    }

    public class Ticket
    {
        #region Ticket Fields & Static Counter
        private static int ticketCounter = 0;
        private string movieName;
        private TicketType type;
        private Seat seat;
        private double price;
        #endregion

        #region Ticket Properties
        public int TicketId { get; private set; }

        public string MovieName
        {
            get => movieName;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    movieName = value;
            }
        }

        public TicketType Type
        {
            get => type;
            set => type = value;
        }

        public Seat Seat
        {
            get => seat;
            set => seat = value;
        }

        public double Price
        {
            get => price;
            set
            {
                if (value > 0)
                    price = value;
            }
        }

        public double PriceAfterTax => Price * 1.14;
        #endregion

        #region Ticket Constructor
        public Ticket(string movieName, TicketType type, Seat seat, double price)
        {
            movieName = !string.IsNullOrWhiteSpace(movieName) ? movieName : "Unknown";
            this.type = type;
            this.seat = seat;
            this.price = price > 0 ? price : 50;

            ticketCounter++;
            TicketId = ticketCounter;
        }
        #endregion

        #region Ticket Static Methods
        public static int GetTotalTicketsSold() => ticketCounter;
        #endregion

        #region Ticket Methods
        public void PrintTicket()
        {
            Console.WriteLine("----- Ticket Info -----");
            Console.WriteLine($"TicketId: {TicketId}");
            Console.WriteLine($"Movie: {MovieName}");
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Seat: {Seat}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Price After Tax: {PriceAfterTax:F2}");
            Console.WriteLine("-----------------------");
        }
        #endregion
    }

    #endregion

    #region Part 03 - Cinema Class

    public class Cinema
    {
        private Ticket[] tickets = new Ticket[20];

        public Ticket this[int index]
        {
            get => (index >= 0 && index < tickets.Length) ? tickets[index] : null;
            set
            {
                if (index >= 0 && index < tickets.Length)
                    tickets[index] = value;
            }
        }

        public Ticket GetMovie(string movieName)
        {
            foreach (var t in tickets)
            {
                if (t != null && t.MovieName.Equals(movieName, StringComparison.OrdinalIgnoreCase))
                    return t;
            }
            return null;
        }

        public bool AddTicket(Ticket t)
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i] == null)
                {
                    tickets[i] = t;
                    return true;
                }
            }
            return false;
        }
    }

    #endregion

    #region Part 04 - BookingHelper Static Class

    public static class BookingHelper
    {
        private static int bookingCounter = 0;

        public static double CalcGroupDiscount(int numberOfTickets, double pricePerTicket)
        {
            double total = numberOfTickets * pricePerTicket;
            if (numberOfTickets >= 5)
                total *= 0.9; // 10% discount
            return total;
        }

        public static string GenerateBookingReference()
        {
            bookingCounter++;
            return $"BK-{bookingCounter}";
        }
    }

    #endregion

    #region Part 05 - Main Program

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q1 - Class vs Struct Demo
            Person p1 = new Person { Name = "Yara" };
            Person p2 = p1;
            p2.Name = "Ali";
            Console.WriteLine("Class Example: p1.Name = " + p1.Name);

            Point pt1;
            pt1.X = 10;
            pt1.Y = 20;
            Point pt2 = pt1;
            pt2.X = 50;
            Console.WriteLine("Struct Example: pt1.X = " + pt1.X);
            #endregion

            #region Q2 - Public vs Private Demo
            Student s = new Student();
            s.Name = "Omar";
            s.SetGrade(95);
            Console.WriteLine("Student Grade: " + s.GetGrade());
            #endregion

            #region Q5 - Ticket Booking Demo
            Cinema cinema = new Cinema();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\nEnter details for Ticket {i + 1}:");

                Console.Write("Movie Name: ");
                string movieName = Console.ReadLine();

                Console.Write("Ticket Type (Standard, VIP, IMAX): ");
                TicketType type = Enum.Parse<TicketType>(Console.ReadLine(), true);

                Console.Write("Seat Row (A-Z): ");
                char row = char.Parse(Console.ReadLine().ToUpper());

                Console.Write("Seat Number: ");
                int seatNumber = int.Parse(Console.ReadLine());

                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine());

                Ticket ticket = new Ticket(movieName, type, new Seat(row, seatNumber), price);
                cinema.AddTicket(ticket);
            }

            Console.WriteLine("\nAll tickets:");
            for (int i = 0; i < 3; i++)
            {
                cinema[i]?.PrintTicket();
            }

            Console.Write("\nEnter movie name to search: ");
            string searchMovie = Console.ReadLine();
            Ticket found = cinema.GetMovie(searchMovie);
            Console.WriteLine(found != null ? "\nFound Ticket:" : "\nMovie not found.");
            found?.PrintTicket();

            Console.WriteLine($"\nTotal tickets sold: {Ticket.GetTotalTicketsSold()}");

            Console.WriteLine("\nBooking references:");
            Console.WriteLine(BookingHelper.GenerateBookingReference());
            Console.WriteLine(BookingHelper.GenerateBookingReference());

            double groupDiscount = BookingHelper.CalcGroupDiscount(5, 80);
            Console.WriteLine($"\nGroup discount for 5 tickets at 80 EGP each: {groupDiscount:F2}");
            #endregion
        }
    }

    #endregion
}
