using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using BlazorJs.Core.Components;
using BlazorJs.Sample.Layout;


namespace BlazorJs.Sample.Layout
{
    public partial class MainLayout : LayoutComponentBase
    {

        protected override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            __frame0.Element("div", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("class", "page");
            }, (__frame1, __key1) =>
            {
                __frame1.Element("div", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("class", "sidebar");
                }, (__frame2, __key2) =>
                {
                    __frame2.Component<NavMenu>(null, key: __key2, sequenceNumber: -2100937643);
                }, key: __key1, sequenceNumber: -2100937642);
                __frame1.Element("main", null, (__frame2, __key2) =>
                {
                    __frame2.Element("div", (ref UIElementAttribute __attribute) =>
                    {
                        __attribute.Set("class", "top-row px-4");
                    }, (__frame3, __key3) =>
                    {
                        __frame3.Element("a", (ref UIElementAttribute __attribute) =>
                        {
                            __attribute.Set("href", "https://learn.microsoft.com/aspnet/core/");
                            __attribute.Set("target", "_blank");
                        }, (__frame4, __key4) =>
                        {
                            __frame4.Text(@"About", key: __key4, sequenceNumber: -2100937641);
                        }, key: __key3, sequenceNumber: -2100937640);
                    }, key: __key2, sequenceNumber: -2100937639);
                    __frame2.Element("article", (ref UIElementAttribute __attribute) =>
                    {
                        __attribute.Set("class", "content px-4");
                    }, (__frame3, __key3) =>
                    {
                        __frame3.Content(Body, key: __key3, sequenceNumber: -2100937638);
                        __frame3.Text(@"        ", key: __key3, sequenceNumber: -2100937637);
                    }, key: __key2, sequenceNumber: -2100937636);
                }, key: __key1, sequenceNumber: -2100937635);
            }, sequenceNumber: -2100937634);
            __frame0.Element("div", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("id", "blazor-error-ui");
            }, (__frame1, __key1) =>
            {
                __frame1.Text(@"An unhandled error has occurred.
    ", key: __key1, sequenceNumber: -2100937633);
                __frame1.Element("a", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("href", "");
                    __attribute.Set("class", "reload");
                }, (__frame2, __key2) =>
                {
                    __frame2.Text(@"Reload", key: __key2, sequenceNumber: -2100937632);
                }, key: __key1, sequenceNumber: -2100937631);
                __frame1.Element("a", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("class", "dismiss");
                }, (__frame2, __key2) =>
                {
                    __frame2.Text(@"🗙", key: __key2, sequenceNumber: -2100937630);
                }, key: __key1, sequenceNumber: -2100937629);
            }, sequenceNumber: -2100937628);
        }

    }
}

