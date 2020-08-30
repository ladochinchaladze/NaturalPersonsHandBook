using FluentValidation;
using Microsoft.Extensions.Localization;
using NaturalPersonsHandbook.Common.Enums;
using NaturalPersonsHandbook.DAL.Entities;
using NaturalPersonsHandbook.DAL.Interfaces;
using NaturalPersonsHandbook.Service.Models;
using NaturalPersonsHandbook.Service.Res.Resources;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NaturalPersonsHandbook.Service.Validators
{
    public class NaturalPersonValidator : AbstractValidator<NaturalPersonModel>
    {

        public NaturalPersonValidator(IStringLocalizerFactory factory)
        {
             
            var type = typeof(ValidationResponce);
            IStringLocalizer localizer = factory.Create(type);

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .Length(2, 50)
                .Matches("^[a-zA-Z]*$|^[ა-ჰ]*$");

            RuleFor(x => x.LastName)
               .NotEmpty()
               .Length(2, 50)
               .Matches("^[a-zA-Z]*$|^[ა-ჰ]*$");

            RuleFor(x => x.Gender).IsInEnum();

            RuleFor(x => x.IdentityNumber)
                .NotEmpty()
                .Length(11);

            RuleFor(x => x.BirthDate)
                .LessThanOrEqualTo(DateTime.Now.AddYears(-18))
                .WithMessage(localizer["LegalAgeRequired"].Value);

            RuleFor(x => x.City).IsInEnum();

        }
    }
}
