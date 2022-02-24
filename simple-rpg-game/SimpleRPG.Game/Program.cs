using Blazorise;
using Blazorise.Bootstrap;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG.Game
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services
                .AddBlazorise(options =>
                {
                    options.ChangeTextOnKeyPress = false;
                })
                .AddBootstrapProviders();

            builder.RootComponents.Add<App>("app");
            builder.Services.
                AddTransient(sp => new HttpClient
                {
                    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
                });

            var host = builder.Build();

            host.Services
                .UseBootstrapProviders();

            await host.RunAsync();
        }
    }
}
