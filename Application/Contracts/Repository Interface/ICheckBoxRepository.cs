using Domain.CheckBoxItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Repository_Interface
{
    public interface ICheckBoxRepository
    {
        Task<List<ServiceRequestItem>> GetAllServiceRequestItem();
        Task<List<TypeOfPropertyItem>> GetAllTypeOfPropertyItem();
        Task<List<PurposeOfValuationItem>> GetAllPurposeOfValuationItem();
    }
}
