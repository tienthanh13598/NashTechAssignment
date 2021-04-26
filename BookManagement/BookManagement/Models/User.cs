using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using BookManagement.Enums;

namespace BookManagement.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime DoB { get; set; }
        [Required]
        public Role Role { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<BookRequest> BookRequests { get; set; }
    }
}