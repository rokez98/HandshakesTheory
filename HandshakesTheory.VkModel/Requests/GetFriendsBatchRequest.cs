using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace HandshakesTheory.VkModel.Requests
{

    public class GetFriendsBatchRequest : Request
    {
        public IEnumerable<long> UserIds { get; set; }

        public GetFriendsBatchRequest(IConfiguration configuration) : base(configuration) { }

        protected string Method { get => "execute.getFriendsBatch"; }
        protected string Parameters { get => $"users={string.Join(',', UserIds)}"; }

        public override string GetRequestUrl()
        {
            return $"{Site}/method/{Method}?v={ApiVersion}&access_token={AccessToken}&{Parameters}";
        }
    }
}