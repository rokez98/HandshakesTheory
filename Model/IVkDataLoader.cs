using System.Threading.Tasks;

namespace TestVkApi
{
    public interface IVkDataLoader
    {
        Task<string> DownloadDataAsync(string requestString);
        string DownloadData(string requestString);
    }
}
