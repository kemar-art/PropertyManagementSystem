using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CheckBox.ServiceRequest
{
    public class ServiceRequestCheckBoxProperty
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool IsChecked { get; set; }

        public List<ServiceRequestCheckBox>? ServiceRequestCheckBoxes { get; set; }
    }
}

