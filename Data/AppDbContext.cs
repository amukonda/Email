using Email.Models;
using Microsoft.EntityFrameworkCore;

namespace Email.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Attachments>  attachments { get; set; }
        public DbSet<BaseEmail>  baseEmails { get; set; }
        public DbSet<BccEmail> bccEmails { get; set; }
        public DbSet<CcEmail>   ccEmails { get; set; }
        public DbSet<ToEmail>  toEmails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure RightsAuthoriser as a keyless entity
            modelBuilder.Entity<ToEmail>()
                .HasNoKey(); // Indicate that this entity does not have a key

            // Add other model configurations as needed
        }


    }
}
