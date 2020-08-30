using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace NaturalPersonsHandbook.DAL.Entities
{
    public class NaturalPerson : BaseDates
    {
        public NaturalPerson()
        {
            Phones = new HashSet<Phone>();
            NaturalPersonsRelationships = new HashSet<NaturalPersonsRelationship>();
            TargetNaturalPersons = new HashSet<NaturalPersonsRelationship>();
        }
      

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public string ImageName { get; set; }
        public City City { get; set; }
        public Gender Gender { get; set; }
        public virtual ICollection<NaturalPersonsRelationship> NaturalPersonsRelationships { get; set; }
        public virtual ICollection<NaturalPersonsRelationship> TargetNaturalPersons { get; set; }
        public ICollection<Phone> Phones { get; set; }

    }
}
