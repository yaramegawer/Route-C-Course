using System;
using System.Collections.Generic;
using System.Text;

namespace EFS01
{
    internal class Book
    {
        public int Id { get; set; }  // EF Convention Primary Key

        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int Pages { get; set; }
        public int PublishedYear { get; set; }
        public bool InStock { get; set; }

        // Foreign Keys (Convention)
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
