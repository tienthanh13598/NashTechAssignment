using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace BookManagement.Models
{
    public class Category
    {
        public Guid ID { get; set; }
        public string Name { get; set; }    
        public virtual ICollection<Book> Books { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
