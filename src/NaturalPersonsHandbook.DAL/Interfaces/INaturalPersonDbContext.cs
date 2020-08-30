using Microsoft.EntityFrameworkCore;
using NaturalPersonsHandbook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonsHandbook.DAL.Interfaces
{
    public interface INaturalPersonDbContext
    {
        DbSet<City> Cities { get; set; }
        DbSet<Gender> Genders { get; set; }
        DbSet<NaturalPerson> NaturalPersons { get; set; }
        DbSet<Phone> Phones { get; set; }
        DbSet<PhoneType> PhoneTypes { get; set; }
        DbSet<NaturalPersonsRelationship> NaturalPersonsRelationships { get; set; }
        DbSet<RelationshipType> RelationshipTypes { get; set; }
    }
}
