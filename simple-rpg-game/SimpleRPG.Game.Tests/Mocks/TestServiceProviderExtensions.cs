using Blazorise;
using Blazorise.Bootstrap;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Moq;

namespace SimpleRPG.Game.Tests.Mocks
{
    public static class TestServiceProviderExtensions
    {
        public static void AddBlazoriseServices(this TestServiceProvider services)
        {
            var mockJsRuntime = new Mock<IJSRuntime>().Object;
            var mockIconProvider = new Mock<IIconProvider>().Object;

            services.AddSingleton<IClassProvider>(new BootstrapClassProvider());
            services.AddSingleton<IStyleProvider>(new BootstrapStyleProvider());
            services.AddSingleton<IJSRunner>(new BootstrapJSRunner(mockJsRuntime));
            services.AddSingleton(mockJsRuntime);
            services.AddSingleton<IComponentMapper>(new ComponentMapper());
            services.AddSingleton<IThemeGenerator>(new BootstrapThemeGenerator());
            services.AddSingleton(mockIconProvider);
            services.AddSingleton(new BlazoriseOptions());
        }
    }
}
