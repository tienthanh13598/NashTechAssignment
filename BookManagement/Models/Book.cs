using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace BookManagement.Models
{
    public class Book
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public Guid CategoryID { get; set; }
        [ForeignKey("CategoryID")]

        public virtual Category Category { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}