namespace HandshakesTheory.Models
{
    public abstract class VkRequestMaker : IRequestMaker
    {
        string Site { get; } = "https://api.vk.com/method";
        protected abstract string Method { get; }
        protected abstract string Parameters { get; }
        protected virtual string ApiVersion { get => "v=" + "5.74"; }
        protected abstract string Id { get; }

        public string MakeRequestUrl()
        {
            return Site + '/' + Method + '?' + ApiVersion + '&' + Parameters + '&' + Id;
        }
    }
}
 