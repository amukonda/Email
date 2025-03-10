using AutoMapper;
using Email.Data;
using Email.DTOs;
using Email.Interfaces;
using Email.Models;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Xml.Serialization;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
namespace Email.Services
{
    public class EmailService : IEmailService
    {


        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly EmailSettings _emailSettings;

        public EmailService(AppDbContext context,IMapper mapper, IOptions<EmailSettings> emailSettings)
        {
            _context = context;
            _mapper = mapper;
            _emailSettings = emailSettings.Value;

        }


      
        public async Task<EmailResponseDto> SendEmailAsync(EmailDto email)
        {

            var message = new MimeMessage();

           // message.From.Add(new MailboxAddress("", _emailSettings.FromEmail));
            message.From.Add(new MailboxAddress("", email.From));
            message.To.Add(new MailboxAddress("", email.To));

            // Add CC recipients
            foreach (var cc in email.CcRecipients)
            {
                message.Cc.Add(new MailboxAddress("", cc.Email));
            }

            // Add BCC recipients
            foreach (var bcc in email.BccRecipients)
            {
                message.Bcc.Add(new MailboxAddress("", bcc.Email));
            }

            message.Subject = email.Subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = email.Body };

            // Add attachments
            foreach (var attachment in email.Attachments)
            {
                var contentType = new MimeKit.ContentType("application", "octet-stream");

                if (!string.IsNullOrEmpty(attachment.ContentType))
                {
                    var parts = attachment.ContentType.Split('/');
                    if (parts.Length == 2)
                    {
                        contentType = new MimeKit.ContentType(parts[0], parts[1]);
                    }
                }

                // Convert Base64 string to byte array
                byte[] byteArray = Convert.FromBase64String(attachment.Content);

                bodyBuilder.Attachments.Add(attachment.Filename, byteArray, contentType);
            }

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.Port, MailKit.Security.SecureSocketOptions.None);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }

            // Update the email status and sent date
            email.SentDate = DateTime.UtcNow;
            email.Status = "Sent";

            // Save email record to the database

            var mainEmail = new EmailDetail()
            {
                From = email.From,
                To = email.To,
                Subject = email.Subject,
                Body = email.Body,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                CreatedBy = 1,
                UpdatedBy = 1
            };
              await _context.Emails.AddAsync(mainEmail);
              await _context.SaveChangesAsync();

            // Save CC recipients
            foreach (var dtx in email.CcRecipients)
            {
                dtx.EmailId = (int)mainEmail.Id;
                await _context.CcRecipients.AddAsync(dtx);
                await _context.SaveChangesAsync();
            }

            // Save BCC recipients 
            foreach (var dtx in email.BccRecipients)
            {
                dtx.EmailId = (int)mainEmail.Id;
                await _context.BccRecipients.AddAsync(dtx);
                await _context.SaveChangesAsync();
            }


            // Save attachments
            //  await _context.Attachments.AddRangeAsync(email.Attachments);
            foreach (var dtx in email.Attachments)
            {
                dtx.EmailId = (int)mainEmail.Id;
                await _context.Attachments.AddAsync(dtx);
                await _context.SaveChangesAsync();
            }

            var emailResponse = new EmailResponseDto();
            emailResponse.responseStatus = "Email Sent Successfully.";
            return emailResponse;
        }

        public static T DeserializeXml<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xml))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
