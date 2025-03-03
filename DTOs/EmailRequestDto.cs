using Email.Models;

namespace Email.DTOs
{
    public class EmailRequestDto
    {
        public string From { get; set; }
        public List<string> To { get; set; }
        public List<string> Cc { get; set; }
        public List<string> Bcc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<Attachment> Attachments { get; set; }
        public string ReplyTo { get; set; }
        public string Priority { get; set; }
    }
}
