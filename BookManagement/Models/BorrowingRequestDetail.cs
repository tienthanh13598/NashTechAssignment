using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace BookManagement.Models
{
    public class BorrowingRequestDetail
    {
     public Guid ID { get; set; }
     public Guid BookID { get; set; }
     [ForeignKey("BookID")]
     public virtual Book Book { get; set; }
     public Guid RequestID { get; set; }   
     [ForeignKey("RequestID")]
     public virtual BorrowingRequest BorrowingRequest { get; set; }
    }
}