using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CheckBox.PurposeValuation
{
    public class PurposeOfValuationCheckBox
    {
        public PurposeOfValuationCheckBox() { }

        public Form Form { get; set; }
        public int? FormId { get; set; }

        public PurposeOfValuationCheckBoxProperty PurposeOfValuationCheckBoxProperty { get; set; }
        public int PurposeOfValuationCheckBoxPropertyId { get; set; }

        public PurposeOfValuationCheckBox(int? formId, int purposeOfValuationCheckBoxPropertyId)
        {
            FormId = formId;
            PurposeOfValuationCheckBoxPropertyId = purposeOfValuationCheckBoxPropertyId;
        }
    }
}

