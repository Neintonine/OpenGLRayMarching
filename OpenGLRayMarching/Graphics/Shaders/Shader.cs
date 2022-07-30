using OpenGLRayMarching.Graphics.OpenGLBindings.Shaders;

namespace OpenGLRayMarching.Graphics.Shaders;

public class Shader : GenericShader
{

    public Shader(string combinedData) : base(combinedData)
    { }
    public Shader(string vertex, string fragment) : base(vertex, fragment)
    { }
    public Shader(ShaderFileCollection shaderFileFiles) : base(shaderFileFiles)
    { }

}