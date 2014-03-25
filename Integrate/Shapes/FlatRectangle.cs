using System;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Integrate.Shapes
{
    class FlatRectangle : Shape
    {
        const int nVertices = 4;
        public FlatRectangle(Vector3d Position, double dx, double height) : base(nVertices, Position) {
            Calculate(dx, height);
        }

        public override void Draw() {
            GL.Color4(_Color);
            GL.Begin(PrimitiveType.Polygon);
            {
                for (int i = 0; i < Vertices.Length; i++) {
                    GL.Vertex3(Vertices[i]);
                }
            } 
            GL.End();
            if (Properties.Settings.Default.DrawOutlines) {
                GL.Color4(Color4.Black);
                GL.Begin(PrimitiveType.LineLoop);
                {
                    for (int i = 0; i < Vertices.Length; i++) {
                        GL.Vertex3(MoveOutwards(Vertices[i]));
                    }
                }
                GL.End();
            }
        }

        /// <summary>
        /// Calculate the shape and store the result in its vertices array
        /// </summary>
        /// <param name="width">dx, or the length on the x axis</param>
        /// <param name="height">f(x), or the length on the y axis</param>
        protected override void Calculate(double width, double height) {
            // This is oddly simple since it's just a rectangle
            // But we just set each of the 4 vertices individually
            // Vertices[0] is the bottom-left corner, so nothing happens to it
            // Vertices[1] is the top-left corner, so we just have to add the height to it
            Vertices[1].Y += height;
            // Vertices[2] is the top-right corner, so add width and height
            Vertices[2].X += width;
            Vertices[2].Y += height;
            // Finally, Vertices[3] is the bottom-right corner, so we just have to add the width
            Vertices[3].X += width;
        }
    }
}
