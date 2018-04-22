using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GraphLibrary.Models;

namespace HandshakesTheory.Models
{
    public class Ok : SocialNetwork
    {
        protected override IDataLoader dataLoader { get; set; } = new OkDataLoader();
        protected override IRequestMaker requestMaker { get; set; } = new OkUsersInfoRequestMaker();
        protected override IDataParser dataParser { get; set; } = new OkDataParser();

        public async Task<string> DownloadUserInfo(long id)
        {
            string url = (requestMaker as OkUsersInfoRequestMaker).UsersInfoRequest(new List<long> { id });

            Console.WriteLine(url);

            return await dataLoader.DownloadDataAsync(url);
        }

        public async Task<string> DownloadUsersFriendsId(long id)
        {
            string url = new OkFriendsInfoRequestMaker().FriendsIdsUrl(id, 571243855757);

            //(new List<long> { id });

            Console.WriteLine(url);

            return await dataLoader.DownloadDataAsync(url);
        }

        public override Dictionary<long, IEnumerable<IUser>> DownloadFriendsIds(IEnumerable<long> userIds)
        {
            OkDataParser dataParser = new OkDataParser();
            Stopwatch watch = new Stopwatch();
            watch.Start();

            SortedSet<long> friendsIds = new SortedSet<long>();
            Dictionary<long, IEnumerable<IUser>> response = new Dictionary<long, IEnumerable<IUser>>();

            List<Task> getFriendsTaskList = new List<Task>();
            foreach (var id in userIds)
                getFriendsTaskList.Add(DownloadUsersFriendsId(id).ContinueWith(task =>
                {
                    long userId = id;
                    var res = dataParser.ParseValue<long>(task.Result);
                    foreach (var s in res)
                        friendsIds.Add((long)s);

                    List<Task> taskList = new List<Task>();
                    foreach (var friendId in friendsIds)
                        taskList.Add(DownloadUserInfo(friendId).ContinueWith(t => {
                            if (response.ContainsKey(userId)) Console.Write("Lol");
                            else response.Add(userId, dataParser.ParseData<OkUser>(t.Result));
                         }));
                    Task.WaitAll(taskList.ToArray());
                }
                ));
            Task.WaitAll(getFriendsTaskList.ToArray());



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
