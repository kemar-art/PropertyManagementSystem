using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CheckBox.ServiceRequest
{
    public class FormServiceRequestItem
    {
        public Form Form { get; set; }
        public int? FormId { get; set; }

        public ServiceRequestItem ServiceRequestItem { get; set; }
        public int ServiceRequestItemId { get; set; }

        public FormServiceRequestItem()
        {

        }

        public FormServiceRequestItem(int? formId, int serviceRequestItemId)
        {
            FormId = formId;
            ServiceRequestItemId = serviceRequestItemId;
        }
    }
}
