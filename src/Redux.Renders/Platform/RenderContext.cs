using Redux.Renders.Platform;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redux.Platform
{
    public class RenderContext
    {
        public RenderContext(IRenderContextImpl renderContextImpl)
        {
            Impl = renderContextImpl;
        }

        private IRenderContextImpl Impl;

        public void DrawCircle() 
        {

        }

        public void DrawCube()
        {

        }
    }
}
