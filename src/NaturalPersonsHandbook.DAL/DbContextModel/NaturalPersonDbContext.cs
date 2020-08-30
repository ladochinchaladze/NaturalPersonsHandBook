using Microsoft.EntityFrameworkCore;
using NaturalPersonsHandbook.DAL.Entities;
using NaturalPersonsHandbook.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NaturalPersonsHandbook.DAL.DbContextModel
{
    public class NaturalPersonDbContext : DbContext, INaturalPersonDbContext
    {
        public NaturalPersonDbContext(DbContextOptions<NaturalPersonDbContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<NaturalPerson> NaturalPersons { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<NaturalPersonsRelationship> NaturalPersonsRelationships { get; set; }
        public DbSet<RelationshipType> RelationshipTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
             new City
             {
                 Id = 1,
                 Code = 1,
                 CreateDate = DateTime.Now,
                 DeleteDate = null,
                 Name = "Tbilisi"
             },
            new City
            {
                Id = 2,
                Code = 2,
                CreateDate = DateTime.Now,
                DeleteDate = null,
                Name = "Kutaisi"
            },
            new City
            {
                Id = 3,
                Code = 3,
                CreateDate = DateTime.Now,
                DeleteDate = null,
                Name = "Batumi"
            });


            modelBuilder.Entity<Gender>().HasData(
                new Gender
                {
                    Id = 1,
                    Code = 1,
                    CreateDate = DateTime.Now,
                    DeleteDate = null,
                    Name = "Male"
                },
                new Gender
                {
                    Id = 2,
                    Code = 2,
                    CreateDate = DateTime.Now,
                    DeleteDate = null,
                    Name = "Female"
                });


            modelBuilder.Entity<PhoneType>().HasData(
                new PhoneType
                {
                    Id = 1,
                    Code = 1,
                    CreateDate = DateTime.Now,
                    DeleteDate = null,
                    Name = "Mobile"
                },
                new PhoneType
                {
                    Id = 2,
                    Code = 2,
                    CreateDate = DateTime.Now,
                    DeleteDate = null,
                    Name = "Office"
                },
                new PhoneType
                {
                    Id = 3,
                    Code = 3,
                    CreateDate = DateTime.Now,
                    DeleteDate = null,
                    Name = "Home"
                });


            modelBuilder.Entity<RelationshipType>().HasData(
                new RelationshipType
                {
                    Id = 1,
                    Code = 1,
                    CreateDate = DateTime.Now,
                    DeleteDate = null,
                    Name = "Colleague"
                },
                new RelationshipType
                {
                    Id = 2,
                    Code = 2,
                    CreateDate = DateTime.Now,
                    DeleteDate = null,
                    Name = "Familiar"
                },
                new RelationshipType
                {
                    Id = 3,
                    Code = 3,
                    CreateDate = DateTime.Now,
                    DeleteDate = null,
                    Name = "Relative"
                },
                new RelationshipType
                {
                    Id = 4,
                    Code = 4,
                    CreateDate = DateTime.Now,
                    DeleteDate = null,
                    Name = "Other"
                });


            modelBuilder.Entity<NaturalPersonsRelationship>().HasKey(x => new { x.NaturalPersonId, x.TargetNaturalPersonId });


            modelBuilder.Entity<NaturalPerson>()
               .HasMany(x => x.NaturalPersonsRelationships)
               .WithOne(x => x.NaturalPerson)
               .HasForeignKey(x => x.NaturalPersonId)
               .OnDelete(DeleteBehavior.NoAction);



            modelBuilder.Entity<NaturalPersonsRelationship>()
                .HasOne(x => x.TargerNaturalPerson)
                .WithMany(x => x.TargetNaturalPersons)
                .HasForeignKey(x => x.TargetNaturalPersonId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
