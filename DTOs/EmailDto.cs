using Email.Models;

namespace Email.DTOs
{
      public class EmailDto
        {
            public int? Id { get; set; }
            public string? To { get; set; }
            public string? From { get; set; }
            public string? Subject { get; set; }
            public string? Body { get; set; }
            public DateTime SentDate { get; set; }
            public string? Status { get; set; } // e.g., "Pending", "Sent", "Failed"
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }


        public ICollection<CcRecipient> CcRecipients { get; set; } = new List<CcRecipient>();
            public ICollection<BccRecipient> BccRecipients { get; set; } = new List<BccRecipient>();
            public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
        
    }
}
