using HandshakesTheory.GraphLibrary.Interfaces;
using HandshakesTheory.Vk.Extensions;
using HandshakesTheory.Vk.Interfaces;
using HandshakesTheory.Vk.Models;
using HandshakesTheory.VkModel.Models;
using HandshakesTheory.VkModel.Requests;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandshakesTheory.Vk.Core
{
    public class VkNetwork : SocialNetwork
    {
        protected readonly IConfiguration _configuration;

        protected override IDataLoader dataLoader { get; set; }

        public VkNetwork(IDataLoader dataLoader, IConfiguration configuration, IPathSearcher<long, long> pathSearcher) : base(pathSearcher)
        {
            this.dataLoader = dataLoader;
            _configuration = configuration;
        }

        private async Task<string> DownloadUsersFriendsAsync(List<long> ids)
        {
            var request = new GetFriendsBatchRequest(_configuration)
            {
                UserIds = ids
            };

            return await dataLoader.DownloadDataAsync(request.GetRequestUrl());
        }

        public async Task<string> DownloadBatchUserDetails(List<long> ids)
        {
            var request = new GetDetailsBatchRequest(_configuration)
            {
                UserIds = ids
            };

            return await dataLoader.DownloadDataAsync(request.GetRequestUrl());
        }

        public override IEnumerable<IUser[]> DetalizePathes(IEnumerable<long[]> pathes)
        {
            var userIds = pathes.SelectMany(x => x).Distinct().ToList();
            var batches = userIds.Split(25);

            var users = new Dictionary<long, IUser>();

            var taskList = new List<Task>();
            foreach (var batch in batches)
                taskList.Add(DownloadBatchUserDetails(batch).ContinueWith(task =>
                {
                    var responseSection = JToken.Parse(task.Result)["response"];
                    if (responseSection == null)
                    {
                        while (responseSection == null)
                        {
                            responseSection = JToken.Parse(DownloadBatchUserDetails(batch).Result)["response"];
                        }
                    }

                    var result = JsonConvert.DeserializeObject<List<VkUser>>(responseSection.ToString());
                    result.ForEach(r => users.Add(r.Id, r));
                }));
            Task.WaitAll(taskList.ToArray());

            var details = pathes.Select(p => p.Select(id => users[id]).ToArray());

            return details;
        }

        public override Dictionary<long, IEnumerable<long>> DownloadFriendsIds(IEnumerable<long> userIds)
        {
            var response = new Dictionary<long, IEnumerable<long>>();

            var batches = userIds.ToList().Split(25);

            var taskList = new List<Task>();
            foreach (var batch in batches)
                taskList.Add(DownloadUsersFriendsAsync(batch).ContinueWith(task =>
                {
                    var responseSection = JToken.Parse(task.Result)["response"];
                    if (responseSection == null)
                    {
                        while (responseSection == null)
                        {
                            responseSection = JToken.Parse(DownloadUsersFriendsAsync(batch).Result)["response"];
                        }
                    }

                    var result = JsonConvert.DeserializeObject<List<GetFriendsBatchResponseModel>>(responseSection.ToString());
                    result.ForEach(r => response.Add(r.UserId, r.Friends ?? new long[0]));
                }));
            Task.WaitAll(taskList.ToArray());


            return response;
        }
    }
}
