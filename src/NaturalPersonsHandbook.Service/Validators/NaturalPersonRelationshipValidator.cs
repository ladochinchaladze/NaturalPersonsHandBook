using FluentValidation;
using Microsoft.Extensions.Localization;
using NaturalPersonsHandbook.Service.Models;
using NaturalPersonsHandbook.Service.Res.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonsHandbook.Service.Validators
{
    public class NaturalPersonRelationshipValidator : AbstractValidator<NaturalPersonRelationshipModel>
    {
        public NaturalPersonRelationshipValidator()
        {
           
            RuleFor(x => x.RelationshipType).IsInEnum();
        }
    }
}
