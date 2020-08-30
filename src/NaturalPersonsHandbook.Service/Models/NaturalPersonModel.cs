using Microsoft.AspNetCore.Http;
using NaturalPersonsHandbook.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonsHandbook.Service.Models
{
    public class NaturalPersonModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GendersEnum Gender { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public CitiesEnum City { get; set; }
        public IFormFile Image { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public List<NaturalPersonRelationshipModel> NaturalPersonsRelationships { get; set; }
        public List<PhoneModel> Phones { get; set; }

    }
}
