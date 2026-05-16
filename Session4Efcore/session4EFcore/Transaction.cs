using session4EFcore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace session4EFcore
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Amount { get; set; }

        public TransactionType TransactionType { get; set; }

        public string Description { get; set; }

        public string AccountNumber { get; set; }

        public Account Account { get; set; }
    }
}

