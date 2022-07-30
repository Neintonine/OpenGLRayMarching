using OpenTK.Mathematics;
using Vector3 = OpenTK.Mathematics.Vector3;

namespace OpenGLRayMarching.Scene;

public class Camera
{
    public Vector3 Position
    {
        get => _position;
        set => _position = value;
    }
    public Quaternion Rotation {
        get => _rotation;
        set => _rotation = value;
    }
    public Vector3 EulerRotation
    {
        get => _eulerRotation;
        set
        {
            SetRotation(value);
        }
    }
    
    private Vector3 _position;
    private Quaternion _rotation;
    private Vector3 _eulerRotation;


    public void SetRotation(Quaternion rotation)
    {
        _rotation = rotation;
        Quaternion.ToEulerAngles(rotation, out _eulerRotation);
    }

    public void SetRotation(Vector3 euler)
    {
        _rotation = Quaternion.FromEulerAngles(euler);
        _eulerRotation = euler;
    }

    public Vector3 GetForward()
    {
        return Vector3.TransformVector(Vector3.UnitZ, Matrix4.CreateFromQuaternion(_rotation));
    }
}