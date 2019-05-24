using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace HandshakesTheory.VkModel.Requests
{
    public class GetDetailsBatchRequest : Request
    {
        public IEnumerable<long> UserIds { get; set; }

        public GetDetailsBatchRequest(IConfiguration configuration) : base(configuration) { }

        protected string Method { get => "execute.getDetailsBatch"; }
        protected string Parameters { get => $"users={string.Join(',', UserIds)}"; }

        public override string GetRequestUrl()
        {
            return $"{Site}/method/{Method}?v={ApiVersion}&access_token={AccessToken}&{Parameters}";
        }
    }
}