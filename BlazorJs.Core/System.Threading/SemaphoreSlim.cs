using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Threading
{
    public class SemaphoreSlim : IDisposable
    {
        int taken;
        int maxCount;
        //
        // Summary:
        //     Initializes a new instance of the System.Threading.SemaphoreSlim class, specifying
        //     the initial number of requests that can be granted concurrently.
        //
        // Parameters:
        //   initialCount:
        //     The initial number of requests for the semaphore that can be granted concurrently.
        //
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     initialCount is less than 0.
        public SemaphoreSlim(int initialCount)
        {
            maxCount = initialCount;
            taken = 0;
        }
        //
        // Summary:
        //     Initializes a new instance of the System.Threading.SemaphoreSlim class, specifying
        //     the initial and maximum number of requests that can be granted concurrently.
        //
        //
        // Parameters:
        //   initialCount:
        //     The initial number of requests for the semaphore that can be granted concurrently.
        //
        //
        //   maxCount:
        //     The maximum number of requests for the semaphore that can be granted concurrently.
        //
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     initialCount is less than 0, or initialCount is greater than maxCount, or maxCount
        //     is equal to or less than 0.
        public SemaphoreSlim(int initialCount, int maxCount)
        {
            taken = 0;
            this.maxCount = maxCount;
        }

        ////
        //// Summary:
        ////     Returns a System.Threading.WaitHandle that can be used to wait on the semaphore.
        ////
        ////
        //// Returns:
        ////     A System.Threading.WaitHandle that can be used to wait on the semaphore.
        ////
        //// Exceptions:
        ////   T:System.ObjectDisposedException:
        ////     The System.Threading.SemaphoreSlim has been disposed.
        //public WaitHandle AvailableWaitHandle { get; }
        //
        // Summary:
        //     Gets the number of remaining threads that can enter the System.Threading.SemaphoreSlim
        //     object.
        //
        // Returns:
        //     The number of remaining threads that can enter the semaphore.
        public int CurrentCount => maxCount - taken;

        //
        // Summary:
        //     Releases all resources used by the current instance of the System.Threading.SemaphoreSlim
        //     class.
        public void Dispose() { }
        //
        // Summary:
        //     Releases the System.Threading.SemaphoreSlim object once.
        //
        // Returns:
        //     The previous count of the System.Threading.SemaphoreSlim.
        //
        // Exceptions:
        //   T:System.ObjectDisposedException:
        //     The current instance has already been disposed.
        //
        //   T:System.Threading.SemaphoreFullException:
        //     The System.Threading.SemaphoreSlim has already reached its maximum size.
        public int Release()
        {
            return Release(1);
        }
        //
        // Summary:
        //     Releases the System.Threading.SemaphoreSlim object a specified number of times.
        //
        //
        // Parameters:
        //   releaseCount:
        //     The number of times to exit the semaphore.
        //
        // Returns:
        //     The previous count of the System.Threading.SemaphoreSlim.
        //
        // Exceptions:
        //   T:System.ObjectDisposedException:
        //     The current instance has already been disposed.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     releaseCount is less than 1.
        //
        //   T:System.Threading.SemaphoreFullException:
        //     The System.Threading.SemaphoreSlim has already reached its maximum size.
        List<TaskCompletionSource<bool>> blockedWaits = new List<TaskCompletionSource<bool>>();
        public int Release(int releaseCount)
        {
            //if (releaseCount> tak)
            int currentCount = CurrentCount;
            while (releaseCount-- > 0)
            {
                if (blockedWaits.Count > 0)
                {
                    var task = blockedWaits.Last();
                    blockedWaits.Remove(task);
                    task.SetResult(true);
                }
            }
            return currentCount;
        }
        //
        // Summary:
        //     Blocks the current thread until it can enter the System.Threading.SemaphoreSlim.
        //
        //
        // Exceptions:
        //   T:System.ObjectDisposedException:
        //     The current instance has already been disposed.
        public void Wait()
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Blocks the current thread until it can enter the System.Threading.SemaphoreSlim,
        //     using a 32-bit signed integer that specifies the timeout.
        //
        // Parameters:
        //   millisecondsTimeout:
        //     The number of milliseconds to wait, System.Threading.Timeout.Infinite(-1) to
        //     wait indefinitely, or zero to test the state of the wait handle and return immediately.
        //
        //
        // Returns:
        //     true if the current thread successfully entered the System.Threading.SemaphoreSlim;
        //     otherwise, false.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     millisecondsTimeout is a negative number other than -1, which represents an infinite
        //     timeout -or- timeout is greater than Int32.MaxValue.
        //
        //   T:System.ObjectDisposedException:
        //     The System.Threading.SemaphoreSlim has been disposed.
        public bool Wait(int millisecondsTimeout)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Blocks the current thread until it can enter the System.Threading.SemaphoreSlim,
        //     using a 32-bit signed integer that specifies the timeout, while observing a System.Threading.CancellationToken.
        //
        //
        // Parameters:
        //   millisecondsTimeout:
        //     The number of milliseconds to wait, System.Threading.Timeout.Infinite(-1) to
        //     wait indefinitely, or zero to test the state of the wait handle and return immediately.
        //
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken to observe.
        //
        // Returns:
        //     true if the current thread successfully entered the System.Threading.SemaphoreSlim;
        //     otherwise, false.
        //
        // Exceptions:
        //   T:System.OperationCanceledException:
        //     cancellationToken was canceled.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     millisecondsTimeout is a negative number other than -1, which represents an infinite
        //     timeout. -or- millisecondsTimeout is greater than Int32.MaxValue.
        //
        //   T:System.ObjectDisposedException:
        //     The System.Threading.SemaphoreSlim instance has been disposed, or the System.Threading.CancellationTokenSource
        //     that created cancellationToken has been disposed.
        public bool Wait(int millisecondsTimeout, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Blocks the current thread until it can enter the System.Threading.SemaphoreSlim,
        //     using a System.TimeSpan to specify the timeout.
        //
        // Parameters:
        //   timeout:
        //     A System.TimeSpan that represents the number of milliseconds to wait, a System.TimeSpan
        //     that represents -1 milliseconds to wait indefinitely, or a System.TimeSpan that
        //     represents 0 milliseconds to test the wait handle and return immediately.
        //
        // Returns:
        //     true if the current thread successfully entered the System.Threading.SemaphoreSlim;
        //     otherwise, false.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     timeout is a negative number other than -1, which represents an infinite timeout.
        //     -or- timeout is greater than Int32.MaxValue.
        //
        //   T:System.ObjectDisposedException:
        //     The semaphoreSlim instance has been disposed.
        public bool Wait(TimeSpan timeout)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Blocks the current thread until it can enter the System.Threading.SemaphoreSlim,
        //     using a System.TimeSpan that specifies the timeout, while observing a System.Threading.CancellationToken.
        //
        //
        // Parameters:
        //   timeout:
        //     A System.TimeSpan that represents the number of milliseconds to wait, a System.TimeSpan
        //     that represents -1 milliseconds to wait indefinitely, or a System.TimeSpan that
        //     represents 0 milliseconds to test the wait handle and return immediately.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken to observe.
        //
        // Returns:
        //     true if the current thread successfully entered the System.Threading.SemaphoreSlim;
        //     otherwise, false.
        //
        // Exceptions:
        //   T:System.OperationCanceledException:
        //     cancellationToken was canceled.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     timeout is a negative number other than -1, which represents an infinite timeout.
        //     -or-. timeout is greater than Int32.MaxValue.
        //
        //   T:System.ObjectDisposedException:
        //     The semaphoreSlim instance has been disposed. -or- The System.Threading.CancellationTokenSource
        //     that created cancellationToken has already been disposed.
        public bool Wait(TimeSpan timeout, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Blocks the current thread until it can enter the System.Threading.SemaphoreSlim,
        //     while observing a System.Threading.CancellationToken.
        //
        // Parameters:
        //   cancellationToken:
        //     The System.Threading.CancellationToken token to observe.
        //
        // Exceptions:
        //   T:System.OperationCanceledException:
        //     cancellationToken was canceled.
        //
        //   T:System.ObjectDisposedException:
        //     The current instance has already been disposed. -or- The System.Threading.CancellationTokenSource
        //     that created cancellationToken has already been disposed.
        public void Wait(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Asynchronously waits to enter the System.Threading.SemaphoreSlim.
        //
        // Returns:
        //     A task that will complete when the semaphore has been entered.
        //
        // Exceptions:
        //   T:System.ObjectDisposedException:
        //     The System.Threading.SemaphoreSlim has been disposed.
        public Task WaitAsync()
        {
            return WaitAsync(int.MaxValue, CancellationToken.None);
        }
        //
        // Summary:
        //     Asynchronously waits to enter the System.Threading.SemaphoreSlim, using a 32-bit
        //     signed integer to measure the time interval.
        //
        // Parameters:
        //   millisecondsTimeout:
        //     The number of milliseconds to wait, System.Threading.Timeout.Infinite (-1) to
        //     wait indefinitely, or zero to test the state of the wait handle and return immediately.
        //
        //
        // Returns:
        //     A task that will complete with a result of true if the current thread successfully
        //     entered the System.Threading.SemaphoreSlim, otherwise with a result of false.
        //
        //
        // Exceptions:
        //   T:System.ObjectDisposedException:
        //     The current instance has already been disposed.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     millisecondsTimeout is a negative number other than -1, which represents an infinite
        //     timeout. -or- millisecondsTimeout is greater than Int32.MaxValue.
        public Task<bool> WaitAsync(int millisecondsTimeout)
        {
            return WaitAsync(millisecondsTimeout, CancellationToken.None);
        }
        //
        // Summary:
        //     Asynchronously waits to enter the System.Threading.SemaphoreSlim, using a 32-bit
        //     signed integer to measure the time interval, while observing a System.Threading.CancellationToken.
        //
        //
        // Parameters:
        //   millisecondsTimeout:
        //     The number of milliseconds to wait, System.Threading.Timeout.Infinite (-1) to
        //     wait indefinitely, or zero to test the state of the wait handle and return immediately.
        //
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken to observe.
        //
        // Returns:
        //     A task that will complete with a result of true if the current thread successfully
        //     entered the System.Threading.SemaphoreSlim, otherwise with a result of false.
        //
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     millisecondsTimeout is a number other than -1, which represents an infinite timeout.
        //     -or- millisecondsTimeout is greater than Int32.MaxValue.
        //
        //   T:System.ObjectDisposedException:
        //     The current instance has already been disposed.
        //
        //   T:System.OperationCanceledException:
        //     cancellationToken was canceled.
        public Task<bool> WaitAsync(int millisecondsTimeout, CancellationToken cancellationToken)
        {
            if (CurrentCount > 0)
            {
                taken++;
                return Task.FromResult(false);
            }
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            blockedWaits.Add(tcs);
            cancellationToken.Register(() =>
            {
                blockedWaits.Remove(tcs);
                tcs.TrySetCanceled();
            });
            if (millisecondsTimeout >= 0 && millisecondsTimeout != int.MaxValue)
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                cts.Token.Register(() =>
                {
                    blockedWaits.Remove(tcs);
                    tcs.TrySetCanceled();
                });
                cts.CancelAfter(millisecondsTimeout);
            }
            return tcs.Task;
        }
        //
        // Summary:
        //     Asynchronously waits to enter the System.Threading.SemaphoreSlim, while observing
        //     a System.Threading.CancellationToken.
        //
        // Parameters:
        //   cancellationToken:
        //     The System.Threading.CancellationToken token to observe.
        //
        // Returns:
        //     A task that will complete when the semaphore has been entered.
        //
        // Exceptions:
        //   T:System.ObjectDisposedException:
        //     The current instance has already been disposed.
        //
        //   T:System.OperationCanceledException:
        //     cancellationToken was canceled.
        public Task WaitAsync(CancellationToken cancellationToken)
        {
            return WaitAsync(int.MaxValue, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously waits to enter the System.Threading.SemaphoreSlim, using a System.TimeSpan
        //     to measure the time interval.
        //
        // Parameters:
        //   timeout:
        //     A System.TimeSpan that represents the number of milliseconds to wait, a System.TimeSpan
        //     that represents -1 milliseconds to wait indefinitely, or a System.TimeSpan that
        //     represents 0 milliseconds to test the wait handle and return immediately.
        //
        // Returns:
        //     A task that will complete with a result of true if the current thread successfully
        //     entered the System.Threading.SemaphoreSlim, otherwise with a result of false.
        //
        //
        // Exceptions:
        //   T:System.ObjectDisposedException:
        //     The current instance has already been disposed.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     timeout is a negative number other than -1, which represents an infinite timeout.
        //     -or- timeout is greater than Int32.MaxValue.
        public Task<bool> WaitAsync(TimeSpan timeout)
        {
            return WaitAsync((int)timeout.TotalMilliseconds, CancellationToken.None);
        }
        //
        // Summary:
        //     Asynchronously waits to enter the System.Threading.SemaphoreSlim, using a System.TimeSpan
        //     to measure the time interval, while observing a System.Threading.CancellationToken.
        //
        //
        // Parameters:
        //   timeout:
        //     A System.TimeSpan that represents the number of milliseconds to wait, a System.TimeSpan
        //     that represents -1 milliseconds to wait indefinitely, or a System.TimeSpan that
        //     represents 0 milliseconds to test the wait handle and return immediately.
        //
        //   cancellationToken:
        //     The System.Threading.CancellationToken token to observe.
        //
        // Returns:
        //     A task that will complete with a result of true if the current thread successfully
        //     entered the System.Threading.SemaphoreSlim, otherwise with a result of false.
        //
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     timeout is a negative number other than -1, which represents an infinite timeout.
        //     -or- timeout is greater than Int32.MaxValue.
        //
        //   T:System.OperationCanceledException:
        //     cancellationToken was canceled.
        //
        //   T:System.ObjectDisposedException:
        //     The System.Threading.SemaphoreSlim has been disposed.
        public Task<bool> WaitAsync(TimeSpan timeout, CancellationToken cancellationToken)
        {
            return WaitAsync(timeout.Milliseconds, cancellationToken);
        }
    }
}
