namespace OpenGLRayMarching.Graphics.OpenGLBindings.Mesh
{
    /// <summary>
    /// Represents a mesh that can be a line object.
    /// </summary>
    public interface ILineMesh
    {
        /// <summary>
        /// The width of a line.
        /// </summary>
        float LineWidth { get; set; }
    }
}