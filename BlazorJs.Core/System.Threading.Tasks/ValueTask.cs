
namespace System.Threading.Tasks
{
    //[H5.Name("System.Threading.Tasks.Task")]
    public class ValueTask : Task
    {
        Task task;

        public ValueTask(Task task) : base(null)
        {
            this.task = task;
        }

        //public TaskAwaiter GetAwaiter() => (task ?? Task.CompletedTask).GetAwaiter();

        public Task AsTask() => task ?? this;
        public ValueTask(Action action) : base(action)
        {
        }

        public ValueTask(Action<object> action, object state) : base(action, state)
        {
        }

        public new static ValueTask CompletedTask => new ValueTask(Task.CompletedTask);
        public new static ValueTask<T> FromResult<T>(T t) => new ValueTask<T>(Task.FromResult<T>(t));
    }

    [H5.Convention(Member = H5.ConventionMember.Field | H5.ConventionMember.Method, Notation = H5.Notation.CamelCase)]
    public class ValueTask<TResult> : Task<TResult>
    {

        Task<TResult> task;

        public ValueTask(Task<TResult> task) : base(null)
        {
            this.task = task;
        }

        public ValueTask(Func<TResult> function) : base(function)
        {
        }

        public ValueTask(Func<object, TResult> function, object state) : base(function, state)
        {
        }

        public new TResult Result => task != null ? task.Result : base.Result;
        public Task<TResult> AsTask() => task ?? this;
        public new Task ContinueWith(Action<Task<TResult>> continuationAction) => task?.ContinueWith(continuationAction) ?? base.ContinueWith(continuationAction);
        public new Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction) => task?.ContinueWith(continuationFunction) ?? base.ContinueWith(continuationFunction);

        public new TaskAwaiter<TResult> GetAwaiter() => task?.GetAwaiter() ?? base.GetAwaiter();

        public new void SetResult(TResult result)
        {
            if (task != null)
                task.SetResult(result);
            else base.SetResult(result);
        }
    }
}