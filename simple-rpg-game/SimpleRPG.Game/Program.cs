using Blazorise;
using Blazorise.Bootstrap;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleRPG.Game.Engine.ViewModels;
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

            ConfigureAppServices(builder.Services);
            
            var host = builder.Build();

            InitializeAppServices(host.Services);

            await host.RunAsync();
        }

        private static void ConfigureAppServices(IServiceCollection services)
        {
            /*  Scoped: 
             *      Blazor WebAssembly apps don’t currently have a concept of DI scopes. 
             *      Scoped - registered services behave like Singleton services.However, 
             *      the Blazor Server hosting model supports the Scoped lifetime.In Blazor Server apps, 
             *      a scoped service registration is scoped to the connection. For this reason, using 
             *      scoped services is preferred for services that should be scoped to the current user, 
             *      even if the current intent is to run client - side in the browser.
             *      
             *  Singleton: 
             *      DI creates a single instance of the service. All components requiring a Singleton 
             *      service receive an instance of the same service.
             *      
             *  Transient: 
             *      Whenever a component obtains an instance of a Transient service from the service container, 
             *      it receives a new instance of the service.
             */

            services.AddSingleton<GameSession>();
        }

        private static void InitializeAppServices(IServiceProvider services)
        {
            services.UseBootstrapProviders();
        }
    }
}
