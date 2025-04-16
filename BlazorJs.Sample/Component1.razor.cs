using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorJs.Core;
using System.Net.Http.Json;
using System.Text.Json;
using static H5.Core.dom;
using Microsoft.AspNetCore.Components;

namespace BlazorJs.Sample
{
    public partial class Component1 : ComponentBase
    {
        HTMLElement input;
        int field1; 
        int field2;
        RenderFragment view;
        [Inject] public HttpClient Http { get; set; }
        public string Property1 { get; set; }
        void Clicked()
        {
            field1++;
        }

        MarkupString html;
        BlazorWasmAppDescriptor descriptor;
        public class BlazorWasmAppFile
        {
            public string Path { get; set; }
            public string Hash { get; set; }
            public long Size { get; set; }
            public DateTime DateModified { get; set; }
            public override string ToString()
            {
                return Path;
            }
            public override int GetHashCode()
            {
                return Path.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                if (obj is BlazorWasmAppFile f)
                {
                    return f.Path == Path;
                }
                return base.Equals(obj);
            }
        }
        public partial class BlazorWasmAppDescriptor
        {
            //public DateTime BuildTime { get; set; }
            public string Version { get; set; }
            public long Size { get; set; }
            public IEnumerable<BlazorWasmAppFile> Files { get; set; }
        }
        protected override async Task OnInitializedAsync()
        {
            descriptor = await Http.GetFromJsonAsync<BlazorWasmAppDescriptor>("https://sake.org.ng/wasm.app.json");
            html = await Http.GetStringAsync("https://google.com");
            await base.OnInitializedAsync();
        }
    }
}
