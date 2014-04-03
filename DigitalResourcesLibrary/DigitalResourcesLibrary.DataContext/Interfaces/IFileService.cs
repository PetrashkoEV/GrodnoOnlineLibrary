namespace DigitalResourcesLibrary.DataContext.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Returns binary file
        /// </summary>
        /// <param name="id">Id file in database</param>
        /// <returns></returns>
        byte[] СontentFile(int id);
    }
}