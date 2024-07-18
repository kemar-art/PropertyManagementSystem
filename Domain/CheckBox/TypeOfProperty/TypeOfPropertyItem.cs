using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CheckBox.TypeOfProperty
{
    public class TypeOfPropertyItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool IsChecked { get; set; }

        public List<FormTypeOfPropertyItem>? FormTypeOfPropertyItem { get; set; }
    }
}
