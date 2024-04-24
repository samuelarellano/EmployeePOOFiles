using EmployeePOOFiles.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePOOFiles.Interfaces
{
    public interface IEmployee
    {
        bool AddEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(Employee employee);
        List<Employee> GetAll();    
    }
}
