using System.Threading.Tasks;

namespace System
{
    public interface IAsyncEnumerable<T>
    {
        IAsyncEnumerator<T> GetAsyncEnumerator();
    }

    public interface IAsyncEnumerator<T> : IAsyncDisposable
    {
        ValueTask<bool> MoveNextAsync();
        T Current { get; }
    }

    public interface IAsyncDisposable
    {
        ValueTask DisposeAsync();
    }
}
