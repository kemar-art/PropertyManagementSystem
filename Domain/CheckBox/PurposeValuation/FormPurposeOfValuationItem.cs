using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CheckBox.PurposeValuation
{
    public class FormPurposeOfValuationItem
    {
        public Form Form { get; set; }
        public int? FormId { get; set; }

        public PurposeOfValuationItem PurposeOfValuationItem { get; set; }
        public int PurposeOfValuationItemId { get; set; }

        public FormPurposeOfValuationItem()
        {

        }

        public FormPurposeOfValuationItem(int? formId, int purposeOfValuationItemId)
        {
            FormId = formId;
            PurposeOfValuationItemId = purposeOfValuationItemId;
        }
    }
}
