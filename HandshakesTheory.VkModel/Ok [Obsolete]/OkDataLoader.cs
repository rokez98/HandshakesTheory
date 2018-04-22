using System;
using System.Net;
using System.Threading.Tasks;

namespace HandshakesTheory.Models
{
    public class OkDataLoader : IDataLoader
    {
        public async Task<string> DownloadDataAsync(string requestString)
        {
            using (WebClient client = new WebClient())
            {
                return await client.DownloadStringTaskAsync(new Uri(requestString));
            }
        }

        public string DownloadData(string requestString)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(new Uri(requestString));
            }
        }

    }
}
