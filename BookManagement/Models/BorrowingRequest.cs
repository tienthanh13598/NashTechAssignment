using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace BookManagement.Models
{
    public class BorrowingRequest
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        public DateTime RequestAt { get; set; }
        public int Status { get; set; }
        public virtual ICollection<BorrowingRequestDetail> RequestDetails { get; set; }
    }
}