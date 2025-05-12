using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using BlazorJs.Core.Components;
using BlazorJs.Sample.Layout;
using System.Collections.Generic;
using System.Text;
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
            __frame0.Component<PageTitle>((__component0) =>
            {

                __component0.ChildContent = (__frame1, __key1) =>
                {
                    __frame1.Text("Counter", key: __key1, sequenceNumber: -755978930);
                };
            }, sequenceNumber: -755978929);
            __frame0.Markup("<h1>Counter</h1>", sequenceNumber: -755978928);
            __frame0.Element("p", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("role", "status");
            }, (__frame1, __key1) =>
            {
                __frame1.Text("Current count: ", key: __key1, sequenceNumber: -755978927);
                __frame1.Content(currentCount, key: __key1, sequenceNumber: -755978926);
            }, sequenceNumber: -755978925);
            __frame0.Element("button", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("class", "btn btn-primary");
                __attribute.Set("@onclick", EventCallback.Factory.Create(this, (Action)IncrementCount));
            }, (__frame1, __key1) =>
            {
                __frame1.Text("Click me +", key: __key1, sequenceNumber: -755978924);
            }, sequenceNumber: -755978923);
            __frame0.Markup("<br>", sequenceNumber: -755978922);
            __frame0.Element("button", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("class", "btn btn-primary");
                __attribute.Set("@onclick", EventCallback.Factory.Create(this, (Action)DecrementCount));
            }, (__frame1, __key1) =>
            {
                __frame1.Text("Click me -", key: __key1, sequenceNumber: -755978921);
            }, sequenceNumber: -755978920);
        }

    }
}

