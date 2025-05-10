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
    public partial class Component1 : ComponentBase
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
            Http = provider.GetRequiredService<HttpClient>();

        }

            
            
        int prope;
        RenderFragment V1()
        {
            return (__frame0, __key0) =>
            {
                __frame0.Element("span", null, (__frame1, __key1) =>
                {
                    __frame1.Content(prope, key: __key1, sequenceNumber: -2129814320);
                }, sequenceNumber: -2129814319);
            };
        }
        RenderFragment V2()
        {
            return (__frame1, __key1) =>
            {
                    __frame1.Element("span", null, (__frame2, __key2) =>
                    {
                        __frame2.Content(prope, key: __key2, sequenceNumber: -2129814318);
                    }, key: __key1, sequenceNumber: -2129814317);
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
                    __frame2.Text(@"Goto C2", key: __key2, sequenceNumber: -2129814388);
                }, key: __key1, sequenceNumber: -2129814387);
                __frame1.Content(field2, key: __key1, sequenceNumber: -2129814386);
                __frame1.Text(@" DEF", key: __key1, sequenceNumber: -2129814385);
            }, sequenceNumber: -2129814384);
            __frame0.Element("div", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("@attributes", this.As<Dictionary<string, object>>());
            }, null, sequenceNumber: -2129814383);
            __frame0.Component<GenericComponent1<int, string>>((__component0) =>
            {
                __component0.Set("@attributes", this.As<Dictionary<string, object>>());
            }, sequenceNumber: -2129814382);
            __frame0.Element("CascadingValue", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("TValue", "Component1");
                __attribute.Set("Name", "C1");
                __attribute.Set("Value", "this");
                __attribute.Set("IsFixed", "true");
            }, (__frame1, __key1) =>
            {
                __frame1.Component<Component2>((__component1) =>
                {
                    __component1.Property1 = "1";
                    __component1.Property2 = 1;
                    __component1.ChildContent = (a) => (__frame2, __key2) =>
                    {
                        __frame2.Text(@"Component2.1 ", key: __key2, sequenceNumber: -2129814381);
                        __frame2.Content(a, key: __key2, sequenceNumber: -2129814380);
                        __frame2.Text(@"        ", key: __key2, sequenceNumber: -2129814379);
                        __frame2.Component<Component2>((__component2) =>
                        {
                            __component2.Property1 = "1";
                            __component2.Property2 = 1;
                            __component2.ChildContent = (aa) => (__frame3, __key3) =>
                            {
                                __frame3.Text(@"Component2.Component2 ", key: __key3, sequenceNumber: -2129814378);
                                __frame3.Content(a, key: __key3, sequenceNumber: -2129814377);
                                __frame3.Text(@" ", key: __key3, sequenceNumber: -2129814376);
                                __frame3.Content(aa, key: __key3, sequenceNumber: -2129814375);
                                __frame3.Text(@" DEF
        ", key: __key3, sequenceNumber: -2129814374);
                            };
                        }, key: __key2, sequenceNumber: -2129814373);
                    };
                }, key: __key1, sequenceNumber: -2129814372);
            }, sequenceNumber: -2129814371);
            __frame0.Component<Component2>((__component0) =>
            {
                __component0.Property1 = "1";
                __component0.Property2 = 1;
                __component0.ChildContent = (i) => (__frame1, __key1) =>
                {
                        __frame1.Text(@"Component2.2
    ", key: __key1, sequenceNumber: -2129814370);
                };
                __component0.Property3 = (__frame1, __key1) =>
                {
                        __frame1.Text(@"Component2.Property3
    ", key: __key1, sequenceNumber: -2129814369);
                };
                __component0.Property4 = (i) => (__frame1, __key1) =>
                {
                        __frame1.Text(@"Component2.Property4
    ", key: __key1, sequenceNumber: -2129814368);
                };
            }, sequenceNumber: -2129814367);
            if ((field1 & 1) == 0)
            {
                input = __frame0.Element("input", (ref UIElementAttribute __attribute) =>
                {
                    var bindGetValue1 = field2;
                    __attribute.Set("value", bindGetValue1);
                    __attribute.Set("@onchange", EventCallback.Factory.CreateBinder(this, __value => field2 = __value, bindGetValue1));
                }, null, sequenceNumber: -2129814366);
            }
            __frame0.Element("button", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("@onclick", EventCallback.Factory.Create(this, (Action)Clicked, EventCallbackFlags.StopPropagation | EventCallbackFlags.PreventDefault));
            }, (__frame1, __key1) =>
            {
                __frame1.Text(@"Click Me", key: __key1, sequenceNumber: -2129814365);
            }, sequenceNumber: -2129814364);
            for (int _i = 0; _i < 10; _i++)
            {
                __frame0.Frame((__frame1, __key1) =>
                {
                        __frame0.Content(_i, sequenceNumber: -2129814363);
                }, key: _i, sequenceNumber: -2129814362);
                var i = _i;
                __frame0.Element("div", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("class", $"abc {field1} {field2} {i}");
                }, (__frame1, __key1) =>
                {
                    __frame1.Content((i + "."), key: __key1, sequenceNumber: -2129814361);
                    __frame1.Text(@" ABC ", key: __key1, sequenceNumber: -2129814360);
                    __frame1.Content(i, key: __key1, sequenceNumber: -2129814359);
                    __frame1.Text(@" ", key: __key1, sequenceNumber: -2129814358);
                    __frame1.Content(field1, key: __key1, sequenceNumber: -2129814357);
                    __frame1.Text(@" ", key: __key1, sequenceNumber: -2129814356);
                    __frame1.Content(field2, key: __key1, sequenceNumber: -2129814355);
                    __frame1.Text(@"    ", key: __key1, sequenceNumber: -2129814354);
                }, key: i, sequenceNumber: -2129814353);
            }
            __frame0.Element("div", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("class", "def");
            }, (__frame1, __key1) =>
            {
                __frame1.Text(@"ABC ", key: __key1, sequenceNumber: -2129814352);
                __frame1.Content(field1, key: __key1, sequenceNumber: -2129814351);
                __frame1.Text(@"    ", key: __key1, sequenceNumber: -2129814350);
                __frame1.Content(view, key: __key1, sequenceNumber: -2129814349);
                __frame1.Text(@"    ", key: __key1, sequenceNumber: -2129814348);
                for (int _i = 0; _i < 10; _i++)
                {
                    var i = _i;
                    __frame1.Element("div", (ref UIElementAttribute __attribute) =>
                    {
                        __attribute.Set("class", $"abc {field1} {field2} {i}");
                    }, (__frame2, __key2) =>
                    {
                        __frame2.Content(i, key: __key2, sequenceNumber: -2129814347);
                        __frame2.Text(@" . ABC ", key: __key2, sequenceNumber: -2129814346);
                        __frame2.Content(i, key: __key2, sequenceNumber: -2129814345);
                        __frame2.Text(@" ", key: __key2, sequenceNumber: -2129814344);
                        __frame2.Content(field1, key: __key2, sequenceNumber: -2129814343);
                        __frame2.Text(@" ", key: __key2, sequenceNumber: -2129814342);
                        __frame2.Content(field2, key: __key2, sequenceNumber: -2129814341);
                        __frame2.Text(@"        ", key: __key2, sequenceNumber: -2129814340);
                    }, key: i, sequenceNumber: -2129814339);
                }
            }, sequenceNumber: -2129814338);
            for (int _i = 0; _i < 10; _i++)
            {
                var i = _i;
                __frame0.Element("div", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("class", $"abc {field1} {field2} {i}");
                }, (__frame1, __key1) =>
                {
                    __frame1.Content(i, key: __key1, sequenceNumber: -2129814337);
                    __frame1.Text(@" . DEF ", key: __key1, sequenceNumber: -2129814336);
                    __frame1.Content(field1, key: __key1, sequenceNumber: -2129814335);
                    __frame1.Text(@" ", key: __key1, sequenceNumber: -2129814334);
                    __frame1.Content(field2, key: __key1, sequenceNumber: -2129814333);
                    __frame1.Text(@"    ", key: __key1, sequenceNumber: -2129814332);
                }, key: i, sequenceNumber: -2129814331);
            }
            
            
            RenderFragment view2 = (__frame1, __key1) =>
            {
                    __frame1.Element("span", null, (__frame2, __key2) =>
                    {
                        __frame2.Content(prope, key: __key2, sequenceNumber: -2129814330);
                    }, key: __key1, sequenceNumber: -2129814329);
            };
            
            __frame0.Content(view2, sequenceNumber: -2129814328);
            if (descriptor != null)
            {
                __frame0.Element("h1", null, (__frame1, __key1) =>
                {
                    __frame1.Text(@"Version: ", key: __key1, sequenceNumber: -2129814327);
                    __frame1.Content(descriptor.Version, key: __key1, sequenceNumber: -2129814326);
                }, sequenceNumber: -2129814325);
                __frame0.Element("h1", null, (__frame1, __key1) =>
                {
                    __frame1.Text(@"Size: ", key: __key1, sequenceNumber: -2129814324);
                    __frame1.Content(descriptor.Size, key: __key1, sequenceNumber: -2129814323);
                }, sequenceNumber: -2129814322);
            }
            __frame0.Content(html, sequenceNumber: -2129814321);
        }

    }
}

