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
            __frame0.Element("Router", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("AppAssembly", typeof(Routes).Assembly);
            }, (__frame1, __key1) =>
            {
                __frame1.Element("Found", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("Context", "routeData");
                }, (__frame2, __key2) =>
                {
                    __frame2.Element("RouteView", (ref UIElementAttribute __attribute) =>
                    {
                        __attribute.Set("RouteData", routeData);
                        __attribute.Set("DefaultLayout", typeof(Layout.MainLayout));
                    }, null, key: __key2, sequenceNumber: 1466719803);
                    __frame2.Element("FocusOnNavigate", (ref UIElementAttribute __attribute) =>
                    {
                        __attribute.Set("RouteData", routeData);
                        __attribute.Set("Selector", "h1");
                    }, null, key: __key2, sequenceNumber: 1466719804);
                }, key: __key1, sequenceNumber: 1466719805);
            }, sequenceNumber: 1466719806);
        }

    }
}

