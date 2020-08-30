using System.Collections.Generic;

namespace NaturalPersonsHandbook.DAL.Entities
{
    public class PhoneType : BaseTemplate
    {

        public PhoneType()
        {
            Phones = new HashSet<Phone>();
        }
        public ICollection<Phone> Phones { get; set; }
    }
}