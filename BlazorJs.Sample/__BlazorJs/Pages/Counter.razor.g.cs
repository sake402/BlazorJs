using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Text;
using BlazorJs.Core.Components;
using BlazorJs.Sample.Layout;
using BlazorJs.Core.Components.LiteRouting;


namespace BlazorJs.Sample.Pages
{
    [RenderModeServer]
    public partial class Counter : ComponentBase
    {
        public static void RegisterRoute()
        {
            RouteTableFactory.Register<Counter>("/counter");
        }


        protected override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            __frame0.Element("PageTitle", null, (__frame1, __key1) =>
            {
                __frame1.Text(@"Counter", key: __key1, sequenceNumber: -1309408867);
            }, sequenceNumber: -1309408866);
            __frame0.Element("h1", null, (__frame1, __key1) =>
            {
                __frame1.Text(@"Counter", key: __key1, sequenceNumber: -1309408865);
            }, sequenceNumber: -1309408864);
            __frame0.Element("p", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("role", "status");
            }, (__frame1, __key1) =>
            {
                __frame1.Text(@"Current count: ", key: __key1, sequenceNumber: -1309408863);
                __frame1.Content(currentCount, key: __key1, sequenceNumber: -1309408862);
            }, sequenceNumber: -1309408861);
            __frame0.Element("button", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("class", "btn btn-primary");
                __attribute.Set("@onclick", EventCallback.Factory.Create(this, (Action)IncrementCount));
            }, (__frame1, __key1) =>
            {
                __frame1.Text(@"Click me +", key: __key1, sequenceNumber: -1309408860);
            }, sequenceNumber: -1309408859);
            __frame0.Element("br", null, null, sequenceNumber: -1309408858);
            __frame0.Element("button", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("class", "btn btn-primary");
                __attribute.Set("@onclick", EventCallback.Factory.Create(this, (Action)DecrementCount));
            }, (__frame1, __key1) =>
            {
                __frame1.Text(@"Click me -", key: __key1, sequenceNumber: -1309408857);
            }, sequenceNumber: -1309408856);
        }

    }
}

