namespace OpenGLRayMarching.Graphics.OpenGLBindings.Shaders
{
    /// <summary>
    /// Uniform interface
    /// </summary>
    public interface IUniform
    {
        /// <summary>
        /// Location of the uniforms
        /// </summary>
        int Location { get; }
    }
}