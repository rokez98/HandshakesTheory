using System.Threading.Tasks;

namespace HandshakesTheory.Models
{
    public interface IVkDataLoader
    {
        Task<string> DownloadDataAsync(string requestString);
        string DownloadData(string requestString);
    }
}
