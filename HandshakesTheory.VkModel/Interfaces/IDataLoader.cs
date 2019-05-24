using System.Threading.Tasks;

namespace HandshakesTheory.Vk.Interfaces
{
    public interface IDataLoader
    {
        Task<string> DownloadDataAsync(string requestString);
        string DownloadData(string requestString);
    }
}
