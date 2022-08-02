using System.Numerics;
using OpenGLRayMarching.Utils;
using OpenTK.Mathematics;
using Quaternion = OpenTK.Mathematics.Quaternion;
using Vector3 = OpenTK.Mathematics.Vector3;

namespace OpenGLRayMarching.Scene;

public class Camera
{
    private static float _aspectRatio;

    public Vector3 Position
    {
        get => _position;
        set
        {
            SetPosition(value);
        }
    }
    
    public Quaternion Rotation
    {
        get => _rotation;
        set
        {
            SetRotation(value);
        }
    }
    public Vector3 EulerRotation
    {
        get => _eulerRotation;
        set
        {
            SetRotation(value);
        }
    }
    public float Fov
    {
        get => _fov;
        set
        {
            _updateWorld = true;
            _fov = value;
        }
    }
    public float NearPlane
    {
        get => _nearPlane;
        set
        {
            _updateWorld = true;
            _nearPlane = value;
        }
    }
    public float FarPlane
    {
        get => _farPlane;
        set
        {
            _updateWorld = true;
            _farPlane = value;
        }
    }
    public float AspectRatio
    {
        get => _aspectRatio;
        set
        {
            _updateWorld = true;
            _aspectRatio = value;
        }
    }

    private Vector3 _position = Vector3.Zero;
    private Quaternion _rotation = Quaternion.Identity;
    private Vector3 _eulerRotation;

    private float _fov = 70;
    private float _nearPlane = .001f;
    private float _farPlane = 100;

    private Matrix4 _world;
    private Matrix4 _view;
    private Matrix4 _model;

    private Matrix4 _mvp;

    private bool _updateWorld = true;
    private bool _updateViewModel = true;

    public Camera()
    {
        SetRotation(Quaternion.Identity);
    }
    
    public void SetPosition(Vector3 value)
    {
        _position = value;
        _updateViewModel = true;
    }
    public void SetRotation(Quaternion rotation)
    {
        _rotation = rotation;
        Quaternion.ToEulerAngles(rotation, out Vector3 euler);
        _eulerRotation = new Vector3(MathHelper.RadiansToDegrees(euler.X), MathHelper.RadiansToDegrees(euler.Y), MathHelper.RadiansToDegrees(euler.Z));
        
        _updateViewModel = true;
    }
    

    public void SetRotation(Vector3 euler)
    {
        _rotation = MathFuncs.EulerQuaternion(euler);
        _eulerRotation = euler;
        
        _updateViewModel = true;
    }

    public Vector3 GetForward()
    {
        return Vector3.TransformVector(Vector3.UnitZ, Matrix4.CreateFromQuaternion(_rotation));
    }
    
    public void GetMatrix(out Matrix4 mvp, out Matrix4 model)
    {
        bool updateMVP = false;
        if (_updateWorld)
        {
            _world = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(_fov), _aspectRatio, _nearPlane, _farPlane);
            updateMVP = true;
            _updateWorld = false;
        }
        
        if (_updateViewModel)
        {
            Vector3 forward = GetForward();
            
            _view = Matrix4.LookAt(_position, _position + forward, Vector3.UnitY);
            _model = Matrix4.CreateScale(5) * Matrix4.CreateFromQuaternion(_rotation) * Matrix4.CreateTranslation( 1 * forward + _position);
            updateMVP = true;
            _updateViewModel = false;
        }

        if (updateMVP)
        {
            _mvp = _model * _view * _world;
        }

        mvp = _mvp;
        model = _model;
    }
}