using System;
using System.Collections.Generic;
using System.Text;

namespace EFS01
{
    internal class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        // Navigation Property
        public List<Book> Books { get; set; }
    }
}
