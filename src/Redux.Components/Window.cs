using Redux.Threading;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Veldrid;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;

namespace Redux.Components
{
    public class Window : AutoRenderable
    {
        public Window()
        {
            //ReduxThread.Current.Invoke(RenderLoop);
            
            RenderLoop();
        }
       

        private WindowCreateInfo CreateInfo() 
        {
            return new WindowCreateInfo()
            {
                X = 100,
                Y = 100,
                WindowWidth = 960,
                WindowHeight = 540,
                WindowTitle = "Veldrid Tutorial"
            };
        }


        private void RenderLoop()
        {
            var windowCI = CreateInfo();
            
            Sdl2Window window = VeldridStartup.CreateWindow(ref windowCI);

            GraphicsDeviceOptions options = new GraphicsDeviceOptions
            {
                PreferStandardClipSpaceYDirection = true,
                PreferDepthRangeZeroToOne = true
            };

            while (window.Exists)
            {
                window.PumpEvents();
                if (window.Exists)
                {
                    new Square().Render(new Platform.RenderContext(null, window, options));
                }
            }
        }
    }
}
