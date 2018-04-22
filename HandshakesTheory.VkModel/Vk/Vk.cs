using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GraphLibrary.Models;

namespace HandshakesTheory.Models
{
    public class Vk : SocialNetwork
    {
        protected override IDataLoader dataLoader { get; set; } =  new VkDataLoader();
        protected override IRequestMaker requestMaker { get; set; } = new VkFriendsInfoRequestMaker();
        protected override IDataParser dataParser { get; set; } = new VkDataParser();

        public async Task<string> DownloadUserInfo(long id) => await dataLoader.DownloadDataAsync((requestMaker as VkFriendsInfoRequestMaker).MakeFriendsInfoRequest(id));

        public override Dictionary<long, IEnumerable<IUser>> DownloadFriendsIds(IEnumerable<long> userIds)
        {
            VkDataParser dataParser = new VkDataParser();
            Stopwatch watch = new Stopwatch();
            watch.Start();

            Dictionary<long, IEnumerable<IUser>> response = new Dictionary<long, IEnumerable<IUser>>();

            List<Task> taskList = new List<Task>();
            foreach (var id in userIds)
                taskList.Add(DownloadUserInfo(id).ContinueWith(task => response.Add(id, dataParser.ParseData<VkUser>(task.Result))));
            Task.WaitAll(taskList.ToArray());

            watch.Stop();


            long numberOfRequests = userIds.Distinct().Count();
            Console.WriteLine($"Time: {(double)watch.ElapsedMilliseconds / 1000} sec;");
            Console.WriteLine($"Total requests: {numberOfRequests};");
            Console.WriteLine($"Avg request time: {(double)watch.ElapsedMilliseconds / (1000 * numberOfRequests)} sec per request;");
            Console.WriteLine($"{((float)1 / 3) / ((double)watch.ElapsedMilliseconds / (1000 * numberOfRequests)) } times faster than Vk Api requests!");
            Console.WriteLine($"-----------------------------------------------------");

            return response;
        }
    }
}
