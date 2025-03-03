using System.ComponentModel.DataAnnotations;

namespace Email.Models
{
    public class BaseEmail
    {

        [Key]
        public int Id { get; set; }
        public string? From { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public string? ReplyTo { get; set; }
        public string? Priority { get; set; }
        public string? EmailStatus { get; set; }
        public string? EmailSendingReport { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }


    }
}
