using session4EFcore;
using System;
using System.Collections.Generic;
using System.Text;
using session4EFcore.Data;
using session4EFcore.Enums;
using session4EFcore.Models;
using Microsoft.EntityFrameworkCore;

namespace session4EFcore
{
    public class BankService
    {
        private readonly BankContext _context = new();

        public void AddCustomer()
        {
            try
            {
                Console.Write("Full Name: ");
                string name = Console.ReadLine();

                Console.Write("National ID: ");
                string nationalId = Console.ReadLine();

                Console.Write("DOB (yyyy-mm-dd): ");
                DateTime dob = DateTime.Parse(Console.ReadLine());

                Console.Write("Email: ");
                string email = Console.ReadLine();

                Console.Write("Phone: ");
                string phone = Console.ReadLine();

                Console.Write("Address: ");
                string address = Console.ReadLine();

                Console.Write("Customer Type (0=Individual,1=Business): ");
                CustomerType type =
                    (CustomerType)int.Parse(Console.ReadLine());

                Customer customer = new()
                {
                    FullName = name,
                    NationalId = nationalId,
                    DateOfBirth = dob,
                    Email = email,
                    PhoneNumber = phone,
                    Address = address,
                    CustomerType = type
                };

                _context.Customers.Add(customer);
                _context.SaveChanges();

                Console.WriteLine("Customer Added Successfully.");
            }
            catch
            {
                Console.WriteLine("Invalid Input.");
            }
        }

        public void OpenAccount()
        {
            try
            {
                Console.Write("Account Number: ");
                string accNo = Console.ReadLine();

                Console.Write("Branch Code: ");
                string branchCode = Console.ReadLine();

                var branch = _context.Branches.Find(branchCode);

                if (branch == null)
                {
                    Console.WriteLine("Branch Not Found.");
                    return;
                }

                Console.Write("Customer Id: ");
                int customerId = int.Parse(Console.ReadLine());

                var customer = _context.Customers.Find(customerId);

                if (customer == null)
                {
                    Console.WriteLine("Customer Not Found.");
                    return;
                }

                Account account = new()
                {
                    AccountNumber = accNo,
                    AccountType = AccountType.Savings,
                    OpeningDate = DateTime.Now,
                    Balance = 0,
                    BranchCode = branchCode
                };

                _context.Accounts.Add(account);

                CustomerAccount customerAccount = new()
                {
                    CustomerId = customerId,
                    AccountNumber = accNo,
                    OwnershipStartDate = DateTime.Now,
                    OwnershipType = OwnershipType.Primary,
                    AccountStatus = AccountStatus.Active
                };

                _context.CustomerAccounts.Add(customerAccount);

                _context.SaveChanges();

                Console.WriteLine("Account Opened Successfully.");
            }
            catch
            {
                Console.WriteLine("Invalid Input.");
            }
        }

        public void UpdateAccountStatus()
        {
            Console.Write("Account Number: ");
            string accNo = Console.ReadLine();

            Console.Write("Customer Id: ");
            int customerId = int.Parse(Console.ReadLine());

            var customerAccount = _context.CustomerAccounts
                .FirstOrDefault(ca =>
                    ca.AccountNumber == accNo &&
                    ca.CustomerId == customerId);

            if (customerAccount == null)
            {
                Console.WriteLine("Record Not Found.");
                return;
            }

            customerAccount.AccountStatus =
                customerAccount.AccountStatus == AccountStatus.Active
                ? AccountStatus.Closed
                : AccountStatus.Active;

            _context.SaveChanges();

            Console.WriteLine("Status Updated.");
        }

        public void RemoveAccountFromCustomer()
        {
            Console.Write("Account Number: ");
            string accNo = Console.ReadLine();

            Console.Write("Customer Id: ");
            int customerId = int.Parse(Console.ReadLine());

            var customerAccount = _context.CustomerAccounts
                .FirstOrDefault(ca =>
                    ca.AccountNumber == accNo &&
                    ca.CustomerId == customerId);

            if (customerAccount == null)
            {
                Console.WriteLine("Not Found.");
                return;
            }

            _context.CustomerAccounts.Remove(customerAccount);

            _context.SaveChanges();

            Console.WriteLine("Removed Successfully.");
        }

        public void ListCustomers()
        {
            var customers = _context.Customers
                .Include(c => c.CustomerAccounts)
                .ThenInclude(ca => ca.Account)
                .ToList();

            foreach (var customer in customers)
            {
                Console.WriteLine($"\nCustomer: {customer.FullName}");

                foreach (var ca in customer.CustomerAccounts)
                {
                    Console.WriteLine(
                        $"Account: {ca.Account.AccountNumber} | " +
                        $"Status: {ca.AccountStatus}");
                }
            }
        }
    }
}



