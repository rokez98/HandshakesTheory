using HandshakesTheory.GraphLibrary.Core;
using HandshakesTheory.GraphLibrary.Interfaces;
using HandshakesTheory.Vk.Enums;
using HandshakesTheory.Vk.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HandshakesTheory.Vk.Core
{
    public abstract class SocialNetwork //: ISocialNetwork
    {
        protected abstract IDataLoader dataLoader { get; set; }
        protected readonly IPathSearcher<long, long> _pathSearcher;

        public SocialNetwork(IPathSearcher<long, long> pathSearcher)
        {
            _pathSearcher = pathSearcher;
        }

        public LeveledGraph<long, long> BuildUsersSocialGraph(IUser user, TreeType treeType)
        {
            var graph = new LeveledGraph<long, long>();

            var downloadQueue = new SortedSet<long>();
            downloadQueue.Add(user.Id);

            var friendsOfFriends = DownloadFriendsIds(downloadQueue);

            foreach (var friendsList in friendsOfFriends)
            {
                var friendId = friendsList.Key;
                var friendsOfFriend = friendsList.Value;

                graph.AddVertex(user.Id, user.Id, treeType == TreeType.Normal ? 0 : 100);

                foreach (var friend in friendsOfFriend)
                {
                    graph.AddVertex(friend, friend, treeType == TreeType.Normal ? 1 : 100 - 1);

                    if (treeType == TreeType.Normal) graph.AddEdge(friendsList.Key, friend);
                    else graph.AddEdge(friend, friendsList.Key);

                    downloadQueue.Add(friend);
                }
            }
            graph.Depth = 1;

            return graph;
        }

        public IEnumerable<long> GetUsersIdsOfLevel(LeveledGraph<long, long> graph, long level) => graph.GetVertexesOfLevel(level);

        public LeveledGraph<long, long> IncreaseDepthOfUsersSocialGraph(LeveledGraph<long, long> graph, TreeType treeType)
        {
            var toDownloadList = GetUsersIdsOfLevel(graph, treeType == TreeType.Normal ? graph.Depth : 100 - graph.Depth);

            var friendsOfFriends = DownloadFriendsIds(toDownloadList);

            foreach (var friendsList in friendsOfFriends)
            {
                var friendId = friendsList.Key;
                var friendsOfFriendIds = friendsList.Value;

                foreach (var friend in friendsOfFriendIds)
                {
                    graph.AddVertex(friend, friend, treeType == TreeType.Normal ? graph.Depth + 1 : 100 - graph.Depth - 1);

                    if (treeType == TreeType.Normal)
                        graph.AddEdge(friendsList.Key, friend);
                    else
                        graph.AddEdge(friend, friendsList.Key);
                }
            }
            graph.Depth++;

            return graph;
        }

        public IEnumerable<IUser[]> SearchPathesBetweenUsers(IUser firstUser, IUser secondUser, long maximalDepth)
        {
            PathSearcherContext<long, long> searchContext = new PathSearcherContext<long, long>(new DfsPathSearcher<long, long>());

            var normalGraph = BuildUsersSocialGraph(firstUser, TreeType.Normal);
            var reversedGraph = BuildUsersSocialGraph(secondUser, TreeType.Reversed);

            IEnumerable<long[]> allPathes = new List<long[]>();

            long currentDepth = 3;

            while (!(allPathes = searchContext.Search(LeveledGraph<long, long>.Merge(normalGraph, reversedGraph), firstUser.Id, secondUser.Id)).Any() && currentDepth++ < maximalDepth)
            {
                if (normalGraph.Size < reversedGraph.Size) normalGraph = IncreaseDepthOfUsersSocialGraph(normalGraph, TreeType.Normal);
                else reversedGraph = IncreaseDepthOfUsersSocialGraph(reversedGraph, TreeType.Reversed);
            }

            var detalized = DetalizePathes(allPathes);

            return detalized;
        }

        public abstract Dictionary<long, IEnumerable<long>> DownloadFriendsIds(IEnumerable<long> userIds);

        public abstract IEnumerable<IUser[]> DetalizePathes(IEnumerable<long[]> pathes);
    }
}
