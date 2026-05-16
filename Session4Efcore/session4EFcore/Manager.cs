using session4EFcore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace session4EFcore
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime HireDate { get; set; }

        public Branch Branch { get; set; }
    }
}
