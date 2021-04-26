using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BookManagement.Models
{
    public class Book
    {
       [Key]
       [Required]
       
       public Guid BookId {get; set;}
       [Required]
       public string Title {get; set;}
       public string Author {get; set;}
       public string Image {get; set;}
       
    
       public string Description {get; set;}
       [Required]
       public Guid CategoryId {get; set;}
       public virtual Category Category {get; set;}
       [JsonIgnore]
       [IgnoreDataMember]
       
       public virtual ICollection<RequestDetail> RequestDetails {get; set;}
    }

}