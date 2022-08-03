namespace OpenGLRayMarching.Scene.RaymarchingObjects;

public abstract class RaymarchObject 
{
    public const string BaseStructure = "mat4 matrix; float roughness; float noise; int booleanOperator;";
    
    public abstract string GLSLStructure { get; }
    public abstract string DistanceGLSLCode { get; }
}