using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CheckBox.ServiceRequest
{
    public class ServiceRequestCheckBox
    {
        public ServiceRequestCheckBox()
        {

        }

        public Form Form { get; set; }
        public int? FormId { get; set; }

        public ServiceRequestCheckBoxProperty serviceRequestCheckBoxProperty { get; set; }
        public int ServiceRequestCheckBoxPropertyId { get; set; }

        public ServiceRequestCheckBox(int? formId, int serviceRequestCheckBoxPropertyId)
        {
            FormId = formId;
            ServiceRequestCheckBoxPropertyId = serviceRequestCheckBoxPropertyId;
        }
    }
}
