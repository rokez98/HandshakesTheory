using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace HandshakesTheory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var port = Environment.GetEnvironmentVariable("PORT");

            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://*:" + port)
                .Build();
        }
    }
}
