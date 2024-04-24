// See https://aka.ms/new-console-template for more information

using EmployeePOOFiles.Entities;
using EmployeePOOFiles.Utilities;
using System.Text;

int option = 0;

while(option != 1000)
{
    Console.WriteLine("Employee Manager System");
    Console.WriteLine("1. Add Employee");
    Console.WriteLine("1000 Exit to program");
    int.TryParse(Console.ReadLine(), out option);


    switch (option)
    {
        case 1:

            string path = @"C:\sarellano-employees";

            DirectoryOperations directoryOperations = new DirectoryOperations();
            directoryOperations.CreateDirectory(path);

            FormatEmployee formatEmployee = new FormatEmployee();
            var employee = AddEmployeeConfiguration();
            var format = formatEmployee.Format(employee);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(format);

            FileOperations fileOperations = new FileOperations();

            path += @"\employeeDB.txt";

            if (File.Exists(path)) 
            {
                var employeeFile = File.ReadAllText(path);
                string[] employees = employeeFile.Split("|");
                Array.Resize(ref employees, employees.Count()+1);
                employees[employees.Count() - 1] = format;
                employees[employees.Length] = format;
                File.Delete(path);
                fileOperations.CreateFile(path, employees.ToString());
            }

            if (fileOperations.CreateFile(path, sb.ToString()))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success");
            }
            Console.ResetColor();
            option = 1000;

            break;

        case 1000:
            break;

        default:
            Console.WriteLine("Invalid option");
            break;
    }
}



Employee AddEmployeeConfiguration()
{
    Employee employee = new Employee();
    Console.WriteLine("Name: ");
    employee.Name = Console.ReadLine();
    Console.WriteLine("Occupation:");
    employee.Occupation = Console.ReadLine();

    var randomId = new Random();
    employee.Id = randomId.Next(0);

    return employee;
}

