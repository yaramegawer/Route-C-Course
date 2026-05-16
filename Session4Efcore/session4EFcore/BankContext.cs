using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace session4EFcore
{
    public class BankContext : DbContext
    {
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=BankDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAccount>()
                .HasKey(ca => new { ca.CustomerId, ca.AccountNumber });

            modelBuilder.Entity<Branch>()
                .HasOne(b => b.Manager)
                .WithOne(m => m.Branch)
                .HasForeignKey<Branch>(b => b.ManagerId);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Branch)
                .WithMany(b => b.Accounts)
                .HasForeignKey(a => a.BranchCode);

            modelBuilder.Entity<CustomerAccount>()
                .HasOne(ca => ca.Customer)
                .WithMany(c => c.CustomerAccounts)
                .HasForeignKey(ca => ca.CustomerId);

            modelBuilder.Entity<CustomerAccount>()
                .HasOne(ca => ca.Account)
                .WithMany(a => a.CustomerAccounts)
                .HasForeignKey(ca => ca.AccountNumber);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Account)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AccountNumber);

            // Seed Managers
            modelBuilder.Entity<Manager>().HasData(
                new Manager
                {
                    ManagerId = 1,
                    FullName = "Ahmed Hassan",
                    Email = "ahmed@nbe.com",
                    PhoneNumber = "01000000001",
                    HireDate = new DateTime(2020, 1, 10)
                },
                new Manager
                {
                    ManagerId = 2,
                    FullName = "Sara Ali",
                    Email = "sara@nbe.com",
                    PhoneNumber = "01000000002",
                    HireDate = new DateTime(2021, 3, 15)
                }
            );

            // Seed Branches
            modelBuilder.Entity<Branch>().HasData(
                new Branch
                {
                    BranchCode = "BR001",
                    BranchName = "Cairo Main Branch",
                    Address = "Cairo",
                    PhoneNumber = "0222222222",
                    ManagerId = 1
                },
                new Branch
                {
                    BranchCode = "BR002",
                    BranchName = "Alex Branch",
                    Address = "Alexandria",
                    PhoneNumber = "0333333333",
                    ManagerId = 2
                }
            );
        }
    }
}
