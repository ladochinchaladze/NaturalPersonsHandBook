using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NaturalPersonsHandbook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NaturalPersonsHandbook.DAL.Configurations
{
    public class NaturalPersonConfiguration : IEntityTypeConfiguration<NaturalPerson>
    {
        public void Configure(EntityTypeBuilder<NaturalPerson> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.IdentityNumber)
               .HasMaxLength(11)
               .IsRequired();


            builder.HasOne(x => x.City)
                .WithMany(x => x.NaturalPersons)
                .HasForeignKey(x => x.CityId);

            builder.HasOne(x => x.Gender)
               .WithMany(x => x.NaturalPersons)
               .HasForeignKey(x => x.GenderId);

            builder.HasMany(x => x.NaturalPersonsRelationships)
                .WithOne(x => x.NaturalPerson)
                .HasForeignKey(x => x.NaturalPersonId);

            builder.HasMany(x => x.Phones)
               .WithOne(x => x.NaturalPerson)
               .HasForeignKey(x => x.NaturalPersonId);

            


        }
    }
}
