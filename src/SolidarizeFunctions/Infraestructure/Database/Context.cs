
using Microsoft.EntityFrameworkCore;
using Solidarize.Infraestructure.Database.Entities.Chat;
using Solidarize.Infraestructure.Database.Entities.Users;
using Solidarize.Infraestructure.Database.Map.Chat;
using Solidarize.Infraestructure.Database.Map.Users;

namespace Solidarize.Infraestructure.Database
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<RequestCompany> RequestCompanies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DBCONN"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChatMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new MessageMap());
            modelBuilder.ApplyConfiguration(new PasswordMap());
            modelBuilder.ApplyConfiguration(new RequestCompanyMap());
            
            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
