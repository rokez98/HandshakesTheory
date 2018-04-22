using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GraphLibrary.Models;

namespace HandshakesTheory.Models
{

    public enum TreeType
    {
        Normal,
        Reversed
    }

    public interface ISocialNetwork
    {
        LeveledGraph<long, IUser> BuildUsersSocialGraph(IUser user, TreeType treeType);
        IEnumerable<long> GetUsersIdsOfLevel(LeveledGraph<long, IUser> graph, long level);
        LeveledGraph<long, IUser> IncreaseDepthOfUsersSocialGraph(LeveledGraph<long, IUser> graph, TreeType treeType);
        IEnumerable<IUser[]> SearchPathesBetweenUsers(IUser firstUser, IUser secondUser, long maximalDepth);
        Task<string> DownloadUserInfo(long id);
        Dictionary<long, IEnumerable<IUser>> DownloadFriendsIds(IEnumerable<long> userIds);
    }
}
