using Email.DTOs;
using Email.Models;
using Microsoft.EntityFrameworkCore;

namespace Email.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EmailDetail> Emails { get; set; }
        public DbSet<CcRecipient> CcRecipients { get; set; }
        public DbSet<BccRecipient> BccRecipients { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CcRecipient>()
            //    .HasOne(cr => cr.EmailDetails)
            //    .WithMany(e => e.CcRecipients)
            //    .HasForeignKey(cr => cr.EmailId);

            //modelBuilder.Entity<BccRecipient>()
            //    .HasOne(br => br.EmailDetails)
            //    .WithMany(e => e.BccRecipients)
            //    .HasForeignKey(br => br.EmailId);

            //modelBuilder.Entity<Attachment>()
            //    .HasOne(a => a.EmailDetails)
            //    .WithMany(e => e.Attachments)
            //    .HasForeignKey(a => a.EmailId);
        }
    }
}
