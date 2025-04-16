using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using BlazorJs.Core.Components;
using BlazorJs.Sample.Layout;
using BlazorJs.Core.Components.LiteRouting;


namespace BlazorJs.Sample.Pages
{
    [StreamRendering(true)]
    public partial class Weather : Microsoft.AspNetCore.Components.ComponentBase
    {
        public static void RegisterRoute()
        {
            RouteTableFactory.Register<Weather>("/weather");
        }


        protected override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            __frame0.Component<PageTitle>((__component0) =>
            {

                __component0.ChildContent = (__frame1, __key1) =>
                {
                    __frame1.Text(@"Weather", key: __key1, sequenceNumber: -663898092);
                };
            }, sequenceNumber: -663898091);
            __frame0.Element("h1", null, (__frame1, __key1) =>
            {
                __frame1.Text(@"Weather", key: __key1, sequenceNumber: -663898090);
            }, sequenceNumber: -663898089);
            __frame0.Element("p", null, (__frame1, __key1) =>
            {
                __frame1.Text(@"This component demonstrates showing data from the server.", key: __key1, sequenceNumber: -663898088);
            }, sequenceNumber: -663898087);
            if (forecasts == null)
            {
                __frame0.Element("p", null, (__frame1, __key1) =>
                {
                    __frame1.Element("em", null, (__frame2, __key2) =>
                    {
                        __frame2.Text(@"Loading...", key: __key2, sequenceNumber: -663898086);
                    }, key: __key1, sequenceNumber: -663898085);
                }, sequenceNumber: -663898084);
            }
            else
            {
                __frame0.Element("table", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("class", "table");
                }, (__frame1, __key1) =>
                {
                    __frame1.Element("thead", null, (__frame2, __key2) =>
                    {
                        __frame2.Element("tr", null, (__frame3, __key3) =>
                        {
                            __frame3.Element("th", null, (__frame4, __key4) =>
                            {
                                __frame4.Text(@"Date", key: __key4, sequenceNumber: -663898083);
                            }, key: __key3, sequenceNumber: -663898082);
                            __frame3.Element("th", null, (__frame4, __key4) =>
                            {
                                __frame4.Text(@"Temp. (C)", key: __key4, sequenceNumber: -663898081);
                            }, key: __key3, sequenceNumber: -663898080);
                            __frame3.Element("th", null, (__frame4, __key4) =>
                            {
                                __frame4.Text(@"Temp. (F)", key: __key4, sequenceNumber: -663898079);
                            }, key: __key3, sequenceNumber: -663898078);
                            __frame3.Element("th", null, (__frame4, __key4) =>
                            {
                                __frame4.Text(@"Summary", key: __key4, sequenceNumber: -663898077);
                            }, key: __key3, sequenceNumber: -663898076);
                        }, key: __key2, sequenceNumber: -663898075);
                    }, key: __key1, sequenceNumber: -663898074);
                    __frame1.Element("tbody", null, (__frame2, __key2) =>
                    {
                        foreach (var forecast in forecasts)
                        {
                            __frame2.Element("tr", null, (__frame3, __key3) =>
                            {
                                __frame3.Element("td", null, (__frame4, __key4) =>
                                {
                                    __frame4.Content(forecast.Date.ToShortDateString(), key: __key4, sequenceNumber: -663898073);
                                }, key: __key3, sequenceNumber: -663898072);
                                __frame3.Element("td", null, (__frame4, __key4) =>
                                {
                                    __frame4.Content(forecast.TemperatureC, key: __key4, sequenceNumber: -663898071);
                                }, key: __key3, sequenceNumber: -663898070);
                                __frame3.Element("td", null, (__frame4, __key4) =>
                                {
                                    __frame4.Content(forecast.TemperatureF, key: __key4, sequenceNumber: -663898069);
                                }, key: __key3, sequenceNumber: -663898068);
                                __frame3.Element("td", null, (__frame4, __key4) =>
                                {
                                    __frame4.Content(forecast.Summary, key: __key4, sequenceNumber: -663898067);
                                }, key: __key3, sequenceNumber: -663898066);
                            }, key: forecast, sequenceNumber: -663898065);
                        }
                    }, key: __key1, sequenceNumber: -663898064);
                }, sequenceNumber: -663898063);
            }
        }

    }
}

