namespace EmployeePOOFiles.Utilities;

internal class FileOperations : IFileOperations
{
    /// <summary>
/// Creates the file.
/// </summary>
/// <param name="path">The path.</param>
/// <param name="sb">The sb.</param>
/// <returns>Return a boolean</returns>
/// <exception cref="System.Exception"></exception>
    public bool CreateFile(string path, string sb)
    {
        if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(sb.ToString())) return false;
        try
        { 
            File.WriteAllText(path,sb);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

        return true;

    }

    /// <summary>
    /// Deletes the file.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>Return a boolean</returns>
    /// <exception cref="Exception">ex.Message</exception>
    public bool DeleteFile(string path)
    {
        if (string.IsNullOrEmpty(path)) return false;
        try
        {
            File.Delete(path);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

        return true;
    }
}
