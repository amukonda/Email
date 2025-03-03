using System.ComponentModel.DataAnnotations;

namespace Email.Models
{
    public class CcEmail
    {
        [Key]
        public int Id { get; set; }
        public int BaseEmailId { get; set; }
        public string? Email { get; set; }

    }
}
