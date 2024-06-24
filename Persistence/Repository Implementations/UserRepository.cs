using Application.Contracts.Repository_Interface;
using Domain;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository_Implementations;

public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
{
    public UserRepository(PMSDatabaseContext dbContext) : base(dbContext)
    {
    }
}
