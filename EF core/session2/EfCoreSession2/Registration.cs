using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreSession2
{
    public class Registration
    {
        public int AttendeeId { get; set; }

        public Attendee Attendee { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }

        public string? NoteToOrganizer { get; set; }

        public DateTime RegisteredAt { get; set; }
    }
}
