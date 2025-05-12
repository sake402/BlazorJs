namespace Microsoft.AspNetCore.Components
{
    /// <summary>
    /// Provides information about the platform that the component is running on.
    /// </summary>
    public sealed class RendererInfo
    {
        /// <summary>
        /// Gets the name of the platform.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets a flag to indicate if the platform is interactive.
        /// </summary>
        public bool IsInteractive { get; }

        /// <param name="rendererName">The name of the platform.</param>
        /// <param name="isInteractive">A flag to indicate if the platform is interactive.</param>
        public RendererInfo(string rendererName, bool isInteractive)
        {
            Name = rendererName;
            IsInteractive = isInteractive;
        }
    }
}
