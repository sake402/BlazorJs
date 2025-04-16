using H5;
using H5.Core;
using System;
using static H5.Core.dom;
using static H5.Core.es5;
using System.Threading.Tasks;
using System.Linq;
using BlazorJs.Core;
using BlazorJs.Sample.Layout;
using BlazorJs.Core.Components.LiteRouting;

namespace BlazorJs.Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GeneratedStartup.Run();
            BrowserApplicationBuilder.Create<Routes>((app) =>
            {
            }, router =>
            {
                //router.DefaultLayout = typeof(MainLayout);
            });
        }
    }
}
