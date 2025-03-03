using System.ComponentModel.DataAnnotations;

namespace Email.Models
{

    public class Attachments
    {
        [Key]
        public int Id { get; set; }
        public int BaseEmailId { get; set; }
        public string Filename { get; set; }
        public string ContentType { get; set; }
        public string Content { get; set; }
    }
}
