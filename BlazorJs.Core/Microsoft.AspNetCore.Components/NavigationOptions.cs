namespace Microsoft.AspNetCore.Components
{
    /// <summary>
    /// Additional options for navigating to another URI.
    /// </summary>
    public partial struct NavigationOptions
    {
        /// <summary>
        /// If true, bypasses client-side routing and forces the browser to load the new page from the server, whether or not the URI would normally be handled by the client-side router.
        /// </summary>
        public bool ForceLoad { get; set; }

        /// <summary>
        /// If true, replaces the currently entry in the history stack.
        /// If false, appends the new entry to the history stack.
        /// </summary>
        public bool ReplaceHistoryEntry { get; set; }

        /// <summary>
        /// Gets or sets the state to append to the history entry.
        /// </summary>
        public object HistoryEntryState { get; set; }
    }
}
