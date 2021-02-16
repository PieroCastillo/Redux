using Redux.Platform;
using Redux.Textures;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Veldrid;
using Veldrid.SPIRV;
using Veldrid.StartupUtilities;

namespace Redux.Components
{
    public class Square : Component, IDisposable
    {
        private static GraphicsDevice _graphicsDevice;
        private static CommandList _commandList;
        private static DeviceBuffer _vertexBuffer;
        private static DeviceBuffer _indexBuffer;
        private static Shader[] _shaders;
        private static Pipeline _pipeline;

        private const string VertexCode = @"
#version 450

layout(location = 0) in vec2 Position;
layout(location = 1) in vec4 Color;

layout(location = 0) out vec4 fsin_Color;

void main()
{
    gl_Position = vec4(Position, 0, 1);
    fsin_Color = Color;
}";

        private const string FragmentCode = @"
#version 450

layout(location = 0) in vec4 fsin_Color;
layout(location = 0) out vec4 fsout_Color;

void main()
{
    fsout_Color = fsin_Color;
}";

        public override void Render(RenderContext context)
        {
            base.Render(context);

            context.DrawCube(new HitBox(new Size(200), new Point(0, 0, 0)), 200, 200, 200, new SolidColorTexture(new Color(255, 255, 255, 255)));

            var window = context.Window;
            var options = context.GraphicsDeviceOptions;

            _graphicsDevice = VeldridStartup.CreateGraphicsDevice(window,options);

            CreateResources();
            Draw();
            dispose = DisposeResources;

            void Draw()
            {
                // Begin() must be called before commands can be issued.
                _commandList.Begin();

                // We want to render directly to the output window.
                _commandList.SetFramebuffer(_graphicsDevice.SwapchainFramebuffer);
                _commandList.ClearColorTarget(0, RgbaFloat.Black);

                // Set all relevant state to draw our quad.
                _commandList.SetVertexBuffer(0, _vertexBuffer);
                _commandList.SetIndexBuffer(_indexBuffer, IndexFormat.UInt16);
                _commandList.SetPipeline(_pipeline);
                // Issue a Draw command for a single instance with 4 indices.
                _commandList.DrawIndexed(
                    indexCount: 4,
                    instanceCount: 1,
                    indexStart: 0,
                    vertexOffset: 0,
                    instanceStart: 0);

                // End() must be called before commands can be submitted for execution.
                _commandList.End();
                _graphicsDevice.SubmitCommands(_commandList);

                // Once commands have been submitted, the rendered image can be presented to the application window.
                _graphicsDevice.SwapBuffers();
            }

            void CreateResources()
            {
                ResourceFactory factory = _graphicsDevice.ResourceFactory;

                VertexPositionColor[] quadVertices =
                {
                    new VertexPositionColor(new Vector2(-0.75f, 0.75f), RgbaFloat.Red),
                    new VertexPositionColor(new Vector2(0.75f, 0.75f), RgbaFloat.Green),
                    new VertexPositionColor(new Vector2(-0.75f, -0.75f), RgbaFloat.Blue),
                    new VertexPositionColor(new Vector2(0.75f, -0.75f), RgbaFloat.Yellow)
                };

                ushort[] quadIndices = { 0, 1, 2, 3 };

                _vertexBuffer = factory.CreateBuffer(new BufferDescription(4 * VertexPositionColor.SizeInBytes, BufferUsage.VertexBuffer));
                _indexBuffer = factory.CreateBuffer(new BufferDescription(4 * sizeof(ushort), BufferUsage.IndexBuffer));

                _graphicsDevice.UpdateBuffer(_vertexBuffer, 0, quadVertices);
                _graphicsDevice.UpdateBuffer(_indexBuffer, 0, quadIndices);

                VertexLayoutDescription vertexLayout = new VertexLayoutDescription(
                    new VertexElementDescription("Position", VertexElementSemantic.TextureCoordinate, VertexElementFormat.Float2),
                    new VertexElementDescription("Color", VertexElementSemantic.TextureCoordinate, VertexElementFormat.Float4));

                ShaderDescription vertexShaderDesc = new ShaderDescription(
                    ShaderStages.Vertex,
                    Encoding.UTF8.GetBytes(VertexCode),
                    "main");
                ShaderDescription fragmentShaderDesc = new ShaderDescription(
                    ShaderStages.Fragment,
                    Encoding.UTF8.GetBytes(FragmentCode),
                    "main");

                _shaders = factory.CreateFromSpirv(vertexShaderDesc, fragmentShaderDesc);

                GraphicsPipelineDescription pipelineDescription = new GraphicsPipelineDescription();
                pipelineDescription.BlendState = BlendStateDescription.SingleOverrideBlend;

                pipelineDescription.DepthStencilState = new DepthStencilStateDescription(
                    depthTestEnabled: true,
                    depthWriteEnabled: true,
                    comparisonKind: ComparisonKind.LessEqual);

                pipelineDescription.RasterizerState = new RasterizerStateDescription(
                    cullMode: FaceCullMode.Back,
                    fillMode: PolygonFillMode.Solid,
                    frontFace: FrontFace.Clockwise,
                    depthClipEnabled: true,
                    scissorTestEnabled: false);

                pipelineDescription.PrimitiveTopology = PrimitiveTopology.TriangleStrip;
                pipelineDescription.ResourceLayouts = System.Array.Empty<ResourceLayout>();

                pipelineDescription.ShaderSet = new ShaderSetDescription(
                    vertexLayouts: new VertexLayoutDescription[] { vertexLayout },
                    shaders: _shaders);

                pipelineDescription.Outputs = _graphicsDevice.SwapchainFramebuffer.OutputDescription;
                _pipeline = factory.CreateGraphicsPipeline(pipelineDescription);

                _commandList = factory.CreateCommandList();
            }

            void DisposeResources()
            {
                _pipeline.Dispose();
                foreach (Shader shader in _shaders)
                {
                    shader.Dispose();
                }
                _commandList.Dispose();
                _vertexBuffer.Dispose();
                _indexBuffer.Dispose();
                _graphicsDevice.Dispose();
            }
        }

        private Action dispose;

        public void Dispose()
        {
            if(dispose is not null)
            {
                dispose.Invoke();
            }
        }

        struct VertexPositionColor
        {
            public Vector2 Position; // This is the position, in normalized device coordinates.
            public RgbaFloat Color; // This is the color of the vertex.
            public VertexPositionColor(Vector2 position, RgbaFloat color)
            {
                Position = position;
                Color = color;
            }
            public const uint SizeInBytes = 24;
        }
        
    }
}
