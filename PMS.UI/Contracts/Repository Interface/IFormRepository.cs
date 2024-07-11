using PMS.UI.Models.Form;
using PMS.UI.Services.Base;

namespace PMS.UI.Contracts
{
    public interface IFormRepository
    {
        Task<IEnumerable<FormVM>> GetAllForms();
        Task<FormVM> GetASingleFormDetails(int id);
        Task<Response<Guid>> CreateForm(FormVM form);
        Task<Response<Guid>> UpdateForm(FormVM form);
        Task<Response<Guid>> DeleteForm(int id);
    }
}
