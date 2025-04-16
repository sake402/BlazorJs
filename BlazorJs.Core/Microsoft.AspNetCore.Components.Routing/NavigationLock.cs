using System;
using System.Threading.Tasks;
using static H5.Core.dom;

namespace Microsoft.AspNetCore.Components.Routing
{
    /// <summary>
    /// A component that can be used to intercept navigation events. 
    /// </summary>
    public partial class NavigationLock : ComponentBase
    {
        private readonly string _id = Guid.NewGuid().ToString("D");

        private IDisposable _locationChangingRegistration;
        private bool _hasLocationChangingHandler;
        private bool _confirmExternalNavigation;

        private bool HasLocationChangingHandler => OnBeforeInternalNavigation.HasDelegate;

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        /// <summary>
        /// Gets or sets a callback to be invoked when an internal navigation event occurs.
        /// </summary>
        [Parameter]
        public EventCallback<LocationChangingContext> OnBeforeInternalNavigation { get; set; }

        /// <summary>
        /// Gets or sets whether a browser dialog should prompt the user to either confirm or cancel
        /// external navigations.
        /// </summary>
        [Parameter]
        public bool ConfirmExternalNavigation { get; set; }

        protected internal override void OnParametersSet()
        {
            if (_hasLocationChangingHandler != HasLocationChangingHandler ||
                _confirmExternalNavigation != ConfirmExternalNavigation)
            {
                //_renderHandle.Render(static builder => { });
            }

            base.OnParametersSet();
        }

        static int onBeforeUnloadSubscribed;
        static void OnBeforeUnload(Event e)
        {
            e.preventDefault();
            e.returnValue = true;
        }

        static void DisableNavigationPrompt()
        {
            onBeforeUnloadSubscribed--;
            if (onBeforeUnloadSubscribed == 0)
            {
                window.removeEventListener("beforeunload", OnBeforeUnload);
            }
        }

        static void EnableNavigationPrompt()
        {
            if (onBeforeUnloadSubscribed == 0)
            {
                window.addEventListener("beforeunload", OnBeforeUnload);
            }
            onBeforeUnloadSubscribed++;
        }

        protected internal override Task OnAfterRenderAsync(bool firstRender)
        {
            if (_hasLocationChangingHandler != HasLocationChangingHandler)
            {
                _hasLocationChangingHandler = HasLocationChangingHandler;
                _locationChangingRegistration?.Dispose();
                _locationChangingRegistration = _hasLocationChangingHandler ?
                     NavigationManager.RegisterLocationChangingHandler(OnLocationChanging)
                    : null;
            }

            if (_confirmExternalNavigation != ConfirmExternalNavigation)
            {
                _confirmExternalNavigation = ConfirmExternalNavigation;
                if (_confirmExternalNavigation)
                {
                    EnableNavigationPrompt();
                }
                else
                {
                    DisableNavigationPrompt();
                }
            }
            return base.OnAfterRenderAsync(firstRender);
        }

        private async Task OnLocationChanging(LocationChangingContext context)
        {
            await OnBeforeInternalNavigation.InvokeAsync(context);
        }

        public override void Dispose()
        {
            _locationChangingRegistration?.Dispose();

            if (_confirmExternalNavigation)
            {
                DisableNavigationPrompt();
            }
            base.Dispose();
        }
    }
}
