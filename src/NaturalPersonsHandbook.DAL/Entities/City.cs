using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace NaturalPersonsHandbook.DAL.Entities
{
    public class City : BaseTemplate
    {
        public City()
        {
            NaturalPersons = new HashSet<NaturalPerson>();
        }
        public ICollection<NaturalPerson> NaturalPersons { get; set; }
    }
}