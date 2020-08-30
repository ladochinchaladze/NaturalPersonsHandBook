using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NaturalPersonsHandbook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonsHandbook.DAL.Configurations
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.PhoneType)
                .WithMany(x => x.Phones)
                .HasForeignKey(x => x.PhoneTypeId);


            builder.Property(x => x.PhoneNumber)
               .HasMaxLength(50);
        }
    }
}
