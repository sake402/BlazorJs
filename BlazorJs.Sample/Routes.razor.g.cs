using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using BlazorJs.Core.Components;
using BlazorJs.Sample.Layout;


namespace BlazorJs.Sample
{
    public partial class Routes : ComponentBase
    {

        protected override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            __frame0.Component<Router>((__component0) =>
            {
                __component0.AppAssembly = typeof(Routes).Assembly;
                __component0.Found = (routeData) => (__frame1, __key1) =>
                {
                        __frame1.Component<RouteView>((__component1) =>
                        {
                            __component1.RouteData = routeData;
                            __component1.DefaultLayout = typeof(Layout.MainLayout);
                        }, key: __key1, sequenceNumber: 1280160589);
                        __frame1.Component<FocusOnNavigate>((__component1) =>
                        {
                            __component1.RouteData = routeData;
                            __component1.Selector = "h1";
                        }, key: __key1, sequenceNumber: 1280160590);
                };
            }, sequenceNumber: 1280160591);
        }

    }
}

