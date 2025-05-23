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
                    __frame2.Component<NavMenu>(null, key: __key2, sequenceNumber: -2046624287);
                }, key: __key1, sequenceNumber: -2046624286);
                __frame1.Element("main", null, (__frame2, __key2) =>
                {
                    __frame2.Markup("<div class=\"top-row px-4\">\r\n            <a href=\"https://learn.microsoft.com/aspnet/core/\" target=\"_blank\">About</a>\r\n        </div>", key: __key2, sequenceNumber: -2046624285);
                    __frame2.Element("article", (ref UIElementAttribute __attribute) =>
                    {
                        __attribute.Set("class", "content px-4");
                    }, (__frame3, __key3) =>
                    {
                        __frame3.Content(Body, key: __key3, sequenceNumber: -2046624284);
                        __frame3.Text("        ", key: __key3, sequenceNumber: -2046624283);
                    }, key: __key2, sequenceNumber: -2046624282);
                }, key: __key1, sequenceNumber: -2046624281);
            }, sequenceNumber: -2046624280);
            __frame0.Markup("<div id=\"blazor-error-ui\">\r\n    An unhandled error has occurred.\r\n    <a href=\"\" class=\"reload\">Reload</a>\r\n    <a class=\"dismiss\">🗙</a>\r\n</div>", sequenceNumber: -2046624279);
        }

    }
}

