﻿using static H5.Core.dom;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorJs.Core
{
    internal partial class BrowserNativeRenderer : IRenderer
    {
        //class RegistryEntry
        //{
        //    public Node.Interface element;
        //    public int id;
        //}

        UIFrame rootFragment;
        object registries = new object();

        internal BrowserNativeRenderer(IServiceProvider services)
        {
            Services = services;
            rootFragment = new UIFrame(this);
            rootFragment.Elements = new[] { document.body };
        }

        public IServiceProvider Services { get; }

        public void Add(RenderFragment fragment)
        {
            fragment(rootFragment);
        }

        public void Add<T>(Action<T> attributeBuilder = null) where T : IComponent
        {
            rootFragment.Component<T>(attributeBuilder, sequenceNumber: int.MaxValue);
        }

        //RegistryEntry GetRegistry(int id, object key = null)
        //{
        //    if (id == 0)
        //        return new RegistryEntry { id = 0, element = document.body };
        //    return (RegistryEntry)registries[id.ToString()];
        //}

        //void AddRegistry(int id, RegistryEntry entry)
        //{
        //    registries[id.ToString()] = entry;
        //}

        static int GetUID(IUIContent content)
        {
            if (content == null)
                return 0;
            if (content.State.Key == null)
            {
                return content.State.Id;
            }
            return content.State.Id + 86438565 * content.State.Key.GetHashCode();
        }

        //Node Text(string txt, int id)
        //{
        //    var e = document.createTextNode(txt);
        //    return e;
        //}

        //HTMLElement Element(string tag, int id)
        //{
        //    var e = document.createElement(tag);
        //    return e;
        //}

        //ShadowRoot Component(string tag, int id, int parentId)
        //{
        //    //if (!definedComponents.includes(tag))
        //    //{
        //    //customElements.define(tag, Component, { extends: "div" });
        //    //}
        //    var parent = GetRegistry(parentId);
        //    ShadowRoot shadow;
        //    if (parent.element is ShadowRoot eshadow)
        //    {
        //        eshadow.
        //    }
        //    else
        //    {
        //        var shadow = ((HTMLElement)parent.element).attachShadow(new ShadowRootInit { mode = Literals.Options.mode.open });
        //    }
        //    //var e = document.createElement(tag);
        //    AddRegistry(id, new RegistryEntry { id = id, element = shadow });
        //    return shadow;
        //    //return e;
        //}

        //HTMLElement Region(int id)
        //{
        //    var e = document.createElement("region");
        //    AddRegistry(id, new RegistryEntry { id = id, element = e });
        //    return e;
        //}

        //void Update(IUIContent frame, string txt)
        //{
        //    //var registry = GetRegistry(id);
        //    //if (registry.element is HTMLElement element)
        //    //{
        //    frame.State.Element.textContent = txt;
        //    //}
        //}

        Node.Interface GetParentElement(IUIContent element)
        {
            var parentElement = element.State.ParentFrame;
            while (parentElement.State.Elements == null)
            {
                parentElement = parentElement.State.ParentFrame;
                if (parentElement == null)
                {
                    return rootFragment.Elements[0];
                }
            }
            //while (!(parentElement is UIElement el))
            //{
            //    parentElement = parentElement.State.ParentFrame;
            //    if (parentElement == null)
            //    {
            //        return rootFragment.Element;
            //    }
            //}
            return parentElement.State.Elements[0];
        }

        Node.Interface GetFirstElementAfter(IUIContent element)
        {
            var after = element.GetAfter();
            while (after != null)
            {
                if (after.State.Elements != null)
                {
                    return after.State.Elements[0];
                }
                if (after is UIFrame frame && frame.Children != null)
                {
                    foreach (var c in frame.Children)
                    {
                        var first = GetFirstElementAfter(c);
                        if (first != null)
                            return first;
                    }
                }
                if (after is ComponentBase component && component.State.Children != null)
                {
                    foreach (var c in component.State.Children)
                    {
                        var first = GetFirstElementAfter(c);
                        if (first != null)
                            return first;
                    }
                }
                after = after.GetAfter();
            }
            return null;
        }

        void Insert(IUIContent frame, IUIContent parent, IUIContent before)
        {
            var useElement = parent.State.Elements?[0];
            var reference = before?.State.Elements?.Length > 0 ? before?.State.Elements[0] : null;
            //A component / region doesnt have an HTMLElement in the dom
            //We need to find the parent HTML element and use that
            if (parent.State.Elements == null)// is ComponentBase component || parent is UIFrame regionFrame) //a component or a region
            {
                useElement = GetParentElement(parent);
                //If we are tring to insert as the last element into this compoonent
                //change the reference to the first element that is after the component
                if (reference == null)
                {
                    reference = GetFirstElementAfter(parent);
                }
            }
            if (reference != null)
            {
                frame.State.Elements.ForEach(el =>
                {
                    useElement.insertBefore(el, (Node)reference);
                });
            }
            else
            {
                frame.State.Elements.ForEach(el =>
                {
                    useElement.appendChild(el);
                });
            }
        }


        //void Remove(IUIContent frame)
        //{
        //    frame.State.ParentFrame.State.Element.removeChild(frame.State.Element);
        //}

        public void CreateElement(UIElement element)
        {
            var insertBefore = element.GetAfter();
            var melement = document.createElement(element.Tag);
            element.Elements = new[] { melement };
            Insert(element, element.State.ParentFrame, insertBefore);
        }

        public void CreateRegion(UIFrame frame)
        {
            //var insertBefore = frame.GetAfter();
            //Insert(null, frame.State.ParentFrame, insertBefore);
        }
        public void RemoveRegion(UIFrame frame)
        {
        }

        public void CreateComponent(IComponent component)
        {
            //var insertBefore = component.GetAfter();
            //Insert(null, component.State.ParentFrame, insertBefore);
        }

        public void RemoveComponent(IComponent component)
        {
        }

        public void CreateText(UIText text)
        {
            var insertBefore = text.GetAfter();
            var element = document.createTextNode(text.Text?.ToString());
            text.Elements = new[] { element };
            Insert(text, text.State.ParentFrame, insertBefore);
        }

        public void UpdateText(UIText text)
        {
            text.State.Elements[0].textContent = text.Text?.ToString();
        }

        public void RemoveElement(UIElement element)
        {
            var parent = GetParentElement(element);
            parent.removeChild(element.State.Elements[0]);
        }

        public void RemoveText(UIText text)
        {
            var parent = GetParentElement(text);
            parent.removeChild(text.State.Elements[0]);
        }

        public void SetElementAttribute(UIElement element, string key, object value)
        {
            if (key.StartsWith("@on") && value is IEventCallback evc)
            {
                var eventName = key.Substring(3).Split(':')[0];
                var existingEvent = element.State.Elements[0]["__" + eventName + "__"];
                element.State.Elements[0].removeEventListener(eventName, (EventListener)existingEvent);
                EventListener evl = (ev) =>
                {
                    evc.InvokeAsync(ev).ContinueWith(t =>
                    {
                        if (t.Exception != null)
                        {
                            System.Console.WriteLine(t.Exception);
                        }
                    }).FireAndForget();
                    if (evc.Flags.HasFlag(EventCallbackFlags.StopPropagation))
                        ev.stopPropagation();
                    if (evc.Flags.HasFlag(EventCallbackFlags.PreventDefault))
                        ev.preventDefault();
                };
                element.State.Elements[0].addEventListener(eventName, evl);
                element.State.Elements[0]["__" + eventName + "__"] = evl;
            }
            else
            {
                bool isInput = H5.Script.InstanceOf(element.Elements[0], typeof(HTMLInputElement));
                if (isInput && key == "value")
                {
                    ((HTMLInputElement)element.Elements[0]).value = value?.ToString();
                }
                else if (isInput && key == "readonly")
                {
                    ((HTMLInputElement)element.Elements[0]).readOnly = value.As<bool>();
                }
                else if (value is null)
                {
                    if (element.State.Elements[0] is HTMLElement melement)
                    {
                        if (melement.attributes.getNamedItem(key) != null)
                            melement.attributes.removeNamedItem(key);
                    }
                }
                else
                {
                    var atr = document.createAttribute(key);
                    atr.value = value.ToString();
                    if (element.State.Elements[0] is HTMLElement melement)
                    {
                        melement.attributes.setNamedItem(atr);
                    }
                }
            }
        }

        public void CreateMarkup(UIMarkup markup)
        {
            var insertBefore = markup.GetAfter();
            var template = (HTMLTemplateElement)document.createElement("template");
            template.innerHTML = markup.Markup;
            markup.Elements = template.content.childNodes.As<Node.Interface[]>();
            Insert(markup, markup.State.ParentFrame, insertBefore);
        }

        public void UpdateMarkup(UIMarkup markup)
        {
            RemoveMarkup(markup);
            CreateMarkup(markup);
        }

        public void RemoveMarkup(UIMarkup markup)
        {
            var parent = GetParentElement(markup);
            markup.State.Elements.ForEach(el =>
            {
                parent.removeChild(el);
            });
        }

        public void Flush()
        {
        }
    }
}
