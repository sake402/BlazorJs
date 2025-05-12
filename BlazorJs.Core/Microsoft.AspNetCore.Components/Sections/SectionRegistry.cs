using System;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Components.Sections
{
    internal sealed class SectionRegistry
    {
        private readonly Dictionary<object, SectionOutlet> _subscribersByIdentifier = new Dictionary<object, SectionOutlet>();
        private readonly Dictionary<object, List<SectionContent>> _providersByIdentifier = new Dictionary<object, List<SectionContent>>();

        public void AddProvider(object identifier, SectionContent provider, bool isDefaultProvider)
        {
            if (!_providersByIdentifier.TryGetValue(identifier, out var providers))
            {
                providers = new List<SectionContent>();
                _providersByIdentifier.Add(identifier, providers);
            }

            if (isDefaultProvider)
            {
                providers.Insert(0, provider);
            }
            else
            {
                providers.Add(provider);
            }
        }

        public void RemoveProvider(object identifier, SectionContent provider)
        {
            if (!_providersByIdentifier.TryGetValue(identifier, out var providers))
            {
                throw new InvalidOperationException($"There are no content providers with the given section ID '{identifier}'.");
            }

            var index = providers.LastIndexOf(provider);

            if (index < 0)
            {
                throw new InvalidOperationException($"The provider was not found in the providers list of the given section ID '{identifier}'.");
            }

            providers.RemoveAt(index);

            if (index == providers.Count)
            {
                // We just removed the most recently added provider, meaning we need to change
                // the current content to that of second most recently added provider.
                var contentProvider = GetCurrentProviderContentOrDefault(providers);
                NotifyContentChangedForSubscriber(identifier, contentProvider);
            }
        }

        public void Subscribe(object identifier, SectionOutlet subscriber)
        {
            if (_subscribersByIdentifier.ContainsKey(identifier))
            {
                throw new InvalidOperationException($"There is already a subscriber to the content with the given section ID '{identifier}'.");
            }

            // Notify the new subscriber with any existing content.
            var provider = GetCurrentProviderContentOrDefault(identifier);
            subscriber.ContentUpdated(provider);

            _subscribersByIdentifier.Add(identifier, subscriber);
        }

        public void Unsubscribe(object identifier)
        {
            if (!_subscribersByIdentifier.Remove(identifier))
            {
                throw new InvalidOperationException($"The subscriber with the given section ID '{identifier}' is already unsubscribed.");
            }
        }

        public void NotifyContentProviderChanged(object identifier, SectionContent provider)
        {
            if (!_providersByIdentifier.TryGetValue(identifier, out var providers))
            {
                throw new InvalidOperationException($"There are no content providers with the given section ID '{identifier}'.");
            }

            // We only notify content changed for subscribers when the content of the
            // most recently added provider changes.
            if (providers.Count != 0 && providers[providers.Count - 1] == provider)
            {
                NotifyContentChangedForSubscriber(identifier, provider);
            }
        }

        private static SectionContent GetCurrentProviderContentOrDefault(List<SectionContent> providers)
            => providers.Count != 0
                ? providers[providers.Count - 1]
                : null;

        private SectionContent GetCurrentProviderContentOrDefault(object identifier)
            => _providersByIdentifier.TryGetValue(identifier, out var existingList)
                ? GetCurrentProviderContentOrDefault(existingList)
                : null;

        private void NotifyContentChangedForSubscriber(object identifier, SectionContent provider)
        {
            if (_subscribersByIdentifier.TryGetValue(identifier, out var subscriber))
            {
                subscriber.ContentUpdated(provider);
            }
        }
    }
}