using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NaturalPersonsHandbook.Common.Enums;
using NaturalPersonsHandbook.Common.Paging;
using NaturalPersonsHandbook.DAL.Entities;
using NaturalPersonsHandbook.DAL.Interfaces;
using NaturalPersonsHandbook.Service.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalPersonsHandbook.Service.Services
{
    public class NaturalPersonService
    {
        IUnitOfWork uow;
        IMapper mapper;
        IWebHostEnvironment webHostEnvironment;

        public NaturalPersonService(IUnitOfWork uow, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }


        public async Task<NaturalPersonModel> GetNaturalPersonAsync(int id)
        {
            var naturalPerson = await this.uow.NaturalPersons.GetAsync(id);
            var data = mapper.Map<NaturalPerson, NaturalPersonModel>(naturalPerson);
            return data;
        }


        public async Task AddNaturalPersonAsync(NaturalPersonModel model)
        {
            var imageName = string.Empty;

            if (model.Image != null)
            {
                imageName = UploadImage(model.Image);
            }

            var naturalPerson = mapper.Map<NaturalPersonModel, NaturalPerson>(model);
            naturalPerson.ImageName = imageName;
            await this.uow.NaturalPersons.AddAsync(naturalPerson);
            await this.uow.SaveChangesAsync();

            var naturalPersonsRelationships = mapper.Map<List<NaturalPersonRelationshipModel>, List<NaturalPersonsRelationship>>(model.NaturalPersonsRelationships);
            naturalPersonsRelationships.ForEach(x => x.NaturalPersonId = naturalPerson.Id);
            await this.uow.NaturalPersonsRelationship.AddRangeAsync(naturalPersonsRelationships);


            var phones = mapper.Map<List<PhoneModel>, List<Phone>>(model.Phones);
            phones.ForEach(x => x.NaturalPersonId = naturalPerson.Id);
            await this.uow.Phones.AddRangeAsync(phones);

            await this.uow.SaveChangesAsync();
        }


        public async Task UpdateNaturalPersonAsync(NaturalPersonModel model)
        {

            var naturalPerson = await this.uow.NaturalPersons.GetAsync(model.Id);

            naturalPerson.FirstName = model.FirstName;
            naturalPerson.LastName = model.LastName;
            naturalPerson.GenderId = (int)model.Gender;
            naturalPerson.IdentityNumber = model.IdentityNumber;
            naturalPerson.BirthDate = model.BirthDate;
            naturalPerson.CityId = (int)model.City;

            await this.uow.SaveChangesAsync();


            await this.UpdatePhonesAsync(model.Phones, model.Id);
        }


        public async Task UpdatePhonesAsync(List<PhoneModel> model, int naturalPersonId)
        {
            var phones = await this.uow.Phones.GetAll().Where(x => x.NaturalPersonId == naturalPersonId).ToListAsync();

            List<Phone> phonesForAdd = new List<Phone>();

            foreach (var item in model)
            {
                if (!phones.Any(x => x.PhoneNumber == item.PhoneNumber))
                {
                    phonesForAdd.Add(new Phone
                    {
                        NaturalPersonId = naturalPersonId,
                        PhoneNumber = item.PhoneNumber,
                        CreateDate = DateTime.Now,
                        PhoneTypeId = (int)item.PhoneType
                    });
                }
            }

            foreach (var item in phones)
            {
                if (!model.Any(x => x.PhoneNumber == item.PhoneNumber))
                {
                    item.DeleteDate = DateTime.Now;
                }
            }

            await this.uow.Phones.AddRangeAsync(phonesForAdd);

            await this.uow.SaveChangesAsync();
        }


        public async Task UpdateNaturalPersonsImageAsync(IFormFile image, int naturalPersonId)
        {
            var naturalPerson = await this.uow.NaturalPersons.GetAsync(naturalPersonId);
            DeleteImage(naturalPerson.ImageName);

            var newImageName = UploadImage(image);
            naturalPerson.ImageName = newImageName;

            await this.uow.SaveChangesAsync();
        }



        public async Task UpdateNaturalPersonRelationshipsAsync(List<NaturalPersonRelationshipModel> model)
        {
            var naturalPersonId = model.FirstOrDefault()?.NaturalPersonId;

            var naturalPersonRelationships = this.uow.NaturalPersonsRelationship.GetAll().Where(x => x.NaturalPersonId == naturalPersonId);

            List<NaturalPersonsRelationship> realtionForAdd = new List<NaturalPersonsRelationship>();

            foreach (var item in model)
            {
                if (!naturalPersonRelationships.Any(x => x.TargetNaturalPersonId == item.TargetNaturalPersonId && x.NaturalPersonId != item.NaturalPersonId))
                {
                    realtionForAdd.Add(new NaturalPersonsRelationship
                    {
                        NaturalPersonId = item.NaturalPersonId,
                        TargetNaturalPersonId = item.TargetNaturalPersonId,
                        RelationshipTypeId = (int)item.RelationshipType,
                        CreateDate = DateTime.Now
                    });
                }
            }

            foreach (var item in naturalPersonRelationships)
            {
                if (!model.Any(x => x.TargetNaturalPersonId == item.TargetNaturalPersonId && x.NaturalPersonId != item.NaturalPersonId))
                {
                    item.DeleteDate = DateTime.Now;
                }
            }

            await this.uow.NaturalPersonsRelationship.AddRangeAsync(realtionForAdd);

            await this.uow.SaveChangesAsync();
        }


        public async Task DeleteNaturalPersonAsync(int id)
        {
            var naturalPerson = await this.uow.NaturalPersons.GetAsync(id);
            naturalPerson.DeleteDate = DateTime.Now;

            await this.uow.SaveChangesAsync();
        }


        public async Task<List<NaturalPersonModel>> GetAllNaturalPersonsAsync()
        {
            var natuarlPersons = await this.uow.NaturalPersons.GetAll().Where(x => x.DeleteDate == null).ToListAsync();
            var data = mapper.Map<List<NaturalPerson>, List<NaturalPersonModel>>(natuarlPersons);
            return data;
        }


        public async Task<List<NaturalPersonModel>> FastSearch(string content, int? pageNumber, int pageSize)
        {
            var natuarlPersons = this.uow.NaturalPersons.GetAll().Where(x => x.DeleteDate == null);
            var data = await natuarlPersons.Where
                (
                x => x.FirstName.Contains(content) || x.LastName.Contains(content) || x.IdentityNumber.Contains(content)
                ).ToListAsync();

            var result = mapper.Map<List<NaturalPerson>, List<NaturalPersonModel>>(data);

            return PaginatedList<NaturalPersonModel>.Create(result, pageNumber ?? 1, pageSize);
        }

        public async Task<List<NaturalPersonModel>> FullSearchAsync(FullSearchModel model)
        {
            var natuarlPersons = this.uow.NaturalPersons.GetAll().Where(x => x.DeleteDate == null);

            var birthDate = default(DateTime);

            if (model.BirthDate != null)
                birthDate = model.BirthDate.Value.Date;


            var data = await natuarlPersons.Where
                (
                x => (string.IsNullOrEmpty(model.FirstName) ? true : x.FirstName.Contains(model.FirstName)) &&
                 (string.IsNullOrEmpty(model.LastName) ? true : x.LastName.Contains(model.LastName)) &&
                (string.IsNullOrEmpty(model.IdentityNumber) ? true : x.IdentityNumber.Contains(model.IdentityNumber)) &&
                (model.Gender == null ? true : x.GenderId == (int)model.Gender) &&
                (model.BirthDate == null ? true : x.BirthDate == birthDate) &&
                (model.City == null ? true : x.CityId == (int)model.City)
                ).ToListAsync();

            var result = mapper.Map<List<NaturalPerson>, List<NaturalPersonModel>>(data);

            return PaginatedList<NaturalPersonModel>.Create(result, model.pageNumber ?? 1, model.pageSize);
        }


        public async Task<List<ReportModel>> ReportAsync()
        {
            var naturalPersons = await this.uow.NaturalPersons.GetAll().Where(x => x.DeleteDate == null).ToListAsync();

            var data = naturalPersons.Select(x => new ReportModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                RelationshipTypesList = x.NaturalPersonsRelationships
                .GroupBy(gr=> gr.RelationshipTypeId)
                .Select(s => new RelationshipTypesListForReportModel
                {
                    Count = s.Count(),
                    RelationshipType = (RelationshipTypesEnum)s.Key
                }).ToList()
            }).ToList();

            return data;
        }


        private void DeleteImage(string imageName)
        {
            string folder = Path.Combine(webHostEnvironment.WebRootPath, "images");

            string filePath = Path.Combine(folder, imageName);

            File.Delete(filePath);
        }

        private string UploadImage(IFormFile image)
        {
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;

            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");

            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }
            return uniqueFileName;
        }




    }
}
