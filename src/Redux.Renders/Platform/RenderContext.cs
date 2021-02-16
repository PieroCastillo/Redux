using Redux.Renders.Platform;
using Redux.Textures;
using System;
using System.Collections.Generic;
using System.Text;
using Veldrid;
using Veldrid.Sdl2;

namespace Redux.Platform
{
    public class RenderContext
    {
        public RenderContext(IRenderContextImpl renderContextImpl, Sdl2Window window, GraphicsDeviceOptions options)
        {
            Impl = renderContextImpl;
            Window = window;
            GraphicsDeviceOptions = options;
        }

        private IRenderContextImpl Impl;

        public Sdl2Window Window { get; }
        public GraphicsDeviceOptions GraphicsDeviceOptions { get; } 


        public void DrawEsphere(HitBox bounds, double radius, ITexture brush) 
        {

        }

        public void DrawCube(HitBox bounds, double width, double height, double large, ITexture texture)
        {

        }
    }
}
