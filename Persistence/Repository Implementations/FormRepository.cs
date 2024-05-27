using Domain;
using Domain.Repository_Interface;
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
    }
}
