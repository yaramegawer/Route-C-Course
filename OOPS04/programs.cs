using System;

/*
===========================================================
Part 01 : Theoretical Questions
===========================================================

Q1 : What is the difference between static binding and dynamic binding? When does each one happen?

Static Binding (Early Binding):
Static binding happens at compile time. The compiler decides which method will be executed before the program runs.
It usually occurs with:
- Method Overloading
- Static methods
- Private methods

Example:
If a class has multiple methods with the same name but different parameters,
the compiler decides which one to call during compilation.

Dynamic Binding (Late Binding):
Dynamic binding happens at runtime. The method that will be executed is determined when the program is running.
This occurs when using inheritance with method overriding and polymorphism.

Example:
Ticket t = new VIPTicket(...);
t.PrintTicket();

Even though the variable type is Ticket, the VIPTicket version of PrintTicket() will run.


-----------------------------------------------------------

Q2 : What is the difference between method overloading and method overriding?

Method Overloading:
- Same method name
- Different parameters
- Occurs within the same class
- Happens at compile time (static binding)

Example:
SetPrice(decimal price)
SetPrice(decimal basePrice, decimal multiplier)

Method Overriding:
- A child class redefines a method from a parent class
- Same method name and parameters
- Uses inheritance
- Happens at runtime (dynamic binding)

Example:
public virtual void PrintTicket() in base class
public override void PrintTicket() in child class


-----------------------------------------------------------

Q3 : What keywords are used for Method Overriding? What does each one mean?

virtual:
Used in the base class to indicate that a method can be overridden in derived classes.

override:
Used in the child class to provide a new implementation of a virtual method.

base:
Used to call the parent class version of a method inside the child class.

Example:

public virtual void PrintTicket()   // base class

public override void PrintTicket()  // child class
{
    base.PrintTicket();
}

===========================================================
Part 02 : Practical (Movie Ticket Booking System)
===========================================================
*/

namespace MovieTicketSystem
{
    #region Base Class - Ticket

    public class Ticket
    {
        private static int counter = 0;

        private string movieName;
        private decimal price;

        public int TicketId { get; }

        public string MovieName
        {
            get => movieName;
            set => movieName = value;
        }

        public decimal Price
        {
            get => price;
            set
            {
                if (value > 0)
                    price = value;
            }
        }

        public decimal PriceAfterTax => Price * 1.14m;

        public Ticket(string movieName, decimal price)
        {
            MovieName = movieName;
            Price = price;

            counter++;
            TicketId = counter;
        }

        // Method Overloading
        public void SetPrice(decimal price)
        {
            Price = price;
        }

        public void SetPrice(decimal basePrice, decimal multiplier)
        {
            Price = basePrice * multiplier;
        }

        // Virtual method for polymorphism
        public virtual void PrintTicket()
        {
            Console.WriteLine($"Ticket ID: {TicketId}");
            Console.WriteLine($"Movie Name: {MovieName}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Price After Tax: {PriceAfterTax}");
        }

        public static int GetTotalTickets()
        {
            return counter;
        }
    }

    #endregion


    #region Child Classes

    public class StandardTicket : Ticket
    {
        public string SeatNumber { get; set; }

        public StandardTicket(string movieName, decimal price, string seatNumber)
            : base(movieName, price)
        {
            SeatNumber = seatNumber;
        }

        public override void PrintTicket()
        {
            base.PrintTicket();
            Console.WriteLine($"Seat Number: {SeatNumber}");
            Console.WriteLine("Ticket Type: Standard");
            Console.WriteLine("------------------------");
        }
    }

    public class VIPTicket : Ticket
    {
        public bool LoungeAccess { get; set; }
        public decimal ServiceFee { get; } = 50m;

        public VIPTicket(string movieName, decimal price, bool loungeAccess)
            : base(movieName, price + 50m)
        {
            LoungeAccess = loungeAccess;
        }

        public override void PrintTicket()
        {
            base.PrintTicket();
            Console.WriteLine($"Lounge Access: {LoungeAccess}");
            Console.WriteLine($"Service Fee: {ServiceFee}");
            Console.WriteLine("Ticket Type: VIP");
            Console.WriteLine("------------------------");
        }
    }

    public class IMAXTicket : Ticket
    {
        public bool Is3D { get; set; }

        public IMAXTicket(string movieName, decimal price, bool is3D)
            : base(movieName, is3D ? price + 30m : price)
        {
            Is3D = is3D;
        }

        public override void PrintTicket()
        {
            base.PrintTicket();
            Console.WriteLine($"IMAX 3D: {Is3D}");
            Console.WriteLine("Ticket Type: IMAX");
            Console.WriteLine("------------------------");
        }
    }

    #endregion


    #region Projector (Sealed Class)

    public sealed class Projector
    {
        public void Start()
        {
            Console.WriteLine("Projector is ON.");
        }

        public void Stop()
        {
            Console.WriteLine("Projector is OFF.");
        }
    }

    #endregion


    #region Cinema Class

    public class Cinema
    {
        private Ticket[] tickets = new Ticket[20];
        private Projector projector = new Projector();

        public string CinemaName { get; set; }

        public Cinema(string cinemaName)
        {
            CinemaName = cinemaName;
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

        public void PrintAllTickets()
        {
            Console.WriteLine($"--- Tickets in {CinemaName} ---");

            foreach (var ticket in tickets)
            {
                if (ticket != null)
                    ticket.PrintTicket(); // polymorphism
            }
        }

        public void OpenCinema()
        {
            Console.WriteLine($"{CinemaName} is now OPEN.");
            projector.Start();
        }

        public void CloseCinema()
        {
            Console.WriteLine($"{CinemaName} is now CLOSED.");
            projector.Stop();
        }
    }

    #endregion


    #region Main Program

    internal class Program
    {
        // Static method required in assignment
        public static void ProcessTicket(Ticket t)
        {
            Console.WriteLine("Processing Ticket...");
            t.PrintTicket();
        }

        static void Main(string[] args)
        {
            // Create cinema and open it
            Cinema cinema = new Cinema("Grand Cinema");
            cinema.OpenCinema();

            // Create tickets
            StandardTicket standard = new StandardTicket("Inception", 100m, "A10");
            VIPTicket vip = new VIPTicket("Avatar 2", 200m, true);
            IMAXTicket imax = new IMAXTicket("Interstellar", 150m, true);

            // Test method overloading
            standard.SetPrice(120m);
            standard.SetPrice(100m, 1.5m);

            // Add tickets to cinema
            cinema.AddTicket(standard);
            cinema.AddTicket(vip);
            cinema.AddTicket(imax);

            // Print all tickets
            cinema.PrintAllTickets();

            // Process one ticket
            ProcessTicket(vip);

            // Close cinema
            cinema.CloseCinema();

            Console.WriteLine($"Total Tickets Created: {Ticket.GetTotalTickets()}");
        }
    }

    #endregion
}
