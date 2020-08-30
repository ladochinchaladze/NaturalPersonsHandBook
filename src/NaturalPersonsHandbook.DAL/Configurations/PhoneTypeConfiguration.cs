using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NaturalPersonsHandbook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonsHandbook.DAL.Configurations
{
    public class PhoneTypeConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
