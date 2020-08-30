using NaturalPersonsHandbook.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonsHandbook.Service.Models
{
    public class FullSearchModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GendersEnum? Gender { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public CitiesEnum? City { get; set; }
        public int? pageNumber { get; set; }
        public int pageSize { get; set; }
    }
}
