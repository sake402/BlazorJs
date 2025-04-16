using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorJs.Core;


namespace Microsoft.AspNetCore.Components.Authorization
{
    public partial class CascadingAuthenticationState : ComponentBase, IDisposable
    {
        private Task<AuthenticationState> _currentAuthenticationStateTask;

        /// <summary>
        /// The content to which the authentication state should be provided.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        protected internal override void OnInitialized()
        {
            AuthenticationStateProvider.AuthenticationStateChanged += OnAuthenticationStateChanged;

            _currentAuthenticationStateTask = AuthenticationStateProvider
                .GetAuthenticationStateAsync();
        }

        private void OnAuthenticationStateChanged(Task<AuthenticationState> newAuthStateTask)
        {
            InvokeAsync(() =>
            {
                _currentAuthenticationStateTask = newAuthStateTask;
                StateHasChanged();
            }).FireAndForget();
        }

        void IDisposable.Dispose()
        {
            AuthenticationStateProvider.AuthenticationStateChanged -= OnAuthenticationStateChanged;
        }
    }
}
