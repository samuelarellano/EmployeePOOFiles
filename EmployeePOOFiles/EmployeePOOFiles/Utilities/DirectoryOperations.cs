namespace EmployeePOOFiles.Utilities;

// Class for Directory Operations
public class DirectoryOperations : IDirectoryOperations
{
    /// <summary>
    /// Creates the directory.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns></returns>
    /// <exception cref="System.Exception"></exception>
    public bool CreateDirectory(string path)
    {
         if(string.IsNullOrEmpty(path)) return false;

        try
        {
            if(!Directory.Exists(path))
            Directory.CreateDirectory(path);
            return true;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// Removes the directory.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns></returns>
    /// <exception cref="System.Exception">Message: {ex.Message} - HelpLink {ex.HelpLink}</exception>
    public bool RemoveDirectory(string path)
    {
        if(string.IsNullOrEmpty (path)) return false;

        try
        {
            Directory.Delete(path, true);
            return true;
        }
        catch (Exception ex)
        {

            throw new Exception($"Message: {ex.Message} - HelpLink {ex.HelpLink}");
        }
    }
}
