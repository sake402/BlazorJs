// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using static H5.Core.dom;

namespace Microsoft.AspNetCore.Components.Web.Virtualization
{
    internal static partial class VirtualizeJs
    {
        //private readonly IVirtualizeJsCallbacks _owner;
        //public VirtualizeJsInterop(IVirtualizeJsCallbacks owner)
        //{
        //    _owner = owner;
        //}

        static HTMLElement FindClosestScrollContainer(HTMLElement element)
        {
            // If we recurse up as far as body or the document root, return null so that the
            // IntersectionObserver observes intersection with the top-level scroll viewport
            // instead of the with body/documentElement which can be arbitrarily tall.
            // See https://github.com/dotnet/aspnetcore/issues/37659 for more about what this fixes.
            if (element == null || element == document.body || element == document.documentElement)
            {
                return null;
            }

            var style = getComputedStyle(element);

            if (style.overflowY != "visible")
            {
                return element;
            }

            return FindClosestScrollContainer(element.parentElement);
        }

        public static void InitializeAsync(IVirtualizeJsCallbacks virtualize, HTMLElement spacerBefore, HTMLElement spacerAfter, int rootMargin = 50)
        {
            // Overflow anchoring can cause an ongoing scroll loop, because when we resize the spacers, the browser
            // would update the scroll position to compensate. Then the spacer would remain visible and we'd keep on
            // trying to resize it.
            var scrollContainer = FindClosestScrollContainer(spacerBefore);
            (scrollContainer ?? document.documentElement).style["overflowAnchor"] = "none";

            var rangeBetweenSpacers = document.createRange();

            if (isValidTableElement(spacerAfter.parentElement))
            {
                spacerBefore.style.display = "table-row";
                spacerAfter.style.display = "table-row";
            }

            var intersectionObserver = new IntersectionObserver(IntersectionCallback, new IntersectionObserverInit
            {
                root = scrollContainer,
                rootMargin = $"{rootMargin}px",
            });

            intersectionObserver.observe(spacerBefore);
            intersectionObserver.observe(spacerAfter);

            var mutationObserverBefore = CreateSpacerMutationObserver(spacerBefore);
            var mutationObserverAfter = CreateSpacerMutationObserver(spacerAfter);

            //          const {
            //              observersByDotNetObjectId, id
            //          } = getObserversMapEntry(dotNetHelper);
            //          observersByDotNetObjectId[id] = {
            //              intersectionObserver,
            //  mutationObserverBefore,
            //  mutationObserverAfter,
            //};
            MutationObserver CreateSpacerMutationObserver(HTMLElement spacer)
            {
                // Without the use of thresholds, IntersectionObserver only detects binary changes in visibility,
                // so if a spacer gets resized but remains visible, no additional callbacks will occur. By unobserving
                // and reobserving spacers when they get resized, the intersection callback will re-run if they remain visible.
                var observerOptions = new MutationObserverInit { attributes = true };
                var mutationObserver = new MutationObserver((mutations, observer) =>
                {
                    if (isValidTableElement(spacer.parentElement))
                    {
                        observer.disconnect();
                        spacer.style.display = "table-row";
                        observer.observe(spacer, observerOptions);
                    }

                    intersectionObserver.unobserve(spacer);
                    intersectionObserver.observe(spacer);
                });

                mutationObserver.observe(spacer, observerOptions);

                return mutationObserver;
            }

            void IntersectionCallback(IntersectionObserverEntry[] entries, IntersectionObserver observer)
            {
                entries.ForEach((entry) =>
                {
                    if (!entry.isIntersecting)
                    {
                        return;
                    }

                    // To compute the ItemSize, work out the separation between the two spacers. We can't just measure an individual element
                    // because each conceptual item could be made from multiple elements. Using getBoundingClientRect allows for the size to be
                    // a fractional value. It's important not to add or subtract any such fractional values (e.g., to subtract the 'top' of
                    // one item from the 'bottom' of another to get the distance between them) because floating point errors would cause
                    // scrolling glitches.
                    rangeBetweenSpacers.setStartAfter(spacerBefore);
                    rangeBetweenSpacers.setEndBefore(spacerAfter);
                    var spacerSeparation = rangeBetweenSpacers.getBoundingClientRect().As<ClientRect>().height;
                    var containerSize = entry.rootBounds.As<ClientRect>()?.height;

                    if (entry.target == spacerBefore)
                    {
                        virtualize.OnBeforeSpacerVisible((float)(entry.intersectionRect.As<ClientRect>().top - entry.boundingClientRect.As<ClientRect>().top), (float)spacerSeparation, (float)containerSize);
                        //dotNetHelper.invokeMethodAsync('OnSpacerBeforeVisible', entry.intersectionRect.top - entry.boundingClientRect.top, spacerSeparation, containerSize);
                    }
                    else if (entry.target == spacerAfter && spacerAfter.offsetHeight > 0)
                    {
                        // When we first start up, both the "before" and "after" spacers will be visible, but it's only relevant to raise a
                        // single event to load the initial data. To avoid raising two events, skip the one for the "after" spacer if we know
                        // it's meaningless to talk about any overlap into it.
                       virtualize.OnAfterSpacerVisible((float)(entry.boundingClientRect.As<ClientRect>().bottom - entry.intersectionRect.As<ClientRect>().bottom), (float)spacerSeparation, (float)containerSize);
                        //dotNetHelper.invokeMethodAsync('OnSpacerAfterVisible', entry.boundingClientRect.bottom - entry.intersectionRect.bottom, spacerSeparation, containerSize);
                    }
                });
            }

            bool isValidTableElement(HTMLElement element)
            {
                if (element == null)
                {
                    return false;
                }

                return ((H5.Script.InstanceOf(element, typeof(HTMLTableElement)) && element.style.display == "") || element.style.display == "table")
                        ||
                       ((H5.Script.InstanceOf(element, typeof(HTMLTableSectionElement)) && element.style.display == "") || element.style.display == "table-row-group");
            }
        }

        //public async Task InitializeAsync(HTMLElement spacerBefore, HTMLElement spacerAfter)
        //{
        //    Init(spacerBefore, spacerAfter);
        //    //_selfReference = DotNetObjectReference.Create(this);
        //    //await _jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.init", _selfReference, spacerBefore, spacerAfter);
        //}

        ////[JSInvokable]
        //public void OnSpacerBeforeVisible(float spacerSize, float spacerSeparation, float containerSize)
        //{
        //    _owner.OnBeforeSpacerVisible(spacerSize, spacerSeparation, containerSize);
        //}

        ////[JSInvokable]
        //public void OnSpacerAfterVisible(float spacerSize, float spacerSeparation, float containerSize)
        //{
        //    _owner.OnAfterSpacerVisible(spacerSize, spacerSeparation, containerSize);
        //}
    }
}