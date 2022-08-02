using OpenGLRayMarching.Graphics.OpenGLBindings.Shaders;
using OpenGLRayMarching.Graphics.Static;
using OpenGLRayMarching.Utils;
using OpenTK.Mathematics;

namespace OpenGLRayMarching.Graphics.Shaders;

public class RaymarchingShader : Shader
{
    private static string _vertex = AssemblyUtility.ReadAssemblyFile("OpenGLRayMarching.Graphics.Shaders.Files.raymarching.vert");
    private static string _fragment = AssemblyUtility.ReadAssemblyFile("OpenGLRayMarching.Graphics.Shaders.Files.raymarching.frag");
    
    public RaymarchingShader() : base(_vertex, _fragment)
    { }
    public override void Render(Scene.Scene scene)
    {
        scene.Camera.GetMatrix(out Matrix4 mvp, out Matrix4 model);
        Activate();
        Plate.Object.Activate();
        
        Uniforms["u_model"].SetMatrix4(model);
        Uniforms["u_mvp"].SetMatrix4(mvp);
        Uniforms["u_cameraPosition"].SetVector3(scene.Camera.Position);
        
        Uniforms["u_envTexture"].SetTexture(scene.EnviromentTexture);
        
        DrawObject(Plate.Object);
    }
}