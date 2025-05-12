using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using BlazorJs.Core.Components;
using BlazorJs.Sample.Layout;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using BlazorJs.Core.Components.LiteRouting;


namespace BlazorJs.Sample
{
    public partial class Component1 : Microsoft.AspNetCore.Components.ComponentBase
    {
        public static void RegisterRoute()
        {
            RouteTableFactory.Register<Component1>("/C1", layout: typeof(MainLayout));
            RouteTableFactory.Register<Component1>("/C1/{Property1}", layout: typeof(MainLayout), routeParameterSetter: (component, name, value) =>
            {
                switch(name.ToLower())
                {
                    case "property1":
                        component.Property1 = value;
                        break;
                }
            });
        }

        protected override void InjectServices(IServiceProvider provider)
        {
            Http = provider.GetRequiredService<System.Net.Http.HttpClient>();

        }

            
            
        int prope;
        RenderFragment V1()
        {
            return (__frame0, __key0) =>
            {
                __frame0.Element("span", null, (__frame1, __key1) =>
                {
                    __frame1.Content(prope, key: __key1, sequenceNumber: -1493641539);
                }, sequenceNumber: -1493641538);
            };
        }
        RenderFragment V2()
        {
            return (__frame1, __key1) =>
            {
                    __frame1.Element("span", null, (__frame2, __key2) =>
                    {
                        __frame2.Content(prope, key: __key2, sequenceNumber: -1493641537);
                    }, key: __key1, sequenceNumber: -1493641536);
            };
        }
            
