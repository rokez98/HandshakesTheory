using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HandshakesTheory.Models
{
    public class OkUsersInfoRequestMaker: OkRequestMaker
    {
        private static IEnumerable<string> fields = typeof(OkUser).GetProperties().Select(p => p.CustomAttributes.First().ConstructorArguments.First().Value.ToString());
        private string ids;

        protected override string Method { get => "method=users.getInfo"; }
        protected override IEnumerable<string> Parameters { get => fields;  }

        private IEnumerable<long> idList;
        protected override IEnumerable<long> Id { get => idList; }

        public string UsersInfoRequest(IEnumerable<long> id)
        {
            idList = id; 
            return base.MakeRequestUrl();
        }
    }
}
