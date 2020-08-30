using System;

namespace NaturalPersonsHandbook.DAL.Entities
{
    public class NaturalPersonsRelationship : BaseDates
    {
        public int NaturalPersonId { get; set; }
        public int TargetNaturalPersonId { get; set; }
        public int RelationshipTypeId { get; set; }
        public RelationshipType RelationshipType { get; set; }
        public virtual NaturalPerson NaturalPerson { get; set; }
        public virtual NaturalPerson TargerNaturalPerson { get; set; }
    }
}