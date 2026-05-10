using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFS01
{
    public class AppDbContext : DbContext
    {
        internal DbSet<Book> Books { get; set; }
        internal DbSet<Author> Authors { get; set; }
        internal DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=ReadMoreBooksDB;Trusted_Connection=True;TrustServerCertificate=True"
            );
        }
    }
}
