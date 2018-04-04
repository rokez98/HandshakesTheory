using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HandshakesTheory.Models
{
    public class Vk
    {
        public static IVkDataLoader dataLoader = new VkDataLoader();
        public static IVkDataParser dataParser = new VkDataParser();

        static string makeFriendsFullRequestString(int id) => "https://api.vk.com/method/friends.get?v=5.73&fields=photo&user_id=" + id;

        private static Graph<VkUser> BuildUsersSocialGraph(VkUser user, TreeType treeType)
        {
            Graph<VkUser> graph = new Graph<VkUser>();

            SortedSet<int> toDownloadList = new SortedSet<int>();
            toDownloadList.Add(user.Id);

            var friendsOfFriends = Vk.DownloadFriendsIds(toDownloadList);

            foreach (var friendsList in friendsOfFriends)
            {
                var friendId = friendsList.Key;
                var friendsOfFriendIds = friendsList.Value;

                graph.AddNode(user.Id, user, treeType == TreeType.Normal ? 0 : 100);

                foreach (var friend in friendsOfFriendIds)
                {
                    graph.AddNode(friend.Id, friend, treeType == TreeType.Normal ? 1 : 100 - 1);

                    if (treeType == TreeType.Normal)
                        graph.AddLink(friendsList.Key, friend.Id);
                    else
                        graph.AddLink(friend.Id, friendsList.Key);

                    toDownloadList.Add(friend.Id);
                }
            }
            graph.Depth = 1;

            return graph;
        }

        private static Graph<VkUser> IncreaseDepthOfUsersSocialGraph(Graph<VkUser> graph, TreeType treeType)
        {
            var toDownloadList = Vk.getUsersIdsOfLevel(graph, treeType == TreeType.Normal ? graph.Depth : 100 - graph.Depth);

            var friendsOfFriends = Vk.DownloadFriendsIds(toDownloadList);

            foreach (var friendsList in friendsOfFriends)
            {
                var friendId = friendsList.Key;
                var friendsOfFriendIds = friendsList.Value;

                foreach (var friend in friendsOfFriendIds)
                {
                    graph.AddNode(friend.Id, friend, treeType == TreeType.Normal ? graph.Depth + 1 : 100 - graph.Depth - 1);

                    if (treeType == TreeType.Normal)
                        graph.AddLink(friendsList.Key, friend.Id);
                    else
                        graph.AddLink(friend.Id, friendsList.Key);
                }
            }

            graph.Depth++;

            return graph;
        }

        public static Graph<VkUser> BuildSocialGraph(VkUser firstUser, VkUser secondUser, int maximalDepth)
        {
            var normalGraph = Vk.BuildUsersSocialGraph(firstUser, TreeType.Normal);
            var reversedGraph = Vk.BuildUsersSocialGraph(secondUser, TreeType.Reversed);

            int currentDepth = 3;

            while (currentDepth < maximalDepth)
            {
                if (normalGraph.Size < reversedGraph.Size) normalGraph = Vk.IncreaseDepthOfUsersSocialGraph(normalGraph, TreeType.Normal);
                else reversedGraph = Vk.IncreaseDepthOfUsersSocialGraph(reversedGraph, TreeType.Reversed);
                currentDepth++;
            }

            var graph = Graph<VkUser>.Merge(normalGraph, reversedGraph);

            return graph;
        }


        public static IEnumerable<int> getUsersIdsOfLevel(Graph<VkUser> graph, int level) => graph.getNodesOfLevel(level).Select(node => node.Id);

        public static async Task<string> DownloadUserInfo(int id) => await dataLoader.DownloadDataAsync(makeFriendsFullRequestString(id));

        public static Dictionary<int, IEnumerable<VkUser>> DownloadFriendsIds(IEnumerable<int> userIds)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            Dictionary<int, IEnumerable<VkUser>> response = new Dictionary<int, IEnumerable<VkUser>>();

            List<Task> taskList = new List<Task>();
            foreach (var id in userIds)
                taskList.Add(DownloadUserInfo(id).ContinueWith(task => response.Add(id, dataParser.parseUsers(task.Result))));
            Task.WaitAll(taskList.ToArray());

            watch.Stop();


            int numberOfRequests = userIds.Distinct().Count();
            Console.WriteLine($"Time: {(double)watch.ElapsedMilliseconds / 1000} sec;");
            Console.WriteLine($"Total requests: {numberOfRequests};");
            Console.WriteLine($"Avg request time: {(double)watch.ElapsedMilliseconds / (1000 * numberOfRequests)} sec per request;");
            Console.WriteLine($"{((float)1 / 3) / ((double)watch.ElapsedMilliseconds / (1000 * numberOfRequests)) } times faster than Vk Api requests!");
            Console.WriteLine($"-----------------------------------------------------");

            return response;
        }
    }
}
