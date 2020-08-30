using Microsoft.EntityFrameworkCore;
using NaturalPersonsHandbook.DAL.DbContextModel;
using NaturalPersonsHandbook.DAL.Entities;
using NaturalPersonsHandbook.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NaturalPersonsHandbook.DAL.Repositories
{
    public class NaturalPersonRepository : GenericRepository<NaturalPerson>, INaturalPersonRepository
    {
        NaturalPersonDbContext dbContext;

        public NaturalPersonRepository(NaturalPersonDbContext dbContext): base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public override async Task<NaturalPerson> GetAsync(int id)
        {
            var data = await dbContext
                .NaturalPersons
                .Include(x => x.City)
                .Include(x=>x.Gender)
                .Include(x=>x.Phones)
                .FirstOrDefaultAsync(x => x.Id == id);

            return data;
        }
    }
}
