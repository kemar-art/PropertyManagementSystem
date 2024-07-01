using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CheckBox.TypeOfProperty
{
    public class TypeOfPropertyCheckBox
    {
        public TypeOfPropertyCheckBox() { }

        public Form Form { get; set; }
        public int? FormId { get; set; }

        public TypeOfPropertyCheckBoxProperty TypeOfPropertyCheckProperty { get; set; }
        public int TypeOfPropertyCheckBoxPropertyId { get; set; }

        public TypeOfPropertyCheckBox(int? formId, int typeOfPropertyCheckBoxPropertyId)
        {
            FormId = formId;
            TypeOfPropertyCheckBoxPropertyId = typeOfPropertyCheckBoxPropertyId;
        }
    }
}

