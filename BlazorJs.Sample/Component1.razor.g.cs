using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using BlazorJs.Core.Components;
using BlazorJs.Sample.Layout;
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
                    __frame1.Content(prope, key: __key1, sequenceNumber: 1144020255);
                }, sequenceNumber: 1144020256);
            };
        }
        RenderFragment V2()
        {
            return (__frame1, __key1) =>
            {
                    __frame1.Element("span", null, (__frame2, __key2) =>
                    {
                        __frame2.Content(prope, key: __key2, sequenceNumber: 1144020257);
                    }, key: __key1, sequenceNumber: 1144020258);
            };
        }
            
        protected override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            __frame0.Element("a", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("href", "C2");
            }, (__frame1, __key1) =>
            {
                __frame1.Element("span", null, (__frame2, __key2) =>
                {
                    __frame2.Text(@"Goto C2", key: __key2, sequenceNumber: 1144020188);
                }, key: __key1, sequenceNumber: 1144020189);
                __frame1.Content(field2, key: __key1, sequenceNumber: 1144020190);
                __frame1.Text(@" DEF", key: __key1, sequenceNumber: 1144020191);
            }, sequenceNumber: 1144020192);
            __frame0.Component<GenericComponent1<int, string>>(null, sequenceNumber: 1144020193);
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
                            __frame2.Text(@"Component2.1 ", key: __key2, sequenceNumber: 1144020194);
                            __frame2.Content(a, key: __key2, sequenceNumber: 1144020195);
                            __frame2.Text(@"        ", key: __key2, sequenceNumber: 1144020196);
                            __frame2.Component<Component2>((__component2) =>
                            {
                                __component2.Property1 = "1";
                                __component2.Property2 = 1;
                                __component2.ChildContent = (aa) => (__frame3, __key3) =>
                                {
                                    __frame3.Text(@"Component2.Component2 ", key: __key3, sequenceNumber: 1144020197);
                                    __frame3.Content(a, key: __key3, sequenceNumber: 1144020198);
                                    __frame3.Text(@" ", key: __key3, sequenceNumber: 1144020199);
                                    __frame3.Content(aa, key: __key3, sequenceNumber: 1144020200);
                                    __frame3.Text(@" DEF
        ", key: __key3, sequenceNumber: 1144020201);
                                };
                            }, key: __key2, sequenceNumber: 1144020202);
                        };
                    }, key: __key1, sequenceNumber: 1144020203);
                };
            }, sequenceNumber: 1144020204);
            __frame0.Component<Component2>((__component0) =>
            {
                __component0.Property1 = "1";
                __component0.Property2 = 1;
                __component0.ChildContent = (i) => (__frame1, __key1) =>
                {
                        __frame1.Text(@"Component2.2
    ", key: __key1, sequenceNumber: 1144020205);
                };
                __component0.Property3 = (__frame1, __key1) =>
                {
                        __frame1.Text(@"Component2.Property3
    ", key: __key1, sequenceNumber: 1144020206);
                };
                __component0.Property4 = (i) => (__frame1, __key1) =>
                {
                        __frame1.Text(@"Component2.Property4
    ", key: __key1, sequenceNumber: 1144020207);
                };
            }, sequenceNumber: 1144020208);
            if ((field1 & 1) == 0)
            {
                input = __frame0.Element("input", (ref UIElementAttribute __attribute) =>
                {
                    var bindGetValue1 = field2;
                    __attribute.Set("value", bindGetValue1);
                    __attribute.Set("@onchange", EventCallback.Factory.CreateBinder(this, __value => field2 = __value, bindGetValue1));
                }, null, sequenceNumber: 1144020209);
            }
            __frame0.Element("button", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("@onclick", EventCallback.Factory.Create(this, (Action)Clicked, EventCallbackFlags.StopPropagation | EventCallbackFlags.PreventDefault));
            }, (__frame1, __key1) =>
            {
                __frame1.Text(@"Click Me", key: __key1, sequenceNumber: 1144020210);
            }, sequenceNumber: 1144020211);
            for (int _i = 0; _i < 10; _i++)
            {
                __frame0.Frame((__frame1, __key1) =>
                {
                        __frame0.Content(_i, sequenceNumber: 1144020212);
                }, key: _i, sequenceNumber: 1144020213);
                var i = _i;
                __frame0.Element("div", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("class", $"abc {field1} {field2} {i}");
                }, (__frame1, __key1) =>
                {
                    __frame1.Content((i + "."), key: __key1, sequenceNumber: 1144020214);
                    __frame1.Text(@" ABC ", key: __key1, sequenceNumber: 1144020215);
                    __frame1.Content(i, key: __key1, sequenceNumber: 1144020216);
                    __frame1.Text(@" ", key: __key1, sequenceNumber: 1144020217);
                    __frame1.Content(field1, key: __key1, sequenceNumber: 1144020218);
                    __frame1.Text(@" ", key: __key1, sequenceNumber: 1144020219);
                    __frame1.Content(field2, key: __key1, sequenceNumber: 1144020220);
                    __frame1.Text(@"    ", key: __key1, sequenceNumber: 1144020221);
                }, key: i, sequenceNumber: 1144020222);
            }
            __frame0.Element("div", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("class", "def");
            }, (__frame1, __key1) =>
            {
                __frame1.Text(@"ABC ", key: __key1, sequenceNumber: 1144020223);
                __frame1.Content(field1, key: __key1, sequenceNumber: 1144020224);
                __frame1.Text(@"    ", key: __key1, sequenceNumber: 1144020225);
                __frame1.Content(view, key: __key1, sequenceNumber: 1144020226);
                __frame1.Text(@"    ", key: __key1, sequenceNumber: 1144020227);
                for (int _i = 0; _i < 10; _i++)
                {
                    var i = _i;
                    __frame1.Element("div", (ref UIElementAttribute __attribute) =>
                    {
                        __attribute.Set("class", $"abc {field1} {field2} {i}");
                    }, (__frame2, __key2) =>
                    {
                        __frame2.Content(i, key: __key2, sequenceNumber: 1144020228);
                        __frame2.Text(@" . ABC ", key: __key2, sequenceNumber: 1144020229);
                        __frame2.Content(i, key: __key2, sequenceNumber: 1144020230);
                        __frame2.Text(@" ", key: __key2, sequenceNumber: 1144020231);
                        __frame2.Content(field1, key: __key2, sequenceNumber: 1144020232);
                        __frame2.Text(@" ", key: __key2, sequenceNumber: 1144020233);
                        __frame2.Content(field2, key: __key2, sequenceNumber: 1144020234);
                        __frame2.Text(@"        ", key: __key2, sequenceNumber: 1144020235);
                    }, key: i, sequenceNumber: 1144020236);
                }
            }, sequenceNumber: 1144020237);
            for (int _i = 0; _i < 10; _i++)
            {
                var i = _i;
                __frame0.Element("div", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("class", $"abc {field1} {field2} {i}");
                }, (__frame1, __key1) =>
                {
                    __frame1.Content(i, key: __key1, sequenceNumber: 1144020238);
                    __frame1.Text(@" . DEF ", key: __key1, sequenceNumber: 1144020239);
                    __frame1.Content(field1, key: __key1, sequenceNumber: 1144020240);
                    __frame1.Text(@" ", key: __key1, sequenceNumber: 1144020241);
                    __frame1.Content(field2, key: __key1, sequenceNumber: 1144020242);
                    __frame1.Text(@"    ", key: __key1, sequenceNumber: 1144020243);
                }, key: i, sequenceNumber: 1144020244);
            }
            
            
            RenderFragment view2 = (__frame1, __key1) =>
            {
                    __frame1.Element("span", null, (__frame2, __key2) =>
                    {
                        __frame2.Content(prope, key: __key2, sequenceNumber: 1144020245);
                    }, key: __key1, sequenceNumber: 1144020246);
            };
            
            __frame0.Content(view2, sequenceNumber: 1144020247);
            if (descriptor != null)
            {
                __frame0.Element("h1", null, (__frame1, __key1) =>
                {
                    __frame1.Text(@"Version: ", key: __key1, sequenceNumber: 1144020248);
                    __frame1.Content(descriptor.Version, key: __key1, sequenceNumber: 1144020249);
                }, sequenceNumber: 1144020250);
                __frame0.Element("h1", null, (__frame1, __key1) =>
                {
                    __frame1.Text(@"Size: ", key: __key1, sequenceNumber: 1144020251);
                    __frame1.Content(descriptor.Size, key: __key1, sequenceNumber: 1144020252);
                }, sequenceNumber: 1144020253);
            }
            __frame0.Content(html, sequenceNumber: 1144020254);
        }

    }
}

