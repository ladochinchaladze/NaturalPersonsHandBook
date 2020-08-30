using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NaturalPersonsHandbook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NaturalPersonsHandbook.DAL.Configurations
{
    //public class RelatedNaturalPersonConfiguration : IEntityTypeConfiguration<NaturalPersonsRelationship>
    //{
    //    public void Configure(EntityTypeBuilder<NaturalPersonsRelationship> builder)
    //    {

    //        builder.HasKey(x => new { x.NaturalPersonId, x.TargerNaturalPersonId });

    //        builder.HasOne(x => x.TargerNaturalPerson)
    //             .WithMany(x => x.NaturalPersonsRelationships)
    //             .HasForeignKey(x => x.TargerNaturalPersonId)
    //             .OnDelete(DeleteBehavior.NoAction); ;


    //    }
    //}
}
