namespace EmployeePOOFiles.Utilities;

public class FormatEmployee : IFormatterEmployee
{
    public string Format(Employee employee)
    {
        return $"Name:{employee.Name};Occupation:{employee.Occupation};|";
    }

    public void FormatMessage(string message, int option = 1)
    {
        switch (option)
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Green;
                break;

            case 2:
                Console.ForegroundColor = ConsoleColor.Red;
                break;

            case 3:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;

            case 4:
                Console.ForegroundColor = ConsoleColor.Blue;
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
        }

        Console.WriteLine(message);
        Console.ResetColor();
    }
}
