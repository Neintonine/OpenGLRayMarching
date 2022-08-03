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
    private Shader _raymarching;
    private Scene.Scene _scene;

    public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
    {
        _scene = new Scene.Scene();
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
        
        Console.WriteLine($"GLSL max uniform locations: {GL.GetInteger(GetPName.MaxSubroutineUniformLocations)}");
        
        GL.ClearColor(0.2f,0.3f,0.2f,1);
        _raymarching = new RaymarchingShader();
        
        _scene.Init();
        
        base.OnLoad();
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        _scene.Update((float)args.Time, KeyboardState, MouseState);
        base.OnUpdateFrame(args);
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);

        string FPS = (1 / args.Time).ToString("F");
        string frameTime = (args.Time * 1000).ToString("F2");
        //Console.WriteLine($"Rendering: {args.Time} - {FPS}");
        Title = $"{BASE_TITLE} - {FPS} FPS - {frameTime}ms";
        
        _raymarching.Render(_scene);
        
        Context.SwapBuffers();
        base.OnRenderFrame(args);
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);
        GL.Viewport(0,0, Size.X, Size.Y);
        _scene.Camera.AspectRatio = Size.X / (float)Size.Y;
    }
}