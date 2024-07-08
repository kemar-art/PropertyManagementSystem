using Domain;
using Domain.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Repository_Interface
{
    public interface IAppraiserRerpository : IGenericRepository<Form>
    {
        Task<IEnumerable<Form>> GetFormThatWasAssignedToAppraiser();
    }
}
