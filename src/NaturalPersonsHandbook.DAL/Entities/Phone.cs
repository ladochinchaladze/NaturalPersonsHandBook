using System;
using System.Collections;

namespace NaturalPersonsHandbook.DAL.Entities
{
    public class Phone : BaseDates
    {
        public int Id { get; set; }
        public int NaturalPersonId { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneTypeId { get; set; }
        public PhoneType PhoneType { get; set; }
        public NaturalPerson NaturalPerson { get; set; }
    }
}