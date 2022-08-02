using OpenTK.Mathematics;

namespace OpenGLRayMarching.Utils;

public class MathFuncs
{
    public static Matrix4 LookAtMatrix(Vector3 source, Vector3 target)
    {
        target.X += float.Epsilon;
        return Matrix4.LookAt(source, target, Vector3.UnitY).ClearTranslation();

    }

    public static Quaternion EulerQuaternion(Vector3 euler)
    {
        Quaternion tempX = Quaternion.FromAxisAngle(Vector3.UnitX, MathHelper.DegreesToRadians(euler.X));
        Quaternion tempY = Quaternion.FromAxisAngle(Vector3.UnitY, MathHelper.DegreesToRadians(euler.Y));
        Quaternion tempZ = Quaternion.FromAxisAngle(Vector3.UnitZ, MathHelper.DegreesToRadians(euler.Z));
        return (tempZ * tempY * tempX);
    }
}