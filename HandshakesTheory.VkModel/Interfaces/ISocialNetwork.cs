using HandshakesTheory.GraphLibrary.Core;
using HandshakesTheory.Vk.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandshakesTheory.Vk.Interfaces
{

    public interface ISocialNetwork
    {
        LeveledGraph<long, long> BuildUsersSocialGraph(IUser user, TreeType treeType);
        IEnumerable<long> GetUsersIdsOfLevel(LeveledGraph<long, IUser> graph, long level);
        LeveledGraph<long, long> IncreaseDepthOfUsersSocialGraph(LeveledGraph<long, IUser> graph, TreeType treeType);
        IEnumerable<long[]> SearchPathesBetweenUsers(IUser firstUser, IUser secondUser, long maximalDepth);
        Task<string> DownloadUserInfo(long id);
        Dictionary<long, IEnumerable<IUser>> DownloadFriendsIds(IEnumerable<long> userIds);
    }
}
