using System;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Models
{
    public class RequestDetail
    {
        [Key]
        public Guid Id {get; set;}
        [Required]
        public Guid BookId {get; set;}
        public virtual Book Book {get; set;}
        [Required]
        public Guid RequestId {get; set;}
        public virtual BookRequest Request {get; set;}
        
    }
}