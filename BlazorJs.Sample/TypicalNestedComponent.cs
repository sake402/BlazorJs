//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using BlazorJs.Core;

//namespace BlazorJs.Generator
//{
//    public class TypicalNestedComponent : ComponentBase
//    {
//        int i = 0;
//        public TypicalNestedComponent()
//        {
//            Task.Run(async () =>
//            {
//                while (true)
//                {
//                    await Task.Delay(5000);
//                    i++;
//                    this.StateHasChanged();
//                }
//            });
//        }

//        public int Prop { get; set; }
//        public int P2 { get; set; }
//        public RenderFragment? ChildContent { get; set; }
//        public RenderFragment<int> ChildContent2 { get; set; }
//        public override void Build(IUIFrame context)
//        {
//            context.Element(
//                "h2",
//                null,
//                (context, key) =>
//            {
//                context.Text("HAB" + i);
//                if ((i & 1) == 0)
//                {
//                    context.Element("pp");
//                }
//                context.Frame((context, key) =>
//                {
//                    ChildContent?.Invoke(context);
//                });
//                for (int i = 0; i < 10; i++)
//                {
//                    context.Frame((context, key) =>
//                    {
//                        ChildContent2?.Invoke(i)?.Invoke(context);
//                    }, key: i);
//                }
//            });
//            base.Build(context);
//        }
//    }
//}
