using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using BlazorJs.Core.Components;
using BlazorJs.Sample.Layout;
using Microsoft.AspNetCore.Components.Routing;


namespace BlazorJs.Sample.Layout
{
    public partial class NavMenu : ComponentBase
    {

        protected override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            __frame0.Markup("<div class=\"top-row ps-3 navbar navbar-dark\">\r\n    <div class=\"container-fluid\">\r\n        <a class=\"navbar-brand\" href=\"\">MyBlazorWeb</a>\r\n    </div>\r\n</div>", sequenceNumber: -917386754);
            __frame0.Markup("<input type=\"checkbox\" title=\"Navigation menu\" class=\"navbar-toggler\" />", sequenceNumber: -917386753);
            __frame0.Element("div", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("class", "nav-scrollable");
                __attribute.Set("onclick", "document.querySelector('.navbar-toggler').click()");
            }, (__frame1, __key1) =>
            {
                __frame1.Element("nav", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("class", "flex-column");
                }, (__frame2, __key2) =>
                {
                    __frame2.Element("div", (ref UIElementAttribute __attribute) =>
                    {
                        __attribute.Set("class", "nav-item px-3");
                    }, (__frame3, __key3) =>
                    {
                        __frame3.Component<NavLink>((__component3) =>
                        {
                            __component3["class"] = "nav-link";
                            __component3["href"] = "/";
                            __component3.Match = NavLinkMatch.All;
                            __component3.ChildContent = (__frame4, __key4) =>
                            {
                                __frame4.Markup("<span class=\"bi bi-house-door-fill\" aria-hidden=\"true\"></span>", key: __key4, sequenceNumber: -917386752);
                                __frame4.Text("Home\r\n            ", key: __key4, sequenceNumber: -917386751);
                            };
                        }, key: __key3, sequenceNumber: -917386750);
                    }, key: __key2, sequenceNumber: -917386749);
                    __frame2.Element("div", (ref UIElementAttribute __attribute) =>
                    {
                        __attribute.Set("class", "nav-item px-3");
                    }, (__frame3, __key3) =>
                    {
                        __frame3.Component<NavLink>((__component3) =>
                        {
                            __component3["class"] = "nav-link";
                            __component3["href"] = "counter";
                            __component3.ChildContent = (__frame4, __key4) =>
                            {
                                __frame4.Markup("<span class=\"bi bi-plus-square-fill\" aria-hidden=\"true\"></span>", key: __key4, sequenceNumber: -917386748);
                                __frame4.Text("Counter\r\n            ", key: __key4, sequenceNumber: -917386747);
                            };
                        }, key: __key3, sequenceNumber: -917386746);
                    }, key: __key2, sequenceNumber: -917386745);
                    __frame2.Element("div", (ref UIElementAttribute __attribute) =>
                    {
                        __attribute.Set("class", "nav-item px-3");
                    }, (__frame3, __key3) =>
                    {
                        __frame3.Component<NavLink>((__component3) =>
                        {
                            __component3["class"] = "nav-link";
                            __component3["href"] = "weather";
                            __component3.ChildContent = (__frame4, __key4) =>
                            {
                                __frame4.Markup("<span class=\"bi bi-list-nested\" aria-hidden=\"true\"></span>", key: __key4, sequenceNumber: -917386744);
                                __frame4.Text("Weather\r\n            ", key: __key4, sequenceNumber: -917386743);
                            };
                        }, key: __key3, sequenceNumber: -917386742);
                    }, key: __key2, sequenceNumber: -917386741);
                    __frame2.Element("div", (ref UIElementAttribute __attribute) =>
                    {
                        __attribute.Set("class", "nav-item px-3");
                    }, (__frame3, __key3) =>
                    {
                        __frame3.Component<NavLink>((__component3) =>
                        {
                            __component3["class"] = "nav-link";
                            __component3["href"] = "Sudoku";
                            __component3.ChildContent = (__frame4, __key4) =>
                            {
                                __frame4.Markup("<span class=\"bi bi-list-nested\" aria-hidden=\"true\"></span>", key: __key4, sequenceNumber: -917386740);
                                __frame4.Text("Sudoku\r\n            ", key: __key4, sequenceNumber: -917386739);
                            };
                        }, key: __key3, sequenceNumber: -917386738);
                    }, key: __key2, sequenceNumber: -917386737);
                    __frame2.Element("div", (ref UIElementAttribute __attribute) =>
                    {
                        __attribute.Set("class", "nav-item px-3");
                    }, (__frame3, __key3) =>
                    {
                        __frame3.Component<NavLink>((__component3) =>
                        {
                            __component3["class"] = "nav-link";
                            __component3["href"] = "Breakout";
                            __component3.ChildContent = (__frame4, __key4) =>
                            {
                                __frame4.Markup("<span class=\"bi bi-list-nested\" aria-hidden=\"true\"></span>", key: __key4, sequenceNumber: -917386736);
                                __frame4.Text("Breakout\r\n            ", key: __key4, sequenceNumber: -917386735);
                            };
                        }, key: __key3, sequenceNumber: -917386734);
                    }, key: __key2, sequenceNumber: -917386733);
                }, key: __key1, sequenceNumber: -917386732);
            }, sequenceNumber: -917386731);
        }

    }
}

