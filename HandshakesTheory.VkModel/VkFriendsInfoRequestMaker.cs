using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HandshakesTheory.Models
{
    public class VkFriendsInfoRequestMaker : VkRequestMaker
    {
        private static string fields = string.Join(",", typeof(VkUser).GetProperties().Select(p => p.CustomAttributes.First().ConstructorArguments.First().Value));
        private int id;

        protected override string Method { get => "friends.get";}
        protected override string Parameters { get => "fields=" + fields; }
        protected override string Id { get => "user_id=" + id;}

        public string MakeFriendsInfoRequest(int id)
        {
            this.id = id;
            return base.MakeRequestUrl();
        }
    }
}
