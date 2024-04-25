// See https://aka.ms/new-console-template for more information



using Newtonsoft.Json;
using System.Linq.Expressions;

int option = 0;
const string SUCCESS = "Success";
string path = @"C:\sarellano-employees";
string pathJSON = $@"{path}\employeesJSON.json";
path += @"\employeeDB.txt";


while (option != 1000)
{
    FormatEmployee formatEmployee = new FormatEmployee();
    Console.WriteLine("Employee Manager System");
    Console.WriteLine("1. Add Employee");
    Console.WriteLine("2. Read Employees");
    Console.WriteLine("3. Create JSON File (.json)");
    Console.WriteLine("4. Read JSON File (.json)");
    Console.WriteLine("1000 Exit to program");
    int.TryParse(Console.ReadLine(), out option);


    switch (option)
    {
        case 1:

            DirectoryOperations directoryOperations = new DirectoryOperations();
            directoryOperations.CreateDirectory(path);

            
            var employee = AddEmployeeConfiguration();
            var format = formatEmployee.Format(employee);


            FileOperations fileOperations = new FileOperations();

            

            //string employee = File.Exists(path) ? File.ReadAllText(path) : "";

            if (File.Exists(path))
            {
                string? employeeFile = File.ReadAllText(path);
                employeeFile.Replace("\n", "");
                employeeFile += format;
                try
                {
                    File.WriteAllText(path, employeeFile);
                }
                catch (Exception ex)
                {
                    formatEmployee.FormatMessage(ex.Message, (int)MessageTypes.Error);
                }
                finally
                {
                    formatEmployee.FormatMessage(SUCCESS);
                }

            }
            else
            {
                SaveEmployeeNewFile(path, format);
            }

            break;

        case 2:
            var fileEmployee = File.ReadAllText (path);
            
            var employees = fileEmployee.Split("|");
            

            foreach (var e in employees)
            {
                formatEmployee.FormatMessage(e, (int)MessageTypes.Information);
            }

            break;

        case 3:
            if (!File.Exists(pathJSON))
            {
                var listEmployees = new List<Employee> 
                {
                    new Employee
                    {
                        Id = 1,
                        Name = "Enrique",
                        Occupation = "Team Lead"
                    },
                    new Employee
                    {
                        Id= 2,
                        Name = "Carlos",
                        Occupation = "Senior .NET Developer"
                    },
                    new Employee
                    {
                        Id = 3,
                        Name = "Chuy",
                        Occupation = "SCRUM Master"
                    }
                };

                //var lista2 = new List<Employee>();
                //var employeenuevo = new Employee();
                //employeenuevo.Occupation = "ssss";
                //lista2.Add(employeenuevo);

                // SERIALIZACION ... convertir tu clase a JSON
                // DESERIALIZACION ... convertir un JSON a clase

                string jsonEmployees = JsonConvert.SerializeObject(listEmployees);

                try
                {
                    File.WriteAllText(pathJSON, jsonEmployees);
                }
                catch (Exception ex)
                {

                    formatEmployee.FormatMessage(ex.Message);
                }
                finally
                {
                    formatEmployee.FormatMessage(SUCCESS);
                }
            }
            break;

        case 4:
            if(File.Exists(pathJSON))
            {
                var jsonData = File.ReadAllText(pathJSON);
                List<Employee> listData = JsonConvert.DeserializeObject<List<Employee>>(jsonData);

                listData.ForEach(x => formatEmployee
                .FormatMessage($"{x.Name} - {x.Occupation}", (int)MessageTypes.Information));

                //foreach (var item in listData)
                //{
                //    Console.WriteLine(item.Name + " " + item.Occupation);
                //}
            }

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

void SaveEmployeeNewFile(string path, string format)
{
    StringBuilder sb = new StringBuilder();
    sb.AppendLine(format);

    FileOperations fileOperations = new FileOperations();
    FormatEmployee formatEmployee = new FormatEmployee();

    if (fileOperations.CreateFile(path, sb.ToString()))
    {
        formatEmployee.FormatMessage(SUCCESS);
    }
}

