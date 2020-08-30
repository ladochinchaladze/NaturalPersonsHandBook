using NaturalPersonsHandbook.Common.Enums;
using System;

namespace NaturalPersonsHandbook.Service.Models
{
    public class PhoneModel
    {
        public int Id { get; set; }
        public int NaturalPersonId { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneTypesEnum PhoneType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}