using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

/*
 https://api.ok.ru/fb.do?application_key=CBAKGEHMEBABABABA&fields=pic50x50%2Cfirst_name&format=json&method=users.getInfo&uids=571243855757%2C581855721997%2C554107747844&sig=ebb48142b490c5399d8bbd98fc4ff8ee
*/

namespace HandshakesTheory.Models
{
    public abstract class OkRequestMaker : IRequestMaker
    {
        protected string Site { get; } = "https://api.ok.ru/fb.do";
        protected string appKey = "application_key=CBAKGEHMEBABABABA";
        protected string format = "format=json";

        protected string appSecret = "16DA5BE97C2FE4CCE1E00559";

        protected abstract string Method { get; }
        protected abstract IEnumerable<string> Parameters { get; }
        protected abstract IEnumerable<long> Id { get; }


        protected string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        protected virtual string  sig() {
            string s = appKey + "fields=" + String.Join(",", Parameters) + format + Method + "uids=" + String.Join(",",Id) + appSecret;

            string res = GetMd5Hash(MD5.Create(), s);

            return "sig=" + res;
        }


        public virtual string MakeRequestUrl()
        {
            return Site + '?' + appKey + '&' + "fields=" + String.Join("%2C",Parameters) + '&' + format + '&' + Method + '&' + "uids=" + String.Join("%2C", Id) + '&' + sig();
        }
    }
}
