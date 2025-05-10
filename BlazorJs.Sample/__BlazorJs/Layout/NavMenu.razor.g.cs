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
                        __frame3.Text(@"MyBlazorWeb", key: __key3, sequenceNumber: 403984950);
                    }, key: __key2, sequenceNumber: 403984951);
                }, key: __key1, sequenceNumber: 403984952);
            }, sequenceNumber: 403984953);
            __frame0.Element("input", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("type", "checkbox");
                __attribute.Set("title", "Navigation menu");
                __attribute.Set("class", "navbar-toggler");
            }, null, sequenceNumber: 403984954);
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
                        __frame3.Element("NavLink", (ref UIElementAttribute __attribute) =>
                        {
                            __attribute.Set("class", "nav-link");
                            __attribute.Set("href", "/");
                            __attribute.Set("Match", "NavLinkMatch.All");
                        }, (__frame4, __key4) =>
                        {
                            __frame4.Element("span", (ref UIElementAttribute __attribute) =>
                            {
                                __attribute.Set("class", "bi bi-house-door-fill");
                                __attribute.Set("aria-hidden", "true");
                            }, null, key: __key4, sequenceNumber: 403984955);
                            __frame4.Text(@"Home
            ", key: __key4, sequenceNumber: 403984956);
                        }, key: __key3, sequenceNumber: 403984957);
                    }, key: __key2, sequenceNumber: 403984958);
                    __frame2.Element("div", (ref UIElementAttribute __attribute) =>
                    {
                        __attribute.Set("class", "nav-item px-3");
                    }, (__frame3, __key3) =>
                    {
                        __frame3.Element("NavLink", (ref UIElementAttribute __attribute) =>
                        {
                            __attribute.Set("class", "nav-link");
                            __attribute.Set("href", "counter");
                        }, (__frame4, __key4) =>
                        {
                            __frame4.Element("span", (ref UIElementAttribute __attribute) =>
                            {
                                __attribute.Set("class", "bi bi-plus-square-fill");
                                __attribute.Set("aria-hidden", "true");
                            }, null, key: __key4, sequenceNumber: 403984959);
                            __frame4.Text(@"Counter
            ", key: __key4, sequenceNumber: 403984960);
                        }, key: __key3, sequenceNumber: 403984961);
                    }, key: __key2, sequenceNumber: 403984962);
                    __frame2.Element("div", (ref UIElementAttribute __attribute) =>
                    {
                        __attribute.Set("class", "nav-item px-3");
                    }, (__frame3, __key3) =>
                    {
                        __frame3.Element("NavLink", (ref UIElementAttribute __attribute) =>
                        {
                            __attribute.Set("class", "nav-link");
                            __attribute.Set("href", "weather");
                        }, (__frame4, __key4) =>
                        {
                            __frame4.Element("span", (ref UIElementAttribute __attribute) =>
                            {
                                __attribute.Set("class", "bi bi-list-nested");
                                __attribute.Set("aria-hidden", "true");
                            }, null, key: __key4, sequenceNumber: 403984963);
                            __frame4.Text(@"Weather
            ", key: __key4, sequenceNumber: 403984964);
                        }, key: __key3, sequenceNumber: 403984965);
                    }, key: __key2, sequenceNumber: 403984966);
                    __frame2.Element("div", (ref UIElementAttribute __attribute) =>
                    {
                        __attribute.Set("class", "nav-item px-3");
                    }, (__frame3, __key3) =>
                    {
                        __frame3.Element("NavLink", (ref UIElementAttribute __attribute) =>
                        {
                            __attribute.Set("class", "nav-link");
                            __attribute.Set("href", "Sudoku");
                        }, (__frame4, __key4) =>
                        {
                            __frame4.Element("span", (ref UIElementAttribute __attribute) =>
                            {
                                __attribute.Set("class", "bi bi-list-nested");
                                __attribute.Set("aria-hidden", "true");
                            }, null, key: __key4, sequenceNumber: 403984967);
                            __frame4.Text(@"Sudoku
            ", key: __key4, sequenceNumber: 403984968);
                        }, key: __key3, sequenceNumber: 403984969);
                    }, key: __key2, sequenceNumber: 403984970);
                    __frame2.Element("div", (ref UIElementAttribute __attribute) =>
                    {
                        __attribute.Set("class", "nav-item px-3");
                    }, (__frame3, __key3) =>
                    {
                        __frame3.Element("NavLink", (ref UIElementAttribute __attribute) =>
                        {
                            __attribute.Set("class", "nav-link");
                            __attribute.Set("href", "Breakout");
                        }, (__frame4, __key4) =>
                        {
                            __frame4.Element("span", (ref UIElementAttribute __attribute) =>
                            {
                                __attribute.Set("class", "bi bi-list-nested");
                                __attribute.Set("aria-hidden", "true");
                            }, null, key: __key4, sequenceNumber: 403984971);
                            __frame4.Text(@"Breakout
            ", key: __key4, sequenceNumber: 403984972);
                        }, key: __key3, sequenceNumber: 403984973);
                    }, key: __key2, sequenceNumber: 403984974);
                }, key: __key1, sequenceNumber: 403984975);
            }, sequenceNumber: 403984976);
        }

    }
}

