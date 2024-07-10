using PMS.UI.Contracts;
using PMS.UI.Services.Base;

namespace PMS.UI.Services.Repository_Implementation
{
    public class FormRepository : BaseHttpService, IFormRepository
    {
        public FormRepository(IClient client) : base(client)
        {
        }
    }
}
