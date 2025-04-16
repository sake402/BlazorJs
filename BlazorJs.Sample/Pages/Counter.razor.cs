using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorJs.Sample.Pages
{
    public partial class Counter
    {
        object? a = null;
        private int currentCount = 0;
        dynamic ab;
        private void IncrementCount()
        {
            ab = currentCount;
            ab.ToString(ab);
            currentCount += 1;
        }
        private void DecrementCount()
        {
            currentCount -= 1;
        }
    }
}
