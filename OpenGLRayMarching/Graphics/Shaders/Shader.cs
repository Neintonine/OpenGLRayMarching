using OpenGLRayMarching.Graphics.OpenGLBindings.Shaders;
using OpenGLRayMarching.Graphics.Static;
using OpenTK.Mathematics;

namespace OpenGLRayMarching.Graphics.Shaders;

public class Shader : GenericShader
{

    public Shader(string combinedData) : base(combinedData)
    { }
    public Shader(string vertex, string fragment) : base(vertex, fragment)
    { }
    public Shader(ShaderFileCollection shaderFileFiles) : base(shaderFileFiles)
    { }

    public void Render(Scene.Scene scene)
    {
        scene.Camera.GetMatrix(out Matrix4 mvp, out Matrix4 model);
        Activate();
        Plate.Object.Activate();
        
        Uniforms["u_model"].SetMatrix4(model);
        Uniforms["u_mvp"].SetMatrix4(mvp);
        Uniforms["u_cameraPosition"].SetVector3(scene.Camera.Position);
        
        DrawObject(Plate.Object);
    }

}