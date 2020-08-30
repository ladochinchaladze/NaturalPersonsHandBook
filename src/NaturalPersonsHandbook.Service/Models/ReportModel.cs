using Microsoft.AspNetCore.Mvc.RazorPages;
using NaturalPersonsHandbook.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonsHandbook.Service.Models
{
    public class ReportModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<RelationshipTypesListForReportModel> RelationshipTypesList { get; set; }
    }
}
