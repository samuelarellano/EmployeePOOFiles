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
        /// <summary>
        /// Formats the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        string Format(Employee employee);
    }
}
