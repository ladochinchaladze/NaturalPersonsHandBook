using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonsHandbook.Service.Models
{
    public class ErrorResponseModel
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
