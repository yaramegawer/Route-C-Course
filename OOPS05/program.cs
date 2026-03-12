using System;

/*
===========================================================
Part 01 : Theoretical Questions
===========================================================

Q1 : What is an interface in C#? Why do we use interfaces instead of depending on concrete classes directly?
An interface in C# is a contract that defines a set of methods or properties that a class must implement.
Interfaces do not contain implementation, only definitions.

Benefits of using interfaces:
1. Loose Coupling – Classes depend on abstractions rather than concrete implementations.
2. Flexibility – Different classes can implement the same interface in different ways.
3. Testability – Interfaces allow easier mocking and unit testing.
4. Polymorphism – Code can work with objects through their interface type.

-----------------------------------------------------------

Q2 :

a) Problem:
Both interfaces define a method named Greet(). The Translator class implements one version,
so both interfaces currently share the same implementation.

b) Fix:
Use Explicit Interface Implementation.

Example:

class Translator : IEnglishSpeaker, IArabicSpeaker
{
    void IEnglishSpeaker.Greet()
    {
        Console.WriteLine("Hello");
    }

    void IArabicSpeaker.Greet()
    {
        Console.WriteLine("Ahlan");
    }
}

This technique is called Explicit Interface Implementation.

c) Can we call translator.Greet() directly?
No. Because explicit interface methods are only accessible through the interface type.

Example:

Translator t = new Translator();
((IEnglishSpeaker)t).Greet(); // Hello
((IArabicSpeaker)t).Greet();  // Ahlan

-----------------------------------------------------------

Q3 : Shallow Copy vs Deep Copy

Shallow Copy:
Copies the object but keeps references to the same reference-type fields.
Changes to shared objects affect both copies.

Deep Copy:
Creates a completely independent copy including all referenced objects.

Risk of Shallow Copy:
If the object contains reference-type fields, both objects share the same reference.
Changing the referenced object affects both copies.

-----------------------------------------------------------

Q4 : Output Explanation

Employee e1 = { Title="Dev", Dept.Name="IT" }
Employee e2 = shallow copy of e1

e2.Title = "QA"
e2.Dept.Name = "Testing"

Title is value copied independently.
Dept is a reference shared by both objects.

Output:

Dev - Testing
QA - Testing

Because Dept reference is shared.

===========================================================
Part 02 : Practical
===========================================================
*/

namespace MovieTicketSystem
{
    #region Interfaces

    // Printing contract
    public interface IPrintable
    {
        void Print();
    }

    // Booking contract
    public interface IBookable
    {
        bool Book();
        bool Cancel();
        bool IsBooked { get; }
    }

    #endregion


    #region Base Ticket Class

    public abstract class Ticket : IPrintable, IBookable, ICloneable
    {
        private static int counter = 0;

        public int TicketId { get; }
        public string MovieName { get; set; }
        public decimal Price { get; set; }

        public bool IsBooked { get; private set; }

        public decimal PriceAfterTax => Price * 1.14m;

        public Ticket(string movie, decimal price)
        {
            counter++;
            TicketId = counter;
            MovieName = movie;
            Price = price;
        }

        // Booking
        public bool Book()
        {
            if (IsBooked)
                return false;

            IsBooked = true;
            return true;
        }

        // Cancellation
        public bool Cancel()
        {
            if (!IsBooked)
                return false;

            IsBooked = false;
            return true;
        }

        // Printing contract
        public abstract void Print();

        // Clone contract
        public abstract object Clone();
    }

    #endregion


    #region Ticket Types

    public class StandardTicket : Ticket
    {
        public string SeatNumber { get; set; }

        public StandardTicket(string movie, decimal price, string seat)
            : base(movie, price)
        {
            SeatNumber = seat;
        }

        public override void Print()
        {
            Console.WriteLine(
                $"[Ticket #{TicketId}] {MovieName} | Standard | Seat: {SeatNumber} | Price: {Price} | After Tax: {PriceAfterTax} | Booked: {(IsBooked ? "Yes" : "No")}"
            );
        }

