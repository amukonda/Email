using System.ComponentModel.DataAnnotations;

namespace Email.Models
{
    public class BccRecipient
    {
        [Key]
        public int Id { get; set; }
        public int EmailId { get; set; } // Foreign key
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        //public EmailDetail EmailDetails { get; set; } // Navigation property
    }
}
