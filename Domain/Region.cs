using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Region
    {
        public Guid Id { get; set; }

        public string CountiesName { get; set; } = string.Empty;

        public string ParishName { get; set; } = string.Empty;


        public Region(Guid id, string countiesName, string parishName)
        {
            Id = id;
            CountiesName = countiesName;
            ParishName = parishName;
        }

        public Region()
        {
        }
    }
}
