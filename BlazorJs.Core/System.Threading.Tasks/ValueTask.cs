namespace System.Threading.Tasks
{
    public struct ValueTask
    {
        public static ValueTask CompletedTask => new ValueTask(Task.CompletedTask);
        public static ValueTask<T> FromResult<T>(T t) => new ValueTask<T>(Task.FromResult<T>(t));

        Task task;

        public ValueTask(Task task)
        {
            this.task = task;
        }

        public TaskAwaiter GetAwaiter() => (task ?? Task.CompletedTask).GetAwaiter();

        public Task AsTask() => task ?? Task.CompletedTask;
    }

    public struct ValueTask<T>
    {
        Task<T> task;

        public ValueTask(Task<T> task)
        {
            this.task = task;
        }

        public TaskAwaiter<T> GetAwaiter() => (task ?? Task.FromResult<T>(default)).GetAwaiter();
        public Task AsTask() => task ?? Task.FromResult<T>(default);
    }
}