using System.Threading.Tasks;

namespace System
{
    public interface IProgress<in T>
    {
        //
        // Summary:
        //     Reports a progress update.
        //
        // Parameters:
        //   value:
        //     The value of the updated progress.
        void Report(T value);
    }

}
