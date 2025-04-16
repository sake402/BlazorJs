//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using BlazorJs.Core;

//namespace BlazorJs.Generator
//{
//    internal class TypicalGenerated
//    {
//        int value = 1;
//        int[] values = new[] { 1, 2, 3 };
//        RenderFragment? childContent;


//        public void CreateThisComponent(IUIFrame context, object? key = null)
//        {
//            //<p class="cx" ... d="@value">A<h1></h1></p>
//            context.Element("p", (ref UIElementAttribute attribute) =>
//            {
//                attribute.Set("class", "cx");
//                attribute.Set("style", "b:red");
//                attribute.Set("a", "c");
//                attribute.Set("d", () => value);
//            },
//            (context, key) =>
//            {
//                UIText? p_a = null;
//                UIElement? h1 = null;
//                UIElement? span = null;
//                UIElement? ul = null;
//                context.Frame((context, key) =>
//               {
//                   p_a ??= context.Text("A");
//                   h1 = context.Element(
//                       "h1",
//                       null,
//                       (context, key) =>
//                       {
//                           UIText? hh = null;
//                           UIText? vl = null;
//                           hh = context.Text("HH");
//                           vl = context.Text(() => value);
//                       });
//                   //@if (value & 1){
//                   //<span>
//                   //</span>
//                   //}
//                   if ((value & 1) != 0)
//                   {
//                       ul?.Dispose();
//                       span ??= context.Element("span", null);
//                   }
//                   else if (value == 2)
//                   {
//                       span?.Dispose();
//                       ul ??= context.Element("ul", null);
//                   }
//                   else
//                   {
//                       span?.Dispose();
//                       ul?.Dispose();
//                   }

//                   foreach (var value in values)
//                   {
//                       context.Frame((context, key) =>
//                       {
//                           context.Element(
//                               "div",
//                               null,
//                               (context, key) =>
//                               {
//                                   context.Text(() => value);
//                               });
//                           context.Frame(childContent);
//                       }, key: value);
//                   }

//                   context.Component<TypicalNestedComponent>((attribute) =>
//                   {
//                       attribute.Prop = 1;
//                       attribute.ChildContent = (context, key) =>
//                       {
//                           context.Element("ul");
//                       };
//                       attribute.ChildContent2 = (i) => (context, key) =>
//                       {
//                           context.Element("ul" + i);
//                       };
//                   });
//               }, key: key);
//            });
//        }

//        //Element? p_1;
//        //void Create_P_1(FragmentContext context)
//        //{
//        //    p_1 ??= context.Element("p", attribute =>
//        //    {
//        //        attribute.Set("class", "cx");
//        //        attribute.Set("style", "b:red");
//        //        attribute.Set("a", "c");
//        //        attribute.Set("d", () => value);
//        //    }, Create_P_A, Create_P_H1, Create_if_block, Create_foreach, Create_childContent_1, Create_childContent_2);
//        //}

//        //Text? p_a;
//        //void Create_P_A(FragmentContext context)
//        //{
//        //    p_a ??= context.Text("A");
//        //}

//        //Element? p_h1;
//        //void Create_P_H1(FragmentContext context)
//        //{
//        //    p_h1 ??= context.Element("h1", null, Create_P_H1_HH, Create_P_H1_Value);
//        //}

//        //Text? p_h1_hh;
//        //void Create_P_H1_HH(FragmentContext context)
//        //{
//        //    p_h1_hh ??= context.Text("HH");
//        //}

//        //Text? p_h1_value;
//        //void Create_P_H1_Value(FragmentContext context)
//        //{
//        //    p_h1_value ??= context.Text(() => value);
//        //}

//        //FragmentContext? block_1;
//        //FragmentContext? block_2;
//        //void Create_if_block(FragmentContext context)
//        //{
//        //    if (value > 1)
//        //    {
//        //        block_1 ??= context.Fragment(Create_Block_span);
//        //    }
//        //    else if (value > 2)
//        //    {
//        //        block_1?.Dispose();
//        //        block_1 = null;
//        //        block_2 ??= context.Fragment(Create_Block_ul);
//        //    }
//        //    else
//        //    {
//        //        block_1?.Dispose();
//        //        block_1 = null;
//        //        block_2?.Dispose();
//        //        block_2 = null;
//        //    }
//        //}

//        //void Create_Block_span(FragmentContext context)
//        //{

//        //}

//        //void Create_Block_ul(FragmentContext context)
//        //{

//        //}


//        //Dictionary<int, foreach_itemContext> foreach_Context = new Dictionary<int, foreach_itemContext>();
//        //void Create_foreach(FragmentContext context)
//        //{
//        //    var clone = new Dictionary<int, foreach_itemContext>(foreach_Context);
//        //    foreach_Context.Clear();
//        //    foreach (var value in values)
//        //    {
//        //        if (clone.TryGetValue(value, out var block))
//        //        {
//        //            clone.Remove(value);
//        //        }
//        //        else
//        //        {
//        //            block = new foreach_itemContext(value);
//        //        }
//        //        foreach_Context[value] = block;
//        //        block.Create_foreach_item(context);
//        //    }
//        //    foreach (var removed in clone)
//        //    {
//        //        removed.Value.Dispose();
//        //    }
//        //}

//        //class foreach_itemContext : FragmentContext<int>
//        //{
//        //    public foreach_itemContext(int value) : base(value)
//        //    {

//        //    }
//        //    Element? div;
//        //    Text? text;
//        //    internal void Create_foreach_item(FragmentContext parentContext)
//        //    {
//        //        div ??= this.Element("div", null);
//        //        text ??= this.Text(() => Value);
//        //        childContent(this);
//        //    }
//        //}

//        //void Create_childContent_1(FragmentContext context)
//        //{
//        //    childContent?.Invoke(context);
//        //}

//        //void Create_childContent_2(FragmentContext context)
//        //{
//        //    childContent?.Invoke(context);
//        //}

//        //TypicalNestedComponent? nestedComponent;
//        //void Create_P_NestedComponent(FragmentContext context)
//        //{
//        //    nestedComponent ??= new TypicalNestedComponent()
//        //    {
//        //        Prop = 1
//        //    };
//        //    nestedComponent.P2 = value;
//        //    nestedComponent.ChildContent = Create_P_NestedComponent_ChildContent_span;
//        //}

//        //class NestedComponent_ChildContent_Context : FragmentContext<int>
//        //{
//        //    Element? span;
//        //    void Create_ChildContent(FragmentContext context)
//        //    {
//        //        span ??= context.Element("span");
//        //        childContent(context);
//        //    }
//        //}
//        //void Create_P_NestedComponent_ChildContent_span(FragmentContext context)
//        //{
//        //    context.Fragment<NestedComponent_ChildContent_Context>();
//        //}
//    }
//}
