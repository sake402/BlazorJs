//using System.Text;
//using BlazorJs.Core;

//namespace BlazorJs.Generator
//{
//    public class TestHtmlPlatformRenderer : IUIPlatformRenderer
//    {
//        UIFrame rootFragment;
//        public IServiceProvider Services { get; }
//        StringBuilder javascript = new StringBuilder();

//        public TestHtmlPlatformRenderer(IServiceProvider services)
//        {
//            Services = services;
//            //rootFragment = new UIFrame(this);
//        }

//        public void Add(RenderFragment fragment)
//        {
//            fragment(rootFragment);
//        }

//        static string GetUID(IUIContent content)  
//        {
//            if (content.State.Key == null)
//            {
//                return $"{content.State.Id}";
//            }
//            return $"[{content.State.Id},{content.State.Key.GetHashCode().ToString() ?? ""}]";
//        }

//        public void CreateText(/*ref */UIText text)
//        {
//            var before = text.GetAfter();
//            //javascript.AppendLine("{");
//            //javascript.AppendLine($"var $ = text('{text.GetText()}', {text.Id});");
//            javascript.AppendLine($"insert(text('{text.GetText()}',{GetUID(text)}),{GetUID(text.State.ParentFrame)}{(before != null ? "," : "")}{before?.State.Id.ToString() ?? ""});");
//            //javascript.AppendLine("}");
//        }

//        public void RemoveText(/*ref */UIText text)
//        {
//            javascript.AppendLine($"remove({GetUID(text)});");
//        }

//        public void UpdateText(/*ref*/ UIText text)
//        {
//            javascript.AppendLine($"update({GetUID(text)},'{text.GetText()}');");
//        }

//        public void CreateElement(/*ref */UIElement element)
//        {
//            var before = element.GetAfter();
//            //javascript.AppendLine("{");
//            //javascript.AppendLine($"var $ = element('{element.Tag}', {element.Id});");
//            javascript.AppendLine($"insert(element('{element.Tag}',{GetUID(element)}),{GetUID(element.State.ParentFrame)}{(before != null ? $",{GetUID(before)}" : "")});");
//            //javascript.AppendLine("}");
//        }

//        public void SetElementAttribute(/*ref*/ UIElement element, string key, object value)
//        {
//            javascript.AppendLine($"attr({GetUID(element)},'{key}',{(value is string ? "'" : "")}{value}{(value is string ? "'" : "")});");
//        }

//        public void RemoveElement(/*ref */UIElement element)
//        {
//            javascript.AppendLine($"remove({GetUID(element)});");
//        }

//        public void CreateRegion(/*ref */UIFrame frame)
//        {
//            var before = frame.GetAfter();
//            javascript.AppendLine($"insert(region({GetUID(frame)}),{GetUID(frame.State.ParentFrame)}{(before != null ? $",{GetUID(before)}" : "")});");
//        }

//        public void CreateRegion(/*ref */ComponentBase component)
//        {
//            var before = component.GetAfter();
//            javascript.AppendLine($"insert(component('{component.ShadowName}',{GetUID(component)}),{GetUID(component.State.ParentFrame)}{(before != null ? $",{GetUID(before)}" : "")});");
//        }

//        public void Flush()
//        {
//            //Console.WriteLine(javascript.ToString());
//            javascript.Clear();
//        }

//        public void Render(IUIContent ui)
//        {
//            ui.Build();
//            Flush();
//        }

//        public override string ToString()
//        {
//            return javascript.ToString();
//        }
//    }
//}
