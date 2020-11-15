using Account.Api.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Account.Api.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserRegistrationTypeConfiguration());
            //builder.ApplyConfiguration(new FieldEntityTypeConfiguration());
            //builder.ApplyConfiguration(new FieldLovEntityTypeConfiguration());
            //builder.ApplyConfiguration(new ModuleFieldEntityTypeConfiguration());
        }
    }
}
