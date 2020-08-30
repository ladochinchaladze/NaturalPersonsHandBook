using NaturalPersonsHandbook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NaturalPersonsHandbook.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<City> Cities { get;}
        IGenericRepository<Gender> Genders { get;}
        INaturalPersonRepository NaturalPersons { get; }
        IGenericRepository<Phone> Phones { get;}
        IGenericRepository<PhoneType> PhoneTypes { get;}
        IGenericRepository<NaturalPersonsRelationship> NaturalPersonsRelationship { get;}
        IGenericRepository<RelationshipType> RelationshipTypes { get;}
        public Task SaveChangesAsync();
    }
}
