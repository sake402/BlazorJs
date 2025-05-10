// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Rendering;
using BlazorJs.Core;
using static H5.Core.dom;

namespace Microsoft.AspNetCore.Components.Web.Virtualization
{

    /// <summary>
    /// Provides functionality for rendering a virtualized list of items.
    /// </summary>
    /// <typeparam name="TItem">The <c>context</c> type for the items being rendered.</typeparam>
    public sealed partial class Virtualize<TItem> : ComponentBase, IVirtualizeJsCallbacks
    {
        private HTMLElement _spacerBefore;

        private HTMLElement _spacerAfter;

        private int _itemsBefore;

        private int _visibleItemCapacity;

        // If the client reports a viewport so large that it could show more than MaxItemCount items,
        // we keep track of the "unused" capacity, which is the amount of blank space we want to leave
        // at the bottom of the viewport (as a number of items). If we didn't leave this blank space,
        // then the bottom spacer would always stay visible and the client would request more items in an
        // infinite (but asynchronous) loop, as it would believe there are more items to render and
        // enough space to render them into.
        private int _unusedItemCapacity;

        private int _itemCount;

        private int _loadedItemsStartIndex;

        private int _lastRenderedItemCount;

        private int _lastRenderedPlaceholderCount;

        private float _itemSize;

        private IEnumerable<TItem> _loadedItems;

        private CancellationTokenSource _refreshCts;

        private Exception _refreshException;

        private ItemsProviderDelegate<TItem> _itemsProvider;

        private RenderFragment<TItem> _itemTemplate;

        private RenderFragment<PlaceholderContext> _placeholder;

        private RenderFragment _emptyContent;

        private bool _loading;

        /// <summary>
        /// Gets or sets the item template for the list.
        /// </summary>
        [Parameter]
        public RenderFragment<TItem> ChildContent { get; set; }

        /// <summary>
        /// Gets or sets the item template for the list.
        /// </summary>
        [Parameter]
        public RenderFragment<TItem> ItemContent { get; set; }

        /// <summary>
        /// Gets or sets the template for items that have not yet been loaded in memory.
        /// </summary>
        [Parameter]
        public RenderFragment<PlaceholderContext> Placeholder { get; set; }

        /// <summary>
        /// Gets or sets the content to show when <see cref="Items"/> is empty
        /// or when the <see cref="ItemsProviderResult&lt;TItem&gt;.TotalItemCount"/> is zero.
        /// </summary>
        [Parameter]
        public RenderFragment EmptyContent { get; set; }

        /// <summary>
        /// Gets the size of each item in pixels. Defaults to 50px.
        /// </summary>
        [Parameter]
        public float ItemSize { get; set; } = 50f;

        /// <summary>
        /// Gets or sets the function providing items to the list.
        /// </summary>
        [Parameter]
        public ItemsProviderDelegate<TItem> ItemsProvider { get; set; }

        /// <summary>
        /// Gets or sets the fixed item source.
        /// </summary>
        [Parameter]
        public ICollection<TItem> Items { get; set; }

        /// <summary>
        /// Gets or sets a value that determines how many additional items will be rendered
        /// before and after the visible region. This help to reduce the frequency of rendering
        /// during scrolling. However, higher values mean that more elements will be present
        /// in the page.
        /// </summary>
        [Parameter]
        public int OverscanCount { get; set; } = 3;

        /// <summary>
        /// Gets or sets the tag name of the HTML element that will be used as the virtualization spacer.
        /// One such element will be rendered before the visible items, and one more after them, using
        /// an explicit "height" style to control the scroll range.
        ///
        /// The default value is "div". If you are placing the <see cref="Virtualize{TItem}"/> instance inside
        /// an element that requires a specific child tag name, consider setting that here. For example when
        /// rendering inside a "tbody", consider setting <see cref="SpacerElement"/> to the value "tr".
        /// </summary>
        [Parameter]
        public string SpacerElement { get; set; } = "div";

