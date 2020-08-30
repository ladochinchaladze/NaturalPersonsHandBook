using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NaturalPersonsHandbook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonsHandbook.DAL.Configurations
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
