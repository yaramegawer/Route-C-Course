using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EfCoreSession2
{
    public class OrganizerProfile
    {
        [Key]
        public int OrganizerId { get; set; }

        public string? Bio { get; set; }

        public string? Website { get; set; }

        public string? LogoUrl { get; set; }

        public Organizer Organizer { get; set; }
    }
}
