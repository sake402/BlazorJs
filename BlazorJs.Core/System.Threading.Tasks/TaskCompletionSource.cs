namespace System.Threading.Tasks
{
    public class TaskCompletionSource : TaskCompletionSource<object>
    {
        public void TrySetResult() => TrySetResult(default);
        public void SetResult() => SetResult(default);
    }
}