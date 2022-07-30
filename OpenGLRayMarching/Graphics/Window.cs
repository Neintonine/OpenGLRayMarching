using System.Drawing;
using OpenGLRayMarching.Graphics.OpenGLBindings;
using OpenGLRayMarching.Graphics.OpenGLBindings.Shaders;
using OpenGLRayMarching.Graphics.Shaders;
using OpenGLRayMarching.Graphics.Static;
using OpenGLRayMarching.Utils;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace OpenGLRayMarching.Graphics;

public class Window : GameWindow
{

    private Shader basicShader;
    public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
    {
        
    }

    protected override void OnLoad()
    {
        GLSystem.INIT_SYSTEM();
        
        GL.ClearColor(0,0,0,1);
        basicShader = new Shader(AssemblyUtility.ReadAssemblyFile("OpenGLRayMarching.Graphics.Shaders.basic.vert"), AssemblyUtility.ReadAssemblyFile("OpenGLRayMarching.Graphics.Shaders.basic.frag"));
        
        base.OnLoad();
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);
        
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);
        
        basicShader.Activate();
        Plate.Object.Activate();
        GenericShader.DrawObject(Plate.Object);
        
        Context.SwapBuffers();
        base.OnRenderFrame(args);
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);
        GL.Viewport(0,0, Size.X, Size.Y);
    }
}