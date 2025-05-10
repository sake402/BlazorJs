using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using BlazorJs.Core.Components;
using BlazorJs.Sample.Layout;
using BlazorJs.Core.Components.LiteRouting;


namespace BlazorJs.Sample.Pages
{
    public partial class Home : ComponentBase
    {
        public static void RegisterRoute()
        {
            RouteTableFactory.Register<Home>("/");
        }


        protected override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            __frame0.Element("PageTitle", null, (__frame1, __key1) =>
            {
                __frame1.Text(@"Home", key: __key1, sequenceNumber: -470694347);
            }, sequenceNumber: -470694346);
            __frame0.Element("h1", null, (__frame1, __key1) =>
            {
                __frame1.Text(@"Hello, worlds!", key: __key1, sequenceNumber: -470694345);
            }, sequenceNumber: -470694344);
            __frame0.Text(@"Welcome to your new app.", sequenceNumber: -470694343);
            __frame0.Component<Counter>(null, sequenceNumber: -470694342);
        }

    }
}

