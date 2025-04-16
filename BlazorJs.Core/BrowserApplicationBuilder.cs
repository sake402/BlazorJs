using System;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.DependencyInjection;
using BlazorJs.ServiceProvider;

namespace BlazorJs.Core
{
    public partial class BrowserApplicationBuilder
    {
        internal BrowserServiceProvider Services { get; }
        internal BrowserNativeRenderer Renderer { get; }
        internal BrowserNativeNavigationManager NavigationManager { get; }
        public HttpClient Http { get; }
        public BrowserApplicationBuilder()
        {
            Services = new BrowserServiceProvider();
            Renderer = new BrowserNativeRenderer(Services);
            NavigationManager = new BrowserNativeNavigationManager();
            Http = new HttpClient();
            Services.AddSingleton<IServiceProvider>(Services);
            Services.AddSingleton(NavigationManager)
                .AddSingleton<NavigationManager>(NavigationManager)
                .AddSingleton<INavigationInterception>(NavigationManager);
            Services.AddSingleton(Http);
        }

        public static BrowserApplicationBuilder Create(Action<BrowserApplicationBuilder> build = null)
        {
            var app = new BrowserApplicationBuilder();
            build?.Invoke(app);
            return app;
        }
        public static BrowserApplicationBuilder Create<TRootComponent>(Action<BrowserApplicationBuilder> build = null, Action<TRootComponent> buildComponent = null) where TRootComponent : IComponent
        {
            var app = new BrowserApplicationBuilder();
            app.Renderer.Add<TRootComponent>(buildComponent);
            build?.Invoke(app);
            return app;
        }
    }
}
