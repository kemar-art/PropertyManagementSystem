using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class AppResponse
    {
        public bool Exists { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
