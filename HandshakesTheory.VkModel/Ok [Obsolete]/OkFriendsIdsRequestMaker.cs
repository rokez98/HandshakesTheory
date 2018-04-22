using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace HandshakesTheory.Models
{
    public class OkFriendsInfoRequestMaker : OkRequestMaker
    {
        private static IEnumerable<string> fields = typeof(OkUser).GetProperties().Select(p => p.CustomAttributes.First().ConstructorArguments.First().Value.ToString());
        private string ids;

        protected override string Method { get => "method=friends.get"; }
        protected override IEnumerable<string> Parameters { get => fields; }

        private IEnumerable<long> idList;
        protected override IEnumerable<long> Id { get => idList; }


        long fid;
        long uid;

        public string FriendsIdsUrl(long fid, long uid)
        {
            this.fid = fid;
            this.uid = uid;
            return MakeRequestUrl();
        }

        protected override string sig()
        {
            string s = appKey + "fid=" + fid + format + Method + "uid=" + uid + appSecret;

            string res = GetMd5Hash(MD5.Create(), s);

            return "sig=" + res;
        }

        public override string MakeRequestUrl()
        {
            return Site + '?' + appKey + '&' + "fid=" + fid + '&' + format + '&' + Method + '&' + "uid=" + uid + '&' + sig();
        }
    }
}

