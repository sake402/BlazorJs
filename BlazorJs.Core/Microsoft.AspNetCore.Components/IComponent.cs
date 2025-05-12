using H5;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Components
{
    public partial interface IComponent
    {
        void Attach(RenderHandle renderHandle);
        Task SetParametersAsync(ParameterView parameters);
    }
}
