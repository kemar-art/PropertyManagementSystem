using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CheckBox.PurposeValuation
{
    public class PurposeOfValuationCheckBoxProperty
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool IsChecked { get; set; }

        public List<PurposeOfValuationCheckBox>? purposeOfValuationItemCheckBoxes { get; set; }
    }
}
