using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using BlazorJs.Core.Components;
using BlazorJs.Sample.Layout;


namespace BlazorJs.Sample.Layout
{
    public partial class NavMenu : ComponentBase
    {

        protected override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            __frame0.Element("div", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("class", "top-row ps-3 navbar navbar-dark");
            }, (__frame1, __key1) =>
            {
                __frame1.Element("div", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("class", "container-fluid");
                }, (__frame2, __key2) =>
                {
                    __frame2.Element("a", (ref UIElementAttribute __attribute) =>
                    {
                        __attribute.Set("class", "navbar-brand");
                        __attribute.Set("href", "");
                    }, (__frame3, __key3) =>
                    {
                        __frame3.Text(@"MyBlazorWeb", key: __key3, sequenceNumber: -586999570);
                    }, key: __key2, sequenceNumber: -586999569);
                }, key: __key1, sequenceNumber: -586999568);
            }, sequenceNumber: -586999567);
            __frame0.Element("input", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("type", "checkbox");
                __attribute.Set("title", "Navigation menu");
                __attribute.Set("class", "navbar-toggler");
            }, null, sequenceNumber: -586999566);
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
                                __frame4.Element("span", (ref UIElementAttribute __attribute) =>
                                {
                                    __attribute.Set("class", "bi bi-house-door-fill");
                                    __attribute.Set("aria-hidden", "true");
                                }, null, key: __key4, sequenceNumber: -586999565);
                                __frame4.Text(@"Home
            ", key: __key4, sequenceNumber: -586999564);
                            };
                        }, key: __key3, sequenceNumber: -586999563);
                    }, key: __key2, sequenceNumber: -586999562);
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
                                __frame4.Element("span", (ref UIElementAttribute __attribute) =>
                                {
                                    __attribute.Set("class", "bi bi-plus-square-fill");
                                    __attribute.Set("aria-hidden", "true");
                                }, null, key: __key4, sequenceNumber: -586999561);
                                __frame4.Text(@"Counter
            ", key: __key4, sequenceNumber: -586999560);
                            };
                        }, key: __key3, sequenceNumber: -586999559);
                    }, key: __key2, sequenceNumber: -586999558);
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
                                __frame4.Element("span", (ref UIElementAttribute __attribute) =>
                                {
                                    __attribute.Set("class", "bi bi-list-nested");
                                    __attribute.Set("aria-hidden", "true");
                                }, null, key: __key4, sequenceNumber: -586999557);
                                __frame4.Text(@"Weather
            ", key: __key4, sequenceNumber: -586999556);
                            };
                        }, key: __key3, sequenceNumber: -586999555);
                    }, key: __key2, sequenceNumber: -586999554);
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
                                __frame4.Element("span", (ref UIElementAttribute __attribute) =>
                                {
                                    __attribute.Set("class", "bi bi-list-nested");
                                    __attribute.Set("aria-hidden", "true");
                                }, null, key: __key4, sequenceNumber: -586999553);
                                __frame4.Text(@"Sudoku
            ", key: __key4, sequenceNumber: -586999552);
                            };
                        }, key: __key3, sequenceNumber: -586999551);
                    }, key: __key2, sequenceNumber: -586999550);
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
                                __frame4.Element("span", (ref UIElementAttribute __attribute) =>
                                {
                                    __attribute.Set("class", "bi bi-list-nested");
                                    __attribute.Set("aria-hidden", "true");
                                }, null, key: __key4, sequenceNumber: -586999549);
                                __frame4.Text(@"Breakout
            ", key: __key4, sequenceNumber: -586999548);
                            };
                        }, key: __key3, sequenceNumber: -586999547);
                    }, key: __key2, sequenceNumber: -586999546);
                }, key: __key1, sequenceNumber: -586999545);
            }, sequenceNumber: -586999544);
        }

    }
}

