using System.Diagnostics;
using OpenGLRayMarching.Graphics.OpenGLBindings;
using OpenGLRayMarching.Graphics.OpenGLBindings.Shaders;
using OpenGLRayMarching.Graphics.Shaders;
using OpenGLRayMarching.Graphics.Static;
using OpenGLRayMarching.Utils;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using DebugSeverity = OpenTK.Graphics.OpenGL4.DebugSeverity;

namespace OpenGLRayMarching.Graphics;

public class Window : GameWindow
{

    private const string BASE_TITLE = "Raymarching";
    private Shader basicShader;
    public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
    {
        
    }

    protected override void OnLoad()
    {
        GLSystem.INIT_SYSTEM();
        GLCustomActions.AtKHRDebug += (source, type, arg3, arg4) =>
        {
            if (arg3 != DebugSeverity.DebugSeverityHigh)
            {
                throw new Exception($"Error at: {source}\nType: {type}\nSeverity: {arg3}\nMessage: {arg4}");
            }
            
            Debug.WriteLine($"Error at: {source}\nType: {type}\nSeverity: {arg3}\nMessage: {arg4}");
            
        };
        
        GL.ClearColor(0,1,0,1);
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

        string FPS = (1 / args.Time).ToString("F");
        //Console.WriteLine($"Rendering: {args.Time} - {FPS}");
        Title = $"{BASE_TITLE} - {FPS}";
        
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