//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BlazorJs.Core
//{
//    public delegate UIFragment FragmentConstructor();

//    //public delegate void FragmentBuilder<T>(FragmentContext<T> context);

//    public partial class FragmentBuilder : IDisposable
//    {
//        public void Dispose()
//        {
//            throw new NotImplementedException();
//        }

//        public UIElement Element(string tag, Action<UIElementAttribute>? attributeBuilder, params FragmentConstructor[] children)
//        {
//            var uiElement = new UIElement(tag, children);
//            attributeBuilder?.Invoke(uiElement.Attributes);
//            return uiElement;
//        }

//        public UIText Text(object text)
//        {
//            var uiText = new UIText(text);
//            return uiText;
//        }

//        public UIText Text(Func<object> text)
//        {
//            var uiText = new UIText(text);
//            return uiText;
//        }

//        public UIFragment Fragment(FragmentConstructor createFragment, object? key = null)
//        {
//            var uiFragment = createFragment();
//            return uiFragment;
//        }

//        //public FragmentContext<T> Fragment<T>(FragmentRenderer fragment)
//        //{

//        //}

//        public void Component<T>(Action<T>? attributeBuilder)
//        {

//        }
//    }

//    public partial class FragmentContext<T> : FragmentBuilder
//    {
//        public FragmentContext(T value)
//        {
//            Value = value;
//        }

//        public T Value { get; }
//    }
//}
