namespace OpenGLRayMarching.Scene.RaymarchingObjects;

public abstract class RaymarchObject
{
    public string GLSLStructure { get; } = "";
    public string DistanceGLSLCode { get; } = "";
}