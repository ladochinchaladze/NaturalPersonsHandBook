using System.Collections;
using System.Collections.Generic;

namespace NaturalPersonsHandbook.DAL.Entities
{
    public class RelationshipType : BaseTemplate
    {
        public RelationshipType()
        {
            NaturalPersonsRelationships = new HashSet<NaturalPersonsRelationship>();
        }
        public ICollection<NaturalPersonsRelationship> NaturalPersonsRelationships { get; set; }
    }
}