using OpenGLRayMarching.Graphics.OpenGLBindings.Shaders;
using OpenGLRayMarching.Graphics.Static;
using OpenGLRayMarching.Utils;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using All = OpenTK.Graphics.OpenGL4.All;
using GL = OpenTK.Graphics.OpenGL4.GL;

namespace OpenGLRayMarching.Graphics.Shaders;

public abstract class Shader : GenericShader
{

    protected Shader(string combinedData) : base(combinedData)
    { }
    protected Shader(string vertex, string fragment) : base(vertex, fragment)
    { }
    protected Shader(ShaderFileCollection shaderFileFiles) : base(shaderFileFiles)
    { }

    public abstract void Render(Scene.Scene scene);

    static Shader()
    {
        ShaderExtensions.AddAssemblyExtensions("ext", "OpenGLRayMarching.Graphics.Shaders.Extensions");
    }

}