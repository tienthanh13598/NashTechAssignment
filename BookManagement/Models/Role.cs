using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace BookManagement.Models
{
    public class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}