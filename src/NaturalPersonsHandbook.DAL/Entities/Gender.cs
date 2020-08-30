using System.Collections.Generic;

namespace NaturalPersonsHandbook.DAL.Entities
{
    public class Gender : BaseTemplate
    {
        public Gender()
        {
            NaturalPersons = new HashSet<NaturalPerson>();
        }
        public ICollection<NaturalPerson> NaturalPersons { get; set; }
    }
}