using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Text;
using BlazorJs.Core.Components;
using BlazorJs.Sample.Layout;
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
            __frame0.Element("a", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("href", "/");
            }, (__frame1, __key1) =>
            {
                __frame1.Text(@"Component2", key: __key1, sequenceNumber: 567999794);
            }, sequenceNumber: 567999795);
            __frame0.Element("div", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("class", "def");
            }, (__frame1, __key1) =>
            {
                __frame1.Content(Property1, key: __key1, sequenceNumber: 567999796);
                __frame1.Text(@"    ", key: __key1, sequenceNumber: 567999797);
                __frame1.Element("span", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("class", "def");
                }, (__frame2, __key2) =>
                {
                    __frame2.Content(Property2, key: __key2, sequenceNumber: 567999798);
                    __frame2.Text(@"    ", key: __key2, sequenceNumber: 567999799);
                }, key: __key1, sequenceNumber: 567999800);
                __frame1.Content(ChildContent?.Invoke("abc"), key: __key1, sequenceNumber: 567999801);
            }, sequenceNumber: 567999802);
            __frame0.Content(Property3, sequenceNumber: 567999803);
            __frame0.Content(Property4, sequenceNumber: 567999804);
        }

    }
}