        protected override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            __frame0.Markup("<div>ShoudUseMarkup</div>", sequenceNumber: -1493641607);
            __frame0.Element("a", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("href", "C2");
            }, (__frame1, __key1) =>
            {
                __frame1.Markup("<span>Goto \r\n        \"\r\n        C2</span>", key: __key1, sequenceNumber: -1493641606);
                __frame1.Content(field2, key: __key1, sequenceNumber: -1493641605);
                __frame1.Text(" DEF", key: __key1, sequenceNumber: -1493641604);
            }, sequenceNumber: -1493641603);
            __frame0.Element("div", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("@attributes", this.As<Dictionary<string, object>>());
            }, null, sequenceNumber: -1493641602);
            __frame0.Component<GenericComponent1<int, string>>((__component0) =>
            {
                __component0.Set("@attributes", this.As<Dictionary<string, object>>());
            }, sequenceNumber: -1493641601);
            __frame0.Component<CascadingValue<Component1>>((__component0) =>
            {
                __component0.Name = "C1";
                __component0.Value = this;
                __component0.IsFixed = true;
                __component0.ChildContent = (__frame1, __key1) =>
                {
                    __frame1.Component<Component2>((__component1) =>
                    {
                        __component1.Property1 = "1";
                        __component1.Property2 = 1;
                        __component1.ChildContent = (a) => (__frame2, __key2) =>
                        {
                            __frame2.Text("Component2.1 ", key: __key2, sequenceNumber: -1493641600);
                            __frame2.Content(a, key: __key2, sequenceNumber: -1493641599);
                            __frame2.Text("        ", key: __key2, sequenceNumber: -1493641598);
                            __frame2.Component<Component2>((__component2) =>
                            {
                                __component2.Property1 = "1";
                                __component2.Property2 = 1;
                                __component2.ChildContent = (aa) => (__frame3, __key3) =>
                                {
                                    __frame3.Text("Component2.Component2 ", key: __key3, sequenceNumber: -1493641597);
                                    __frame3.Content(a, key: __key3, sequenceNumber: -1493641596);
                                    __frame3.Text(" ", key: __key3, sequenceNumber: -1493641595);
                                    __frame3.Content(aa, key: __key3, sequenceNumber: -1493641594);
                                    __frame3.Text(" DEF\r\n        ", key: __key3, sequenceNumber: -1493641593);
                                };
                            }, key: __key2, sequenceNumber: -1493641592);
                        };
                    }, key: __key1, sequenceNumber: -1493641591);
                };
            }, sequenceNumber: -1493641590);
            __frame0.Component<Component2>((__component0) =>
            {
                __component0.Property1 = "1";
                __component0.Property2 = 1;
                __component0.ChildContent = (i) => (__frame1, __key1) =>
                {
                        __frame1.Text("Component2.2\r\n    ", key: __key1, sequenceNumber: -1493641589);
                };
                __component0.Property3 = (__frame1, __key1) =>
                {
                        __frame1.Text("Component2.Property3\r\n    ", key: __key1, sequenceNumber: -1493641588);
                };
                __component0.Property4 = (i) => (__frame1, __key1) =>
                {
                        __frame1.Text("Component2.Property4\r\n    ", key: __key1, sequenceNumber: -1493641587);
                };
            }, sequenceNumber: -1493641586);
            if ((field1 & 1) == 0)
            {
                input = __frame0.Element("input", (ref UIElementAttribute __attribute) =>
                {
                    var bindGetValue1 = field2;
                    __attribute.Set("value", bindGetValue1);
                    __attribute.Set("@onchange", EventCallback.Factory.CreateBinder(this, __value => field2 = __value, bindGetValue1));
                }, null, sequenceNumber: -1493641585);
            }
            __frame0.Element("button", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("@onclick", EventCallback.Factory.Create(this, (Action)Clicked, EventCallbackFlags.StopPropagation | EventCallbackFlags.PreventDefault));
            }, (__frame1, __key1) =>
            {
                __frame1.Text("Click Me", key: __key1, sequenceNumber: -1493641584);
            }, sequenceNumber: -1493641583);
            for (int _i = 0; _i < 10; _i++)
            {
                __frame0.Frame((__frame1, __key1) =>
                {
                        __frame0.Content(_i, sequenceNumber: -1493641582);
                }, key: _i, sequenceNumber: -1493641581);
                var i = _i;
                __frame0.Element("div", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("class", $"abc {field1} {field2} {i}");
                }, (__frame1, __key1) =>
                {
                    __frame1.Content((i + "."), key: __key1, sequenceNumber: -1493641580);
                    __frame1.Text(" ABC ", key: __key1, sequenceNumber: -1493641579);
                    __frame1.Content(i, key: __key1, sequenceNumber: -1493641578);
                    __frame1.Text(" ", key: __key1, sequenceNumber: -1493641577);
                    __frame1.Content(field1, key: __key1, sequenceNumber: -1493641576);
                    __frame1.Text(" ", key: __key1, sequenceNumber: -1493641575);
                    __frame1.Content(field2, key: __key1, sequenceNumber: -1493641574);
                    __frame1.Text("    ", key: __key1, sequenceNumber: -1493641573);
                }, key: i, sequenceNumber: -1493641572);
            }
            __frame0.Element("div", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("class", "def");
            }, (__frame1, __key1) =>
            {
                __frame1.Text("ABC ", key: __key1, sequenceNumber: -1493641571);
                __frame1.Content(field1, key: __key1, sequenceNumber: -1493641570);
                __frame1.Text("    ", key: __key1, sequenceNumber: -1493641569);
                __frame1.Content(view, key: __key1, sequenceNumber: -1493641568);
                __frame1.Text("    ", key: __key1, sequenceNumber: -1493641567);
                for (int _i = 0; _i < 10; _i++)
                {
                    var i = _i;
                    __frame1.Element("div", (ref UIElementAttribute __attribute) =>
                    {
                        __attribute.Set("class", $"abc {field1} {field2} {i}");
                    }, (__frame2, __key2) =>
                    {
                        __frame2.Content(i, key: __key2, sequenceNumber: -1493641566);
                        __frame2.Text(" . ABC ", key: __key2, sequenceNumber: -1493641565);
                        __frame2.Content(i, key: __key2, sequenceNumber: -1493641564);
                        __frame2.Text(" ", key: __key2, sequenceNumber: -1493641563);
                        __frame2.Content(field1, key: __key2, sequenceNumber: -1493641562);
                        __frame2.Text(" ", key: __key2, sequenceNumber: -1493641561);
                        __frame2.Content(field2, key: __key2, sequenceNumber: -1493641560);
                        __frame2.Text("        ", key: __key2, sequenceNumber: -1493641559);
                    }, key: i, sequenceNumber: -1493641558);
                }
            }, sequenceNumber: -1493641557);
            for (int _i = 0; _i < 10; _i++)
            {
                var i = _i;
                __frame0.Element("div", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("class", $"abc {field1} {field2} {i}");
                }, (__frame1, __key1) =>
                {
                    __frame1.Content(i, key: __key1, sequenceNumber: -1493641556);
                    __frame1.Text(" . DEF ", key: __key1, sequenceNumber: -1493641555);
                    __frame1.Content(field1, key: __key1, sequenceNumber: -1493641554);
                    __frame1.Text(" ", key: __key1, sequenceNumber: -1493641553);
                    __frame1.Content(field2, key: __key1, sequenceNumber: -1493641552);
                    __frame1.Text("    ", key: __key1, sequenceNumber: -1493641551);
                }, key: i, sequenceNumber: -1493641550);
            }
            
            
            RenderFragment view2 = (__frame1, __key1) =>
            {
                    __frame1.Element("span", null, (__frame2, __key2) =>
                    {
                        __frame2.Content(prope, key: __key2, sequenceNumber: -1493641549);
                    }, key: __key1, sequenceNumber: -1493641548);
            };
            
            __frame0.Content(view2, sequenceNumber: -1493641547);
            if (descriptor != null)
            {
                __frame0.Element("h1", null, (__frame1, __key1) =>
                {
                    __frame1.Text("Version: ", key: __key1, sequenceNumber: -1493641546);
                    __frame1.Content(descriptor.Version, key: __key1, sequenceNumber: -1493641545);
                }, sequenceNumber: -1493641544);
                __frame0.Element("h1", null, (__frame1, __key1) =>
                {
                    __frame1.Text("Size: ", key: __key1, sequenceNumber: -1493641543);
                    __frame1.Content(descriptor.Size, key: __key1, sequenceNumber: -1493641542);
                }, sequenceNumber: -1493641541);
            }
            __frame0.Content(html, sequenceNumber: -1493641540);
        }

    }
}

