namespace Microsoft.AspNetCore.Components
{
    public enum ComponentLifeCycle
    {
        Unknown,
        OnInjectingService,
        OnParametersSetting,
        OnParametersSettingAsnc,
        OnInitializing,
        OnInitializingAsync,
        OnRendering,
        OnAfterRender,
        OnAfterRenderAsnyc,
        OnEventHandling
    }
}
