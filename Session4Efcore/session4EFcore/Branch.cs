using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text;

namespace session4EFcore
{
    public class Branch
    {
        [Key]
        public string BranchCode { get; set; }

        [Required]
        public string BranchName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int ManagerId { get; set; }

        public Manager Manager { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}

