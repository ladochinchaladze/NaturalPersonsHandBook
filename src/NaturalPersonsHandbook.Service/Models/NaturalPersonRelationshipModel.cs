using NaturalPersonsHandbook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using NaturalPersonsHandbook.Common.Enums;

namespace NaturalPersonsHandbook.Service.Models
{
    public class NaturalPersonRelationshipModel
    {
        public int NaturalPersonId { get; set; }
        public int TargetNaturalPersonId { get; set; }
        public RelationshipTypesEnum RelationshipType { get; set; }
    }
}
