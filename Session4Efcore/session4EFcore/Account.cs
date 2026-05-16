using session4EFcore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Transactions;

namespace session4EFcore
{
    public class Account
    {
        [Key]
        public string AccountNumber { get; set; }

        public AccountType AccountType { get; set; }

        public DateTime OpeningDate { get; set; }

        public decimal Balance { get; set; }

        public string BranchCode { get; set; }

        public Branch Branch { get; set; }

        public ICollection<CustomerAccount> CustomerAccounts { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
