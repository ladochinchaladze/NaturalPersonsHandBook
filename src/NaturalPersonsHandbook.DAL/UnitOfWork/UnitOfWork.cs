using Microsoft.EntityFrameworkCore.Storage;
using NaturalPersonsHandbook.DAL.DbContextModel;
using NaturalPersonsHandbook.DAL.Entities;
using NaturalPersonsHandbook.DAL.Interfaces;
using NaturalPersonsHandbook.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NaturalPersonsHandbook.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        NaturalPersonDbContext dbContext;

        public UnitOfWork(NaturalPersonDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IGenericRepository<City> Cities => new GenericRepository<City>(dbContext);

        public IGenericRepository<Gender> Genders => new GenericRepository<Gender>(dbContext);

        public INaturalPersonRepository NaturalPersons => new NaturalPersonRepository(dbContext);

        public IGenericRepository<Phone> Phones => new GenericRepository<Phone>(dbContext);

        public IGenericRepository<PhoneType> PhoneTypes => new GenericRepository<PhoneType>(dbContext);

        public IGenericRepository<NaturalPersonsRelationship> NaturalPersonsRelationship => new GenericRepository<NaturalPersonsRelationship>(dbContext);

        public IGenericRepository<RelationshipType> RelationshipTypes => new GenericRepository<RelationshipType>(dbContext);
        public async Task SaveChangesAsync()
        {
            await this.dbContext.SaveChangesAsync();
        }
    }
}
