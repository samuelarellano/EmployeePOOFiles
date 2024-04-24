using EmployeePOOFiles.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePOOFiles.Utilities.Interfaces
{
    public interface IFormatterEmployee
    {
        string Format(Employee employee);
    }
}
