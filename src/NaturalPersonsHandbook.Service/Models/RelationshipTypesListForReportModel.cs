using NaturalPersonsHandbook.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonsHandbook.Service.Models
{
    public class RelationshipTypesListForReportModel
    {
        public RelationshipTypesEnum RelationshipType { get; set; }
        public int Count { get; set; }
    }
}
