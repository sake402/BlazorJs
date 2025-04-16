using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Collections.Generic;
using System.Text;
using BlazorJs.Core;
using static H5.Core.dom;

namespace BlazorJs.Core.Components.LiteRouting
{
    public partial class LiteRouter : ComponentBase
    {
        [Inject] public NavigationManager Navigation { get; set; }
        public Type DefaultLayout { get; set; }
        public RenderFragment NotFound { get; set; }

        int routeIndexSequenceNumber;
        RouteRegistration route;
        object routeParameter;

        void RefreshRoute(string location = null)
        {
            routeParameter = null;
            route = RouteTableFactory.Match(location ?? (document.location.pathname + document.location.search), out routeIndexSequenceNumber, out routeParameter);
        }

        RenderFragment RenderLayout(Type layoutType, RenderFragment body)
        {
            //layoutType.GetCustomAttributes()
            return (frame, key) =>
            {
                frame.Component(layoutType, component =>
                {
                    ((ILayoutComponent)component).Body = body;
                }, sequenceNumber: Utility.LiteRouter_Layout_SequenceNumber);
            };
        }

        RenderFragment Found()
        {
            RenderFragment pageContent = (frame, key) =>
            {
                frame.Component(route.PageType, component =>
                {
                    if (route.ParameterSetter != null && routeParameter != null)
                    {
                        foreach (var name in Object.GetOwnPropertyNames(routeParameter))
                        {
                            route.ParameterSetter(component, name, (string)routeParameter[name]);
                        }
                    }
                }, sequenceNumber: Utility.LiteRouter_Page_SequenceNumber + routeIndexSequenceNumber);
            };
            var layout = route.Layout ?? DefaultLayout;
            if (layout != null)
            {
                return RenderLayout(layout, pageContent);
            }
            return pageContent;
        }

        protected internal override void OnInitialized()
        {
            RefreshRoute();
            Navigation.LocationChanged += Navigation_OnLocationChanged;
            base.OnInitialized();
        }

        public override void Dispose()
        {
            Navigation.LocationChanged -= Navigation_OnLocationChanged;
            base.Dispose();
        }
        private void Navigation_OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            RefreshRoute(e.Location);
            StateHasChanged();
        }
    }
}
