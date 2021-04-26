using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using BookManagement.Enums;

namespace BookManagement.Models
{
    public class BookRequest
    {
        [Key]
        public Guid RequestId {get; set;}
        [Required]
        public DateTime DateRequest {get; set;}
        public DateTime? ReturnRequest {get; set;}
        [Required]
        public Status Status {get; set;}
        [Required]
        public Guid RequestUserId {get; set;}
        public virtual User RequestUser {get; set;}
        
        public Guid? ApprovalUserId {get; set;}
        [NotMapped]
        public virtual User ApprovalUser {get; set;}
        public  Guid? RejectUserId {get; set;}
        [NotMapped]
        public virtual User RejectUser {get; set;}
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<RequestDetail> RequestDetails {get; set;}

        
    }
}