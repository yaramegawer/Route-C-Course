using System;

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

        public static int GetTotalTickets()
        {
            return counter;
        }

        public override string ToString()
        {
            return $"Ticket ID: {TicketId}, Movie: {MovieName}, Price: {Price}, After Tax: {PriceAfterTax}";
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

        public override string ToString()
        {
            return base.ToString() + $", Seat: {SeatNumber}, Type: Standard";
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

        public override string ToString()
        {
            return base.ToString() + $", VIP Lounge: {LoungeAccess}, Service Fee: {ServiceFee}";
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

        public override string ToString()
        {
            return base.ToString() + $", IMAX 3D: {Is3D}";
        }
    }

    #endregion

    #region Composition Class - Projector (Sealed)

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

    #region Cinema Class (Composition + Ticket Storage)

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
                    Console.WriteLine(ticket);
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
        static void Main(string[] args)
        {
            // a. Create Cinema and open it
            Cinema cinema = new Cinema("Grand Cinema");
            cinema.OpenCinema();

            // b. Create one of each ticket type
            StandardTicket standard = new StandardTicket("Inception", 100m, "A10");
            VIPTicket vip = new VIPTicket("Avatar 2", 200m, true);
            IMAXTicket imax = new IMAXTicket("Interstellar", 150m, true);

            cinema.AddTicket(standard);
            cinema.AddTicket(vip);
            cinema.AddTicket(imax);

            // c. Print all tickets
            cinema.PrintAllTickets();

            Console.WriteLine($"Total Tickets Created: {Ticket.GetTotalTickets()}");

            // d. Close Cinema
            cinema.CloseCinema();
        }
    }

    #endregion
}
