using Microsoft.Extensions.Configuration;

namespace HandshakesTheory.VkModel.Requests
{
    public abstract class Request
    {
        protected readonly IConfiguration _configuration;

        protected string Site { get => _configuration["Vk:ApiUrl"]; }
        protected string AccessToken { get => _configuration["Vk:AccessToken"]; }
        protected string ApiVersion { get => _configuration["Vk:ApiVersion"]; }

        public Request(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public abstract string GetRequestUrl();
    }
}