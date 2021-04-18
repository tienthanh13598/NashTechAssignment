using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace BookManagement.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }

    }
}