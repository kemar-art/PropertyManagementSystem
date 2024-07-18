using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CheckBox.TypeOfProperty
{
    public class FormTypeOfPropertyItem
    {
        public Form Form { get; set; }
        public int? FormId { get; set; }

        public TypeOfPropertyItem TypeOfPropertyItem { get; set; }
        public int TypeOfPropertyItemId { get; set; }

        public FormTypeOfPropertyItem()
        {

        }

        public FormTypeOfPropertyItem(int? formId, int typeOfPropertyItemId)
        {
            FormId = formId;
            TypeOfPropertyItemId = typeOfPropertyItemId;
        }
    }
}
