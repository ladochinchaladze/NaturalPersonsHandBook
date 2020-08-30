using System;

namespace NaturalPersonsHandbook.DAL.Entities
{
    public class BaseTemplate : BaseDates
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        
    }
}