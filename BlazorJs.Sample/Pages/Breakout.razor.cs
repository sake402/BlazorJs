using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static H5.Core.dom;

namespace BlazorJs.Sample.Pages
{
    public partial class Breakout : ComponentBase
    {
        HTMLElement world;
        CanvasRenderingContext2D context;

        bool disposed;
        int x, y;
        void Render(double time)
        {
            context.beginPath();
            context.clearRect(x - 1, y - 1, 10, 10);
            context.rect(x, x, 10, 10);
            context.fillStyle = "red";
            context.fill();
            context.closePath();
            x++;
            y++;
            if (!disposed)
            {
                window.requestAnimationFrame(Render);
            }
        }
        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                window.requestAnimationFrame(Render);
                context = ((HTMLCanvasElement)world).getContext("2d").As<CanvasRenderingContext2D>();
            }
            return base.OnAfterRenderAsync(firstRender);
        }

        public override void Dispose()
        {
            disposed = true;
            base.Dispose();
        }
    }
}