        public override object Clone()
        {
            return new StandardTicket(MovieName, Price, SeatNumber);
        }
    }


    public class VIPTicket : Ticket
    {
        public bool LoungeAccess { get; set; }
        public decimal ServiceFee { get; set; } = 50;

        public VIPTicket(string movie, decimal price, bool lounge)
            : base(movie, price)
        {
            LoungeAccess = lounge;
        }

        public override void Print()
        {
            Console.WriteLine(
                $"[Ticket #{TicketId}] {MovieName} | VIP | Lounge: {LoungeAccess} | Fee: {ServiceFee} | Price: {Price} | After Tax: {PriceAfterTax} | Booked: {(IsBooked ? "Yes" : "No")}"
            );
        }

        public override object Clone()
        {
            return new VIPTicket(MovieName, Price, LoungeAccess);
        }
    }


    public class IMAXTicket : Ticket
    {
        public bool Is3D { get; set; }

        public IMAXTicket(string movie, decimal price, bool is3d)
            : base(movie, price)
        {
            Is3D = is3d;
        }

        public override void Print()
        {
            Console.WriteLine(
                $"[Ticket #{TicketId}] {MovieName} | IMAX | 3D: {Is3D} | Price: {Price} | After Tax: {PriceAfterTax} | Booked: {(IsBooked ? "Yes" : "No")}"
            );
        }

        public override object Clone()
        {
            return new IMAXTicket(MovieName, Price, Is3D);
        }
    }

    #endregion


    #region Cinema

    public class Cinema
    {
        private IPrintable[] tickets = new IPrintable[20];

        public void AddTicket(IPrintable t)
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i] == null)
                {
                    tickets[i] = t;
                    return;
                }
            }
        }

        public void PrintAllTickets()
        {
            Console.WriteLine("\n--- All Tickets ---");

            foreach (var t in tickets)
            {
                if (t != null)
                    t.Print();
            }
        }

        public void OpenCinema()
        {
            Console.WriteLine("=== Cinema Opened ===");
        }

        public void CloseCinema()
        {
            Console.WriteLine("\n=== Cinema Closed ===");
        }
    }

    #endregion


    #region Helper Utility

    public static class BookingHelper
    {
        public static void PrintAll(IPrintable[] items)
        {
            Console.WriteLine("\n--- BookingHelper.PrintAll ---");

            foreach (var item in items)
            {
                item.Print();
            }
        }
    }

    #endregion


    #region Main

    class Program
    {
        static void Main()
        {
            // a. Create Cinema
            Cinema cinema = new Cinema();
            cinema.OpenCinema();

            // b. Create tickets
            StandardTicket t1 = new StandardTicket("Inception", 80, "A5");
            VIPTicket t2 = new VIPTicket("Avengers", 200, true);
            IMAXTicket t3 = new IMAXTicket("Dune", 130, true);

            t1.Book();
            t2.Book();
            t3.Book();

            cinema.AddTicket(t1);
            cinema.AddTicket(t2);
            cinema.AddTicket(t3);

            // c. Print all tickets
            cinema.PrintAllTickets();

            // d. Clone VIP ticket
            Console.WriteLine("\n--- Clone Test ---");

            VIPTicket clone = (VIPTicket)t2.Clone();
            clone.MovieName = "Interstellar";

            Console.Write("Original : ");
            t2.Print();

            Console.Write("Clone    : ");
            clone.Print();

            // e. Cancel one ticket
            Console.WriteLine("\n--- After Cancellation ---");
            t1.Cancel();
            t1.Print();

            // f. Utility method
            BookingHelper.PrintAll(new IPrintable[] { t1, t2, t3 });

            // g. Close cinema
            cinema.CloseCinema();
        }
    }

    #endregion
}