        /// <summary>
        /// Gets or sets the maximum number of items that will be rendered, even if the client reports
        /// that its viewport is large enough to show more. The default value is 100.
        ///
        /// This should only be used as a safeguard against excessive memory usage or large data loads.
        /// Do not set this to a smaller number than you expect to fit on a realistic-sized window, because
        /// that will leave a blank gap below and the user may not be able to see the rest of the content.
        /// </summary>
        [Parameter]
        public int MaxItemCount { get; set; } = 100;

        /// <summary>
        /// Instructs the component to re-request data from its <see cref="ItemsProvider"/>.
        /// This is useful if external data may have changed. There is no need to call this
        /// when using <see cref="Items"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the completion of the operation.</returns>
        public async Task RefreshDataAsync()
        {
            // We don't auto-render after this operation because in the typical use case, the
            // host component calls this from one of its lifecycle methods, and will naturally
            // re-render afterwards anyway. It's not desirable to re-render twice.
            await RefreshDataCoreAsync(renderOnSuccess: false);
        }

        /// <inheritdoc />
        protected internal override void OnParametersSet()
        {
            if (ItemSize <= 0)
            {
                throw new InvalidOperationException(
                    $"{GetType()} requires a positive value for parameter '{nameof(ItemSize)}'.");
            }

            if (_itemSize <= 0)
            {
                _itemSize = ItemSize;
            }

            if (ItemsProvider != null)
            {
                if (Items != null)
                {
                    throw new InvalidOperationException(
                        $"{GetType()} can only accept one item source from its parameters. " +
                        $"Do not supply both '{nameof(Items)}' and '{nameof(ItemsProvider)}'.");
                }

                _itemsProvider = ItemsProvider;
            }
            else if (Items != null)
            {
                _itemsProvider = DefaultItemsProvider;

                // When we have a fixed set of in-memory data, it doesn't cost anything to
                // re-query it on each cycle, so do that. This means the developer can add/remove
                // items in the collection and see the UI update without having to call RefreshDataAsync.
                var refreshTask = RefreshDataCoreAsync(renderOnSuccess: false);

                // We know it's synchronous and has its own error handling
                Debug.Assert(refreshTask.IsCompleted && !refreshTask.IsFaulted);
            }
            else
            {
                throw new InvalidOperationException(
                    $"{GetType()} requires either the '{nameof(Items)}' or '{nameof(ItemsProvider)}' parameters to be specified " +
                    $"and non-null.");
            }

            _itemTemplate = ItemContent ?? ChildContent;
            _placeholder = Placeholder ?? DefaultPlaceholder;
            _emptyContent = EmptyContent;
        }

