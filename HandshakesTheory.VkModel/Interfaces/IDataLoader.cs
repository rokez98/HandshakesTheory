using System.Threading.Tasks;

namespace HandshakesTheory.Models
{
    public interface IDataLoader
    {
        Task<string> DownloadDataAsync(string requestString);
        string DownloadData(string requestString);
    }
}
