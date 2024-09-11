using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class NotFoundException : Exception
    {
        object key = new();
        public NotFoundException(string name, object key, string message) : base($"{name} with value {key} was not found., {message}") 
        {
            
        }

        public NotFoundException(string name, object key) : base($"{name} with value {key} was not found.")
        {

        }
    }
}
