using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using BlazorJs.Core.Components;
using BlazorJs.Sample.Layout;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
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
                    __frame1.Text("Weather", key: __key1, sequenceNumber: 492763211);
                };
            }, sequenceNumber: 492763212);
            __frame0.Markup("<h1>Weather</h1>", sequenceNumber: 492763213);
            __frame0.Markup("<p>This component demonstrates showing data from the server.</p>", sequenceNumber: 492763214);
            if (forecasts == null)
            {
                __frame0.Markup("<p><em>Loading...</em></p>", sequenceNumber: 492763215);
            }
            else
            {
                __frame0.Element("table", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("class", "table");
                }, (__frame1, __key1) =>
                {
                    __frame1.Markup("<thead>\r\n            <tr>\r\n                <th>Date</th>\r\n                <th>Temp. (C)</th>\r\n                <th>Temp. (F)</th>\r\n                <th>Summary</th>\r\n            </tr>\r\n        </thead>", key: __key1, sequenceNumber: 492763216);
                    __frame1.Element("tbody", null, (__frame2, __key2) =>
                    {
                        foreach (var forecast in forecasts)
                        {
                            __frame2.Element("tr", null, (__frame3, __key3) =>
                            {
                                __frame3.Element("td", null, (__frame4, __key4) =>
                                {
                                    __frame4.Content(forecast.Date.ToShortDateString(), key: __key4, sequenceNumber: 492763217);
                                }, key: __key3, sequenceNumber: 492763218);
                                __frame3.Element("td", null, (__frame4, __key4) =>
                                {
                                    __frame4.Content(forecast.TemperatureC, key: __key4, sequenceNumber: 492763219);
                                }, key: __key3, sequenceNumber: 492763220);
                                __frame3.Element("td", null, (__frame4, __key4) =>
                                {
                                    __frame4.Content(forecast.TemperatureF, key: __key4, sequenceNumber: 492763221);
                                }, key: __key3, sequenceNumber: 492763222);
                                __frame3.Element("td", null, (__frame4, __key4) =>
                                {
                                    __frame4.Content(forecast.Summary, key: __key4, sequenceNumber: 492763223);
                                }, key: __key3, sequenceNumber: 492763224);
                            }, key: forecast, sequenceNumber: 492763225);
                        }
                    }, key: __key1, sequenceNumber: 492763226);
                }, sequenceNumber: 492763227);
            }
        }

    }
}

