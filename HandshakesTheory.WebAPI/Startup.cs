using AutoMapper;
using HandshakesTheory.GraphLibrary.Core;
using HandshakesTheory.GraphLibrary.Interfaces;
using HandshakesTheory.Vk.Core;
using HandshakesTheory.Vk.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HandshakesTheory
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddNewtonsoftJson(options =>
                {
                    if (options.SerializerSettings.ContractResolver != null)
                    {
                        var resolver = options.SerializerSettings.ContractResolver as DefaultContractResolver;
                        resolver.NamingStrategy = null;
                    }

                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services.AddScoped<IDataLoader, DataLoader>();

            services.AddScoped(typeof(IPathSearcher<,>), typeof(DfsPathSearcher<,>));

            services.AddScoped<VkNetwork>();

            services.AddAutoMapper();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHsts();

            if (env.EnvironmentName == "Delelopment")
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
