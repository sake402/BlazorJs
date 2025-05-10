using System;
using static H5.Core.dom;
using BlazorJs.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BlazorJs.Core.Components;
using BlazorJs.Sample.Layout;
using BlazorJs.Core.Components.LiteRouting;


namespace BlazorJs.Sample.Pages
{
    public partial class Sudoku : ComponentBase
    {
        public static void RegisterRoute()
        {
            RouteTableFactory.Register<Sudoku>("/Sudoku");
        }


        protected override void BuildRenderTree(IUIFrame __frame0, object __key = null)
        {
            __frame0.Element("div", (ref UIElementAttribute __attribute) =>
            {
                __attribute.Set("class", "ltroot flex");
            }, (__frame1, __key1) =>
            {
                __frame1.Element("EditForm", (ref UIElementAttribute __attribute) =>
                {
                    __attribute.Set("Model", "this");
                    __attribute.Set("class", "bg-card mg-a");
                    __attribute.Set("OnSubmit", "CreateBoard");
                }, (__frame2, __key2) =>
                {
                    if (size == 0 || boards == null)
                    {
                        __frame2.Element("h3", null, (__frame3, __key3) =>
                        {
                            __frame3.Text(@"Enter board size", key: __key3, sequenceNumber: 1530641480);
                        }, key: __key2, sequenceNumber: 1530641481);
                        __frame2.Element("InputNumber", (ref UIElementAttribute __attribute) =>
                        {
                            __attribute.Set("TValue", "int");
                            var bindGetValue3 = size;
                            __attribute.Set("Value", bindGetValue3);
                            __attribute.Set("@onchange", EventCallback.Factory.CreateBinder(this, __value => size = __value, bindGetValue3));
                        }, null, key: __key2, sequenceNumber: 1530641482);
                        __frame2.Element("button", (ref UIElementAttribute __attribute) =>
                        {
                            __attribute.Set("type", "submit");
                            __attribute.Set("class", "mgx bg-primary");
                            __attribute.Set("@onclick", EventCallback.Factory.Create(this, (Action)CreateBoard));
                        }, (__frame3, __key3) =>
                        {
                            __frame3.Text(@"Continue", key: __key3, sequenceNumber: 1530641483);
                        }, key: __key2, sequenceNumber: 1530641484);
                    }
                    else
                    {
                        __frame2.Element("table", null, (__frame3, __key3) =>
                        {
                            for (int _y = 0; _y < size; _y++)
                            {
                                var y = _y;
                                __frame3.Element("tr", null, (__frame4, __key4) =>
                                {
                                    for (int _x = 0; _x < size; _x++)
                                    {
                                        var x = _x;
                                        var board = boards[y, x];
                                        __frame4.Element("td", null, (__frame5, __key5) =>
                                        {
                                            __frame5.Element("InputNumber", (ref UIElementAttribute __attribute) =>
                                            {
                                                __attribute.Set("TValue", "int?");
                                                var bindGetValue6 = board.Entry;
                                                __attribute.Set("Value", bindGetValue6);
                                                __attribute.Set("@onchange", EventCallback.Factory.CreateBinder(this, (__value) =>
                                                {
                                                    board.Entry = __value;
                                                    Validate(x, y);
                                                }, bindGetValue6));
                                                __attribute.Set("readonly", (board.IsFixed));
                                                __attribute.Set("class", ($"text-center bd-0 wx-04 hx-04 {(board.IsFixed ? " bg-dark-01" : board.HasError ? " bg-error-01" : board.Entry > 0 ? " bg-success-01": " bg-primary-01")}"));
                                            }, null, key: __key5, sequenceNumber: 1530641485);
                                        }, key: x, sequenceNumber: 1530641486);
                                    }
                                }, key: y, sequenceNumber: 1530641487);
                            }
                        }, key: __key2, sequenceNumber: 1530641488);
                    }
                }, key: __key1, sequenceNumber: 1530641489);
            }, sequenceNumber: 1530641490);
        }

    }
}

