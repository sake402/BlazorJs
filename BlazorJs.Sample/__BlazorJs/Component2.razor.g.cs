using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using BlazorJs.Core.Components;
using BlazorJs.Sample.Layout;
using System.Collections.Generic;
using System.Text;
using BlazorJs.Core.Components.LiteRouting;


namespace BlazorJs.Sample
{
    public partial class Component2 : ComponentBase
    {
        public static void RegisterRoute()
        {
            RouteTableFactory.Register<Component2>("/C2");
        }

        protected override void CascadeParameters()
        {
            RequestCascadingParameter<BlazorJs.Sample.Component1>(e => C1 = e, cascadingParameterName: "C1");
            base.CascadeParameters();
        }


        protected override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            __frame0.Markup("<a href=\"/\">Component2</a>", sequenceNumber: 859351914);
            __frame0.Element("div", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("class", "def");
            }, (__frame1, __key1) =>
            {
                __frame1.Content(Property1, key: __key1, sequenceNumber: 859351915);
                __frame1.Text("    ", key: __key1, sequenceNumber: 859351916);
                __frame1.Element("span", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("class", "def");
                }, (__frame2, __key2) =>
                {
                    __frame2.Content(Property2, key: __key2, sequenceNumber: 859351917);
                    __frame2.Text("    ", key: __key2, sequenceNumber: 859351918);
                }, key: __key1, sequenceNumber: 859351919);
                __frame1.Content(ChildContent?.Invoke("abc"), key: __key1, sequenceNumber: 859351920);
            }, sequenceNumber: 859351921);
            __frame0.Content(Property3, sequenceNumber: 859351922);
            __frame0.Content(Property4, sequenceNumber: 859351923);
        }

    }
}

