using Account.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Api.Database.Configurations
{
    public class UserRegistrationTypeConfiguration : IEntityTypeConfiguration<UserRegistration>
    {
        public void Configure(EntityTypeBuilder<UserRegistration> builder)
        {
            builder.ToTable("UserRegistration");

            //Composite Key
            builder.HasKey(prop => prop.Email);

            builder.Property(prop => prop.Name)
               .IsRequired(true);

            builder.Property(prop => prop.Password)
               .IsRequired(true);

            builder.Property(prop => prop.Mobile)
               .IsRequired(true);

            builder.Property(prop => prop.Active)
               .IsRequired(true);

            builder.Property(prop => prop.DateCreated)
              .IsRequired(true);

            builder.Property(prop => prop.DateUpdated)
            .IsRequired(false);
        }
    }
}
