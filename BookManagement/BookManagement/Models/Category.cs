using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BookManagement.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId {get; set;}
        [Required]
        public string CategoryName {get; set;}
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Book> Books {get; set;}

    }
}