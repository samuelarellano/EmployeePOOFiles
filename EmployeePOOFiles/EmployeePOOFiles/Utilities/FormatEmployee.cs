using EmployeePOOFiles.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePOOFiles.Utilities
{
    public class FormatEmployee : IFormatterEmployee
    {
        public string Format(Employee employee)
        {
            return $"Name:{employee.Name};Occupation:{employee.Occupation}|";
        }
    }
}
