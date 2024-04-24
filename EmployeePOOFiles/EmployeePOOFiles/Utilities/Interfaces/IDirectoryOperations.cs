using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePOOFiles.Utilities.Interfaces
{
    public interface IDirectoryOperations
    {
        bool CreateDirectory(string path);
        bool RemoveDirectory(string path);
    }
}
