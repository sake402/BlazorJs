// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Rendering;
using BlazorJs.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Microsoft.AspNetCore.Components.Authorization
{

    /// <summary>
    /// Combines the behaviors of <see cref="AuthorizeView"/> and <see cref="RouteView"/>,
    /// so that it displays the page matching the specified route but only if the user
    /// is authorized to see it.
    ///
    /// Additionally, this component supplies a cascading parameter of type <see cref="Task{AuthenticationState}"/>,
    /// which makes the user's current authentication state available to descendants.
    /// </summary>
    public sealed partial class AuthorizeRouteView : RouteView
    {
        // We expect applications to supply their own authorizing/not-authorized content, but
        // it's better to have defaults than to make the parameters mandatory because in some
        // cases they will never be used (e.g., "authorizing" in out-of-box server-side Blazor)
        private static readonly RenderFragment<AuthenticationState> _defaultNotAuthorizedContent
            = state => (builder, key) => builder.AddContent(0, "Not authorized");
        private static readonly RenderFragment _defaultAuthorizingContent
            = (builder, key) => builder.AddContent(0, "Authorizing...");

        private readonly RenderFragment _renderAuthorizeRouteViewCoreDelegate;
        private readonly RenderFragment<AuthenticationState> _renderAuthorizedDelegate;
        private readonly RenderFragment<AuthenticationState> _renderNotAuthorizedDelegate;
        private readonly RenderFragment _renderAuthorizingDelegate;

        /// <summary>
        /// Initialize a new instance of a <see cref="AuthorizeRouteView"/>.
        /// </summary>
        public AuthorizeRouteView()
        {
            // Cache the rendering delegates so that we only construct new closure instances
            // when they are actually used (e.g., we never prepare a RenderFragment bound to
            // the NotAuthorized content except when you are displaying that particular state)
            RenderFragment renderBaseRouteViewDelegate = base.BuildRenderTree;
            _renderAuthorizedDelegate = authenticateState => renderBaseRouteViewDelegate;
            _renderNotAuthorizedDelegate = authenticationState => (builder, key) => RenderNotAuthorizedInDefaultLayout(builder, key, authenticationState);
            _renderAuthorizingDelegate = RenderAuthorizingInDefaultLayout;
            _renderAuthorizeRouteViewCoreDelegate = RenderAuthorizeRouteViewCore;
        }

        /// <summary>
        /// The content that will be displayed if the user is not authorized.
        /// </summary>
        [Parameter]
        public RenderFragment<AuthenticationState> NotAuthorized { get; set; }

        /// <summary>
        /// The content that will be displayed while asynchronous authorization is in progress.
        /// </summary>
        [Parameter]
        public RenderFragment Authorizing { get; set; }

        /// <summary>
        /// The resource to which access is being controlled.
        /// </summary>
        [Parameter]
        public object Resource { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> ExistingCascadedAuthenticationState { get; set; }

        protected internal override void BuildRenderTree(IUIFrame frame, object key = null)
        {
            if (ExistingCascadedAuthenticationState != null)
            {
                // If this component is already wrapped in a <CascadingAuthenticationState> (or another
                // compatible provider), then don't interfere with the cascaded authentication state.
                _renderAuthorizeRouteViewCoreDelegate(frame, key);
            }
            else
            {
                frame.Component<CascadingAuthenticationState>(component =>
                {
                    component.ChildContent = _renderAuthorizeRouteViewCoreDelegate;
                }, sequenceNumber: 1);
            }
        }

        private void RenderAuthorizeRouteViewCore(IUIFrame frame, object key = null)
        {
            frame.Component<AuthorizeRouteViewCore>(component =>
            {
                component.RouteData = RouteData;
                component.Authorized = _renderAuthorizedDelegate;
                component.Authorizing = _renderAuthorizingDelegate;
                component.NotAuthorized = _renderNotAuthorizedDelegate;
                component.Resource = Resource;
            }, sequenceNumber: Utility.AuthorizeRouteView_AuthorizeRouteViewCore_SequenceNumber);
        }

        private void RenderContentInDefaultLayout(IUIFrame frame, object key, RenderFragment content)
        {
            frame.Component<LayoutView>(component =>
            {
                component.Layout = DefaultLayout;
                component.ChildContent = content;
            }, sequenceNumber: Utility.AuthorizeRouteView_LayoutView_SequenceNumber);
        }

        private void RenderNotAuthorizedInDefaultLayout(IUIFrame builder, object key, AuthenticationState authenticationState)
        {
            var content = NotAuthorized ?? _defaultNotAuthorizedContent;
            RenderContentInDefaultLayout(builder, key, content(authenticationState));
        }

        private void RenderAuthorizingInDefaultLayout(IUIFrame builder, object key = null)
        {
            var content = Authorizing ?? _defaultAuthorizingContent;
            RenderContentInDefaultLayout(builder, key, content);
        }

        private sealed partial class AuthorizeRouteViewCore : AuthorizeViewCore
        {
            [Parameter]
            public RouteData RouteData { get; set; } = default;

            protected override IAuthorizeData[] GetAuthorizeData()
                => AttributeAuthorizeDataCache.GetAuthorizeDataForType(RouteData.PageType);
        }
    }
}
