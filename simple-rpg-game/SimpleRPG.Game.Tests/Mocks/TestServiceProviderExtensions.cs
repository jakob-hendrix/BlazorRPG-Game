using Blazorise;
using Blazorise.Bootstrap;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace SimpleRPG.Game.Tests.Mocks
{
    public static class TestServiceProviderExtensions
    {
        public static void AddBlazoriseServices(this TestServiceProvider services)
        {
            services.AddSingleton<IClassProvider>(new BootstrapClassProvider());
            services.AddSingleton<IStyleProvider>(new BootstrapStyleProvider());
            services.AddSingleton<IJSRunner>(new BootstrapJSRunner(new MockJSRuntime()));
            services.AddSingleton<IJSRuntime>(new MockJSRuntime());
            services.AddSingleton<IComponentMapper>(new ComponentMapper());
            services.AddSingleton<IThemeGenerator>(new BootstrapThemeGenerator());
            services.AddSingleton<IIconProvider>(new MockIconProvider());
            services.AddSingleton(new BlazoriseOptions());
        }
    }
}
