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
using Microsoft.AspNetCore.Components.Routing;
using System.Reflection;
using System.IO;
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
            MHttp = provider.GetRequiredService<System.Net.Http.HttpClient>();
            Http = provider.GetRequiredService<System.Net.Http.HttpClient>();

        }

            
            
        int prope;
        RenderFragment V1()
        {
            return (__frame0, __key0) =>
            {
                __frame0.Element("span", null, (__frame1, __key1) =>
                {
                    __frame1.Content(prope, key: __key1, sequenceNumber: -137192053);
                }, sequenceNumber: -137192052);
            };
        }
        RenderFragment V2()
        {
            return (__frame1, __key1) =>
            {
                    __frame1.Element("span", null, (__frame2, __key2) =>
                    {
                        __frame2.Content(prope, key: __key2, sequenceNumber: -137192051);
                    }, key: __key1, sequenceNumber: -137192050);
            };
        }
            
        protected override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            __frame0.Markup("<div>ShoudUseMarkup</div>", sequenceNumber: -137192121);
            __frame0.Element("a", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("href", "C2");
            }, (__frame1, __key1) =>
            {
                __frame1.Markup("<span>Goto \r\n        \"\r\n        C2</span>", key: __key1, sequenceNumber: -137192120);
                __frame1.Content(field2, key: __key1, sequenceNumber: -137192119);
                __frame1.Text(" DEF", key: __key1, sequenceNumber: -137192118);
            }, sequenceNumber: -137192117);
            __frame0.Element("div", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("@attributes", this.As<Dictionary<string, object>>());
            }, null, sequenceNumber: -137192116);
            __frame0.Component<GenericComponent1<int, string>>((__component0) =>
            {
                __component0.Set("@attributes", this.As<Dictionary<string, object>>());
            }, sequenceNumber: -137192115);
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
                            __frame2.Text("Component2.1 ", key: __key2, sequenceNumber: -137192114);
                            __frame2.Content(a, key: __key2, sequenceNumber: -137192113);
                            __frame2.Text("        ", key: __key2, sequenceNumber: -137192112);
                            __frame2.Component<Component2>((__component2) =>
                            {
                                __component2.Property1 = "1";
                                __component2.Property2 = 1;
                                __component2.ChildContent = (aa) => (__frame3, __key3) =>
                                {
                                    __frame3.Text("Component2.Component2 ", key: __key3, sequenceNumber: -137192111);
                                    __frame3.Content(a, key: __key3, sequenceNumber: -137192110);
                                    __frame3.Text(" ", key: __key3, sequenceNumber: -137192109);
                                    __frame3.Content(aa, key: __key3, sequenceNumber: -137192108);
                                    __frame3.Text(" DEF\r\n        ", key: __key3, sequenceNumber: -137192107);
                                };
                            }, key: __key2, sequenceNumber: -137192106);
                        };
                    }, key: __key1, sequenceNumber: -137192105);
                };
            }, sequenceNumber: -137192104);
            __frame0.Component<Component2>((__component0) =>
            {
                __component0.Property1 = "1";
                __component0.Property2 = 1;
                __component0.ChildContent = (i) => (__frame1, __key1) =>
                {
                        __frame1.Text("Component2.2\r\n    ", key: __key1, sequenceNumber: -137192103);
                };
                __component0.Property3 = (__frame1, __key1) =>
                {
                        __frame1.Text("Component2.Property3\r\n    ", key: __key1, sequenceNumber: -137192102);
                };
                __component0.Property4 = (i) => (__frame1, __key1) =>
                {
                        __frame1.Text("Component2.Property4\r\n    ", key: __key1, sequenceNumber: -137192101);
                };
            }, sequenceNumber: -137192100);
            if ((field1 & 1) == 0)
            {
                input = __frame0.Element("input", (ref UIElementAttribute __attribute) =>
                {
                    var bindGetValue1 = field2;
                    __attribute.Set("value", bindGetValue1);
                    __attribute.Set("@onchange", EventCallback.Factory.CreateBinder(this, __value => field2 = __value, bindGetValue1));
                }, null, sequenceNumber: -137192099);
            }
            __frame0.Element("button", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("@onclick", EventCallback.Factory.Create(this, (Action)Clicked, EventCallbackFlags.StopPropagation | EventCallbackFlags.PreventDefault));
            }, (__frame1, __key1) =>
            {
                __frame1.Text("Click Me", key: __key1, sequenceNumber: -137192098);
            }, sequenceNumber: -137192097);
            for (int _i = 0; _i < 10; _i++)
            {
                __frame0.Frame((__frame1, __key1) =>
                {
                        __frame0.Content(_i, sequenceNumber: -137192096);
                }, key: _i, sequenceNumber: -137192095);
                var i = _i;
                __frame0.Element("div", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("class", $"abc {field1} {field2} {i}");
                }, (__frame1, __key1) =>
                {
                    __frame1.Content((i + "."), key: __key1, sequenceNumber: -137192094);
                    __frame1.Text(" ABC ", key: __key1, sequenceNumber: -137192093);
                    __frame1.Content(i, key: __key1, sequenceNumber: -137192092);
                    __frame1.Text(" ", key: __key1, sequenceNumber: -137192091);
                    __frame1.Content(field1, key: __key1, sequenceNumber: -137192090);
                    __frame1.Text(" ", key: __key1, sequenceNumber: -137192089);
                    __frame1.Content(field2, key: __key1, sequenceNumber: -137192088);
                    __frame1.Text("    ", key: __key1, sequenceNumber: -137192087);
                }, key: i, sequenceNumber: -137192086);
            }
            __frame0.Element("div", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("class", "def");
            }, (__frame1, __key1) =>
            {
                __frame1.Text("ABC ", key: __key1, sequenceNumber: -137192085);
                __frame1.Content(field1, key: __key1, sequenceNumber: -137192084);
                __frame1.Text("    ", key: __key1, sequenceNumber: -137192083);
                __frame1.Content(view, key: __key1, sequenceNumber: -137192082);
                __frame1.Text("    ", key: __key1, sequenceNumber: -137192081);
                for (int _i = 0; _i < 10; _i++)
                {
                    var i = _i;
                    __frame1.Element("div", (ref UIElementAttribute __attribute) =>
                    {
                        __attribute.Set("class", $"abc {field1} {field2} {i}");
                    }, (__frame2, __key2) =>
                    {
                        __frame2.Content(i, key: __key2, sequenceNumber: -137192080);
                        __frame2.Text(" . ABC ", key: __key2, sequenceNumber: -137192079);
                        __frame2.Content(i, key: __key2, sequenceNumber: -137192078);
                        __frame2.Text(" ", key: __key2, sequenceNumber: -137192077);
                        __frame2.Content(field1, key: __key2, sequenceNumber: -137192076);
                        __frame2.Text(" ", key: __key2, sequenceNumber: -137192075);
                        __frame2.Content(field2, key: __key2, sequenceNumber: -137192074);
                        __frame2.Text("        ", key: __key2, sequenceNumber: -137192073);
                    }, key: i, sequenceNumber: -137192072);
                }
            }, sequenceNumber: -137192071);
            for (int _i = 0; _i < 10; _i++)
            {
                var i = _i;
                __frame0.Element("div", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("class", $"abc {field1} {field2} {i}");
                }, (__frame1, __key1) =>
                {
                    __frame1.Content(i, key: __key1, sequenceNumber: -137192070);
                    __frame1.Text(" . DEF ", key: __key1, sequenceNumber: -137192069);
                    __frame1.Content(field1, key: __key1, sequenceNumber: -137192068);
                    __frame1.Text(" ", key: __key1, sequenceNumber: -137192067);
                    __frame1.Content(field2, key: __key1, sequenceNumber: -137192066);
                    __frame1.Text("    ", key: __key1, sequenceNumber: -137192065);
                }, key: i, sequenceNumber: -137192064);
            }
            
            
            RenderFragment view2 = (__frame1, __key1) =>
            {
                    __frame1.Element("span", null, (__frame2, __key2) =>
                    {
                        __frame2.Content(prope, key: __key2, sequenceNumber: -137192063);
                    }, key: __key1, sequenceNumber: -137192062);
            };
            
            __frame0.Content(view2, sequenceNumber: -137192061);
            if (descriptor != null)
            {
                __frame0.Element("h1", null, (__frame1, __key1) =>
                {
                    __frame1.Text("Version: ", key: __key1, sequenceNumber: -137192060);
                    __frame1.Content(descriptor.Version, key: __key1, sequenceNumber: -137192059);
                }, sequenceNumber: -137192058);
                __frame0.Element("h1", null, (__frame1, __key1) =>
                {
                    __frame1.Text("Size: ", key: __key1, sequenceNumber: -137192057);
                    __frame1.Content(descriptor.Size, key: __key1, sequenceNumber: -137192056);
                }, sequenceNumber: -137192055);
            }
            __frame0.Content(html, sequenceNumber: -137192054);
        }

    }
}

