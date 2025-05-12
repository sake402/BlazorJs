namespace Microsoft.AspNetCore.Components
{
    //Component parameters are set directly, parameter view does nothing
    public readonly struct ParameterView
    {
        public struct ParameterViewValue
        {
            public string Name => default;
            public object Value => default;
        }

        public struct ParameterViewEnumerator
        {
            public bool MoveNext() => false;
            public ParameterViewValue Current => default;
        }
        public ParameterViewEnumerator GetEnumerator()
        {
            return default;
        }

        public void SetParameterProperties(IComponent component)
        {
            //do nothing. component parameters are set immediately in this port
        }
    }
}
