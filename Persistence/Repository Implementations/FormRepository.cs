using Domain;
using Domain.Repository_Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository_Implementations
{
    public class FormRepository : GenericRepository<Form>, IFormRepository
    {
        public FormRepository(PMSDatabaseContext dbContext) : base(dbContext)
        {
        }

        //public Task<bool> FormIdMustExist(int id)
        //{
        //    return _dbContext.Forms.AnyAsync(p => p.Id == id);
        //}
    }
}
