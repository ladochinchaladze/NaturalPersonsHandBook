using AutoMapper;
using NaturalPersonsHandbook.DAL.Entities;
using NaturalPersonsHandbook.Service.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NaturalPersonsHandbook.Service.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NaturalPerson, NaturalPersonModel>()
                .ForMember(d => d.City, o => o.MapFrom(s => s.CityId))
                .ForMember(d => d.Gender, o => o.MapFrom(s => s.GenderId))
                .ForMember(d => d.NaturalPersonsRelationships, o => o.Ignore())
                .ForMember(d => d.Image, o => o.Ignore())
                .ForMember(d => d.Phones, o => o.Ignore());

            CreateMap<NaturalPersonModel, NaturalPerson>()
                .ForMember(d => d.CityId, o => o.MapFrom(s => s.City))
                .ForMember(d => d.GenderId, o => o.MapFrom(s => s.Gender))
                .ForMember(d => d.City, o => o.Ignore())
                .ForMember(d => d.Gender, o => o.Ignore())
                .ForMember(d => d.ImageName, o => o.Ignore())
                .ForMember(d => d.Phones, o => o.Ignore())
                .ForMember(d => d.NaturalPersonsRelationships, o => o.Ignore());
                

            

            CreateMap<NaturalPersonsRelationship, NaturalPersonRelationshipModel>()
                 .ForMember(d => d.RelationshipType, o => o.MapFrom(s => s.RelationshipTypeId));

            CreateMap<NaturalPersonRelationshipModel, NaturalPersonsRelationship>()
                 .ForMember(d => d.RelationshipTypeId, o => o.MapFrom(s => s.RelationshipType))
                 .ForMember(d => d.TargerNaturalPerson, o => o.Ignore())
                 .ForMember(d => d.NaturalPerson, o => o.Ignore())
                 .ForMember(d => d.RelationshipType, o => o.Ignore());



            CreateMap<Phone, PhoneModel>()
                .ForMember(d => d.PhoneType, o => o.MapFrom(s => s.PhoneTypeId));

            CreateMap<PhoneModel, Phone>()
               .ForMember(d => d.PhoneTypeId, o => o.MapFrom(s => s.PhoneType))
               .ForMember(d => d.PhoneType, o => o.Ignore())
               .ForMember(d => d.NaturalPerson, o => o.Ignore());

            //CreateMap<List<PhoneModel>, List<Phone>>();
        }
    }
}