        protected internal override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                VirtualizeJs.InitializeAsync(this, _spacerBefore, _spacerAfter);
            }
            base.OnAfterRender(firstRender);
        }

        /// <inheritdoc />
        protected internal override void BuildRenderTree(IUIFrame builder, object key)
        {
            if (_refreshException != null)
            {
                var oldRefreshException = _refreshException;
                _refreshException = null;

                throw oldRefreshException;
            }

            _spacerBefore = builder.Element(SpacerElement, (ref UIElementAttribute attribute) =>
            {
                attribute.Set("style", GetSpacerStyle(_itemsBefore));
            }, sequenceNumber: Utility.Virtualize_SpacerElementBefore_SequenceNumber);

            var lastItemIndex = Math.Min(_itemsBefore + _visibleItemCapacity, _itemCount);
            var renderIndex = _itemsBefore;
            var placeholdersBeforeCount = Math.Min(_loadedItemsStartIndex, lastItemIndex);

            // Render placeholders before the loaded items.
            for (; renderIndex < placeholdersBeforeCount; renderIndex++)
            {
                // This is a rare case where it's valid for the sequence number to be programmatically incremented.
                // This is only true because we know for certain that no other content will be alongside it.
                builder.Content(_placeholder(new PlaceholderContext(renderIndex, _itemSize)), sequenceNumber: Utility.Virtualize_PlaceholderBefore_SequenceNumber);
            }

            _lastRenderedItemCount = 0;

            if (_loadedItems != null && !_loading && _itemCount == 0 && _emptyContent != null)
            {
                builder.Content(_emptyContent, sequenceNumber: Utility.Virtualize_EmptyContent_SequenceNumber);
            }
            else if (_loadedItems != null && _itemTemplate != null)
            {
                var itemsToShow = _loadedItems
                    .Skip(_itemsBefore - _loadedItemsStartIndex)
                    .Take(lastItemIndex - _loadedItemsStartIndex);

                // Render the loaded items.
                foreach (var item in itemsToShow)
                {
                    builder.Content(_itemTemplate(item), key: item, sequenceNumber: Utility.Virtualize_Item_SequenceNumber);
                    _lastRenderedItemCount++;
                }

                renderIndex += _lastRenderedItemCount;
            }

            _lastRenderedPlaceholderCount = Math.Max(0, lastItemIndex - _itemsBefore - _lastRenderedItemCount);

            // Render the placeholders after the loaded items.
            for (; renderIndex < lastItemIndex; renderIndex++)
            {
                builder.Content(_placeholder(new PlaceholderContext(renderIndex, _itemSize)), sequenceNumber: Utility.Virtualize_PlaceholderAfter_SequenceNumber);
            }

            var itemsAfter = Math.Max(0, _itemCount - _visibleItemCapacity - _itemsBefore);

            _spacerAfter = builder.Element(SpacerElement, (ref UIElementAttribute attribute) =>
            {
                attribute.Set("style", GetSpacerStyle(itemsAfter, _unusedItemCapacity));
            }, sequenceNumber: Utility.Virtualize_SpacerElementAfter_SequenceNumber);
        }

        private string GetSpacerStyle(int itemsInSpacer, int numItemsGapAbove)
            => numItemsGapAbove == 0 ?
             GetSpacerStyle(itemsInSpacer)
            : $"height: {(itemsInSpacer * _itemSize).ToString(CultureInfo.InvariantCulture)}px; flex-shrink: 0; transform: translateY({(numItemsGapAbove * _itemSize).ToString(CultureInfo.InvariantCulture)}px);";

        private string GetSpacerStyle(int itemsInSpacer)
            => $"height: {(itemsInSpacer * _itemSize).ToString(CultureInfo.InvariantCulture)}px; flex-shrink: 0;";

        void IVirtualizeJsCallbacks.OnBeforeSpacerVisible(float spacerSize, float spacerSeparation, float containerSize)
        {
            CalcualteItemDistribution(spacerSize, spacerSeparation, containerSize, out var itemsBefore, out var visibleItemCapacity, out var unusedItemCapacity);

            // Since we know the before spacer is now visible, we absolutely have to slide the window up
            // by at least one element. If we're not doing that, the previous item size info we had must
            // have been wrong, so just move along by one in that case to trigger an update and apply the
            // new size info.
            if (itemsBefore == _itemsBefore && itemsBefore > 0)
            {
                itemsBefore--;
            }

            UpdateItemDistribution(itemsBefore, visibleItemCapacity, unusedItemCapacity);
        }

        void IVirtualizeJsCallbacks.OnAfterSpacerVisible(float spacerSize, float spacerSeparation, float containerSize)
        {
            CalcualteItemDistribution(spacerSize, spacerSeparation, containerSize, out var itemsAfter, out var visibleItemCapacity, out var unusedItemCapacity);

            var itemsBefore = Math.Max(0, _itemCount - itemsAfter - visibleItemCapacity);

            // Since we know the after spacer is now visible, we absolutely have to slide the window down
            // by at least one element. If we're not doing that, the previous item size info we had must
            // have been wrong, so just move along by one in that case to trigger an update and apply the
            // new size info.
            if (itemsBefore == _itemsBefore && itemsBefore < _itemCount - visibleItemCapacity)
            {
                itemsBefore++;
            }

            UpdateItemDistribution(itemsBefore, visibleItemCapacity, unusedItemCapacity);
        }

        private void CalcualteItemDistribution(
            float spacerSize,
            float spacerSeparation,
            float containerSize,
            out int itemsInSpacer,
            out int visibleItemCapacity,
            out int unusedItemCapacity)
        {
            if (_lastRenderedItemCount > 0)
            {
                _itemSize = (spacerSeparation - (_lastRenderedPlaceholderCount * _itemSize)) / _lastRenderedItemCount;
            }

            if (_itemSize <= 0)
            {
                // At this point, something unusual has occurred, likely due to misuse of this component.
                // Reset the calculated item size to the user-provided item size.
                _itemSize = ItemSize;
            }

            // This AppContext data was added as a stopgap for .NET 8 and earlier, since it was added in a patch
            // where we couldn't add new public API. For backcompat we still support the AppContext setting, but
            // new applications should use the much more convenient MaxItemCount parameter.
            var maxItemCount = MaxItemCount;

            itemsInSpacer = Math.Max(0, (int)Math.Floor(spacerSize / _itemSize) - OverscanCount);
            visibleItemCapacity = (int)Math.Ceiling(containerSize / _itemSize) + 2 * OverscanCount;
            unusedItemCapacity = Math.Max(0, visibleItemCapacity - maxItemCount);
            visibleItemCapacity -= unusedItemCapacity;
        }

        private void UpdateItemDistribution(int itemsBefore, int visibleItemCapacity, int unusedItemCapacity)
        {
            // If the itemcount just changed to a lower number, and we're already scrolled past the end of the new
            // reduced set of items, clamp the scroll position to the new maximum
            if (itemsBefore + visibleItemCapacity > _itemCount)
            {
                itemsBefore = Math.Max(0, _itemCount - visibleItemCapacity);
            }

            // If anything about the offset changed, re-render
            if (itemsBefore != _itemsBefore || visibleItemCapacity != _visibleItemCapacity || unusedItemCapacity != _unusedItemCapacity)
            {
                _itemsBefore = itemsBefore;
                _visibleItemCapacity = visibleItemCapacity;
                _unusedItemCapacity = unusedItemCapacity;
                var refreshTask = RefreshDataCoreAsync(renderOnSuccess: true);

                if (!refreshTask.IsCompleted)
                {
                    StateHasChanged();
                }
            }
        }

        private async Task RefreshDataCoreAsync(bool renderOnSuccess)
        {
            _refreshCts?.Cancel();
            CancellationToken cancellationToken;

            if (_itemsProvider == DefaultItemsProvider)
            {
                // If we're using the DefaultItemsProvider (because the developer supplied a fixed
                // Items collection) we know it will complete synchronously, and there's no point
                // instantiating a new CancellationTokenSource
                _refreshCts = null;
                cancellationToken = CancellationToken.None;
            }
            else
            {
                _refreshCts = new CancellationTokenSource();
                cancellationToken = _refreshCts.Token;
                _loading = true;
            }

            var request = new ItemsProviderRequest(_itemsBefore, _visibleItemCapacity, cancellationToken);

            try
            {
                var result = await _itemsProvider(request);

                // Only apply result if the task was not canceled.
                if (!cancellationToken.IsCancellationRequested)
                {
                    _itemCount = result.TotalItemCount;
                    _loadedItems = result.Items;
                    _loadedItemsStartIndex = request.StartIndex;
                    _loading = false;

                    if (renderOnSuccess)
                    {
                        StateHasChanged();
                    }
                }
            }
            catch (Exception e)
            {
                if (e is OperationCanceledException oce && oce.CancellationToken.Equals(cancellationToken))
                {
                    // No-op; we canceled the operation, so it's fine to suppress this exception.
                }
                else
                {
                    // Cache this exception so the renderer can throw it.
                    _refreshException = e;

                    // Re-render the component to throw the exception.
                    StateHasChanged();
                }
            }
        }

        private Task<ItemsProviderResult<TItem>> DefaultItemsProvider(ItemsProviderRequest request)
        {
            return Task.FromResult(new ItemsProviderResult<TItem>(
                Items.Skip(request.StartIndex).Take(request.Count),
                Items.Count));
        }

        private RenderFragment DefaultPlaceholder(PlaceholderContext context) => (builder, key) =>
        {
            builder.Element("div", (ref UIElementAttribute attribute) =>
            {
                attribute.Set("style", $"height: {_itemSize.ToString(CultureInfo.InvariantCulture)}px; flex-shrink: 0;");
            }, sequenceNumber: Utility.Virtualize_DefaultPlaceholder_SequenceNumber);
        };

        public override void Dispose()
        {
            _refreshCts?.Cancel();
            base.Dispose();
        }
    }
}