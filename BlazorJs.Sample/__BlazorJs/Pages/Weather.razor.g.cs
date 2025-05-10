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
    public partial class Weather : ComponentBase
    {
        public static void RegisterRoute()
        {
            RouteTableFactory.Register<Weather>("/weather");
        }


        protected override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            __frame0.Element("PageTitle", null, (__frame1, __key1) =>
            {
                __frame1.Text(@"Weather", key: __key1, sequenceNumber: 1356354934);
            }, sequenceNumber: 1356354935);
            __frame0.Element("h1", null, (__frame1, __key1) =>
            {
                __frame1.Text(@"Weather", key: __key1, sequenceNumber: 1356354936);
            }, sequenceNumber: 1356354937);
            __frame0.Element("p", null, (__frame1, __key1) =>
            {
                __frame1.Text(@"This component demonstrates showing data from the server.", key: __key1, sequenceNumber: 1356354938);
            }, sequenceNumber: 1356354939);
            if (forecasts == null)
            {
                __frame0.Element("p", null, (__frame1, __key1) =>
                {
                    __frame1.Element("em", null, (__frame2, __key2) =>
                    {
                        __frame2.Text(@"Loading...", key: __key2, sequenceNumber: 1356354940);
                    }, key: __key1, sequenceNumber: 1356354941);
                }, sequenceNumber: 1356354942);
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
                                __frame4.Text(@"Date", key: __key4, sequenceNumber: 1356354943);
                            }, key: __key3, sequenceNumber: 1356354944);
                            __frame3.Element("th", null, (__frame4, __key4) =>
                            {
                                __frame4.Text(@"Temp. (C)", key: __key4, sequenceNumber: 1356354945);
                            }, key: __key3, sequenceNumber: 1356354946);
                            __frame3.Element("th", null, (__frame4, __key4) =>
                            {
                                __frame4.Text(@"Temp. (F)", key: __key4, sequenceNumber: 1356354947);
                            }, key: __key3, sequenceNumber: 1356354948);
                            __frame3.Element("th", null, (__frame4, __key4) =>
                            {
                                __frame4.Text(@"Summary", key: __key4, sequenceNumber: 1356354949);
                            }, key: __key3, sequenceNumber: 1356354950);
                        }, key: __key2, sequenceNumber: 1356354951);
                    }, key: __key1, sequenceNumber: 1356354952);
                    __frame1.Element("tbody", null, (__frame2, __key2) =>
                    {
                        foreach (var forecast in forecasts)
                        {
                            __frame2.Element("tr", null, (__frame3, __key3) =>
                            {
                                __frame3.Element("td", null, (__frame4, __key4) =>
                                {
                                    __frame4.Content(forecast.Date.ToShortDateString(), key: __key4, sequenceNumber: 1356354953);
                                }, key: __key3, sequenceNumber: 1356354954);
                                __frame3.Element("td", null, (__frame4, __key4) =>
                                {
                                    __frame4.Content(forecast.TemperatureC, key: __key4, sequenceNumber: 1356354955);
                                }, key: __key3, sequenceNumber: 1356354956);
                                __frame3.Element("td", null, (__frame4, __key4) =>
                                {
                                    __frame4.Content(forecast.TemperatureF, key: __key4, sequenceNumber: 1356354957);
                                }, key: __key3, sequenceNumber: 1356354958);
                                __frame3.Element("td", null, (__frame4, __key4) =>
                                {
                                    __frame4.Content(forecast.Summary, key: __key4, sequenceNumber: 1356354959);
                                }, key: __key3, sequenceNumber: 1356354960);
                            }, key: forecast, sequenceNumber: 1356354961);
                        }
                    }, key: __key1, sequenceNumber: 1356354962);
                }, sequenceNumber: 1356354963);
            }
        }

    }
}

