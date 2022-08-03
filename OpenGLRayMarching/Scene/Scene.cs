using System.Diagnostics;
using OpenGLRayMarching.Graphics;
using OpenGLRayMarching.Graphics.Shaders;
using OpenGLRayMarching.Graphics.Static;
using OpenGLRayMarching.Scene.RaymarchingObjects;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using SkiaSharp;

namespace OpenGLRayMarching.Scene;

public class Scene
{
    public const float MOVE_SPEED = 1f;
    public const float ROTATE_SPEED = 360f;
    
    public Camera Camera = new Camera();
    public List<RaymarchObject> Objects;
    public Texture EnviromentTexture;

    public void Init()
    {
        SKBitmap image = SKBitmap.Decode(File.OpenRead(Path.Combine("_Resources", "spruit_sunrise_4k.png")));
        //SKBitmap image = SKBitmap.FromImage(SKImage.FromEncodedData(File.OpenRead(Path.Combine("_Resources", "spruit_sunrise_4k.png"))));
        
        EnviromentTexture = new Texture(image);
    }

    public void Update(float deltatime, KeyboardState keyboardState, MouseState mouseState)
    {
        float movex = (keyboardState[Keys.Left] ? 1 : 0) + (keyboardState[Keys.Right] ? -1 : 0);
        float movey = (keyboardState[Keys.Down] ? -1 : 0) + (keyboardState[Keys.Up] ? 1 : 0);
        Vector2 delta = mouseState.Delta;
        
        Vector3 addedMovement = new Vector3(MOVE_SPEED * movex, 0, MOVE_SPEED * movey) * deltatime;
        Vector3 addedRotation = new Vector3(ROTATE_SPEED * delta.Y, ROTATE_SPEED * -delta.X, 0) * deltatime;
        Camera.SetRotation(Camera.EulerRotation + addedRotation);
        Camera.SetPosition(Camera.Position + addedMovement);
        //Console.WriteLine($"{Camera.Position} - {Camera.EulerRotation}");
    }
}