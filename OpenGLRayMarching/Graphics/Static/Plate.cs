#region usings

using OpenGLRayMarching.Graphics.OpenGLBindings.Mesh;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

#endregion

namespace OpenGLRayMarching.Graphics.Static
{
    /// <summary>
    ///     A basic plate
    /// </summary>
    public class Plate : GenericMesh
    {
        /// <summary>
        ///     The object.
        /// </summary>
        public static Plate Object = new Plate();

        //public override int[] Indices { get; set; } = new[] {0, 1, 2, 3};

        private Plate()
        {
        }

        /// <inheritdoc />
        public override VBO<Vector3> Vertex { get; protected set; } = new VBO<Vector3>
        {
            new Vector3(-1f, -1f, 0),
            new Vector3(-1f, 1f, 0),
            new Vector3(1f, 1f, 0),
            new Vector3(1f, 1f, 0),
            new Vector3(1f, -1f, 0),
            new Vector3(-1f, -1f, 0),
        };

        /// <inheritdoc />
        public override VBO<Vector2> UVs { get; protected set; } = new VBO<Vector2>
        {
            new Vector2(0, 1),
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1),
        };

        /// <inheritdoc />
        public override PrimitiveType PrimitiveType { get; protected set; } = PrimitiveType.Triangles;

        /// <inheritdoc />
        public override BoundingBox BoundingBox { get; } =
            new BoundingBox(new Vector3(-.5f, -.5f, 0), new Vector3(.5f, .5f, 0));
    }
}