using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary.Models;

namespace HandshakesTheory.Models
{
    public abstract class SocialNetwork : ISocialNetwork
    {
        protected abstract IDataLoader dataLoader { get; set; }
        protected abstract IRequestMaker requestMaker { get; set; }
        protected abstract IDataParser dataParser { get; set; }

        public LeveledGraph<long, IUser> BuildUsersSocialGraph(IUser user, TreeType treeType)
        {
            LeveledGraph<long, IUser> graph = new LeveledGraph<long, IUser>();

            SortedSet<long> toDownloadList = new SortedSet<long>();
            toDownloadList.Add(user.Id);

            var friendsOfFriends = DownloadFriendsIds(toDownloadList);

            foreach (var friendsList in friendsOfFriends)
            {
                var friendId = friendsList.Key;
                var friendsOfFriendIds = friendsList.Value;

                graph.AddVertex(user.Id, user, treeType == TreeType.Normal ? 0 : 100);

                foreach (var friend in friendsOfFriendIds)
                {
                    graph.AddVertex(friend.Id, friend, treeType == TreeType.Normal ? 1 : 100 - 1);

                    if (treeType == TreeType.Normal) graph.AddEdge(friendsList.Key, friend.Id);
                    else graph.AddEdge(friend.Id, friendsList.Key);

                    toDownloadList.Add(friend.Id);
                }
            }
            graph.Depth = 1;

            return graph;
        }

        public IEnumerable<long> GetUsersIdsOfLevel(LeveledGraph<long, IUser> graph, long level) => graph.GetVertexesOfLevel(level).Select(node => node.Id);

        public LeveledGraph<long, IUser> IncreaseDepthOfUsersSocialGraph(LeveledGraph<long, IUser> graph, TreeType treeType)
        {
            var toDownloadList = GetUsersIdsOfLevel(graph, treeType == TreeType.Normal ? graph.Depth : 100 - graph.Depth);

            var friendsOfFriends = DownloadFriendsIds(toDownloadList);

            foreach (var friendsList in friendsOfFriends)
            {
                var friendId = friendsList.Key;
                var friendsOfFriendIds = friendsList.Value;

                foreach (var friend in friendsOfFriendIds)
                {
                    graph.AddVertex(friend.Id, friend, treeType == TreeType.Normal ? graph.Depth + 1 : 100 - graph.Depth - 1);

                    if (treeType == TreeType.Normal)
                        graph.AddEdge(friendsList.Key, friend.Id);
                    else
                        graph.AddEdge(friend.Id, friendsList.Key);
                }
            }
            graph.Depth++;

            return graph;
        }

        public IEnumerable<IUser[]> SearchPathesBetweenUsers(IUser firstUser, IUser secondUser, long maximalDepth)
        {
            PathSearcherContext<long, IUser> searchContext = new PathSearcherContext<long, IUser>(new DfsSearcher<long, IUser>());

            var normalGraph = BuildUsersSocialGraph(firstUser, TreeType.Normal);
            var reversedGraph = BuildUsersSocialGraph(secondUser, TreeType.Reversed);

            IEnumerable<IUser[]> allPathes = new List<IUser[]>();

            long currentDepth = 3;

            while (!(allPathes = searchContext.Search(LeveledGraph<long, IUser>.Merge(normalGraph, reversedGraph), firstUser.Id, secondUser.Id)).Any() && currentDepth++ < maximalDepth)
            {
                if (normalGraph.Size < reversedGraph.Size) normalGraph = IncreaseDepthOfUsersSocialGraph(normalGraph, TreeType.Normal);
                else reversedGraph = IncreaseDepthOfUsersSocialGraph(reversedGraph, TreeType.Reversed);
            }

            return allPathes;
        }

        public async Task<string> DownloadUserInfo(long id) => await dataLoader.DownloadDataAsync((requestMaker as VkFriendsInfoRequestMaker).MakeFriendsInfoRequest(id));

        public abstract Dictionary<long, IEnumerable<IUser>> DownloadFriendsIds(IEnumerable<long> userIds);
    }
}
