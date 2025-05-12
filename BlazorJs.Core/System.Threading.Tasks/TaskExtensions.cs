using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.Threading.Tasks
{
    public static class TaskExtensions
    {
        public static void TrySetCanceled<T>(this TaskCompletionSource<T> tcs, CancellationToken token)
        {
            tcs.TrySetCanceled();
        }
    }
}
