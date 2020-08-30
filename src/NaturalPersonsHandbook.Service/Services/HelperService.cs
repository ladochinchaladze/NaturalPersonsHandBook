using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NaturalPersonsHandbook.DAL.Entities;
using NaturalPersonsHandbook.DAL.Interfaces;
using NaturalPersonsHandbook.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalPersonsHandbook.Service.Services
{
    public class HelperService
    {
        IUnitOfWork uow;
        IMapper mapper;

        public HelperService(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<List<TemplateModel>> GetGendersAsync()
        {
            var genders = await (this.uow.Genders.GetAll().Where(x=>x.DeleteDate == null)).ToListAsync();
            var data = mapper.Map<List<Gender>, List<TemplateModel>>(genders);

            return data;
        }

        public async Task<List<TemplateModel>> GetCytiesAsync()
        {
            var cities = await (this.uow.Cities.GetAll().Where(x => x.DeleteDate == null)).ToListAsync();
            var data = mapper.Map<List<City>, List<TemplateModel>>(cities);

            return data;
        }

        public async Task<List<TemplateModel>> GetRelationshipTypesAsync()
        {
            var relationshipTypes = await (this.uow.RelationshipTypes.GetAll().Where(x => x.DeleteDate == null)).ToListAsync();
            var data = mapper.Map<List<RelationshipType>, List<TemplateModel>>(relationshipTypes);

            return data;
        }


        public async Task<List<NaturalPersonRelationshipModel>> GetNaturalPersonRelationshipsAsync()
        {
            var relationships = await (this.uow.NaturalPersonsRelationship.GetAll().Where(x => x.DeleteDate == null)).ToListAsync();
            var data = mapper.Map<List<NaturalPersonsRelationship>, List<NaturalPersonRelationshipModel>>(relationships);

            return data;
        }

    }
}
