using System;
using OpenGLRayMarching.Graphics;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace OpenGLRayMarching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NativeWindowSettings windowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(1280, 720),
                Title = "Raymarching",
                Flags = ContextFlags.Default
            };
            
            using (Window window = new Window(GameWindowSettings.Default, windowSettings)) window.Run();
        }
    }
}