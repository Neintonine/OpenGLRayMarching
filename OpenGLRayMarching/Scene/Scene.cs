﻿using System.Diagnostics;
using OpenGLRayMarching.Graphics.Shaders;
using OpenGLRayMarching.Graphics.Static;
using OpenGLRayMarching.Scene.RaymarchingObjects;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OpenGLRayMarching.Scene;

public class Scene
{
    public const float MOVE_SPEED = 1f;
    public const float ROTATE_SPEED = 10f;
    
    public Camera Camera = new Camera();
    public List<RaymarchObject> Objects;

    public void Init()
    {
        
    }

    public void Update(float deltatime, KeyboardState keyboardState)
    {
        float movex = (keyboardState[Keys.Left] ? 1 : 0) + (keyboardState[Keys.Right] ? -1 : 0);
        float movey = (keyboardState[Keys.Down] ? -1 : 0) + (keyboardState[Keys.Up] ? 1 : 0);
        float rotatex = (keyboardState[Keys.A] ? 1 : 0) + (keyboardState[Keys.D] ? -1 : 0);
        float rotatey = (keyboardState[Keys.S] ? -1 : 0) + (keyboardState[Keys.W] ? 1 : 0);
        
        Vector3 addedMovement = new Vector3(MOVE_SPEED * movex, 0, MOVE_SPEED * movey) * deltatime;
        Vector3 addedRotation = new Vector3(ROTATE_SPEED * rotatey, ROTATE_SPEED * rotatex, 0) * deltatime;
        Camera.SetRotation(Camera.EulerRotation + addedRotation);
        Camera.SetPosition(Camera.Position + addedMovement);
        Console.WriteLine($"{Camera.Position} - {Camera.EulerRotation}");
    }
}