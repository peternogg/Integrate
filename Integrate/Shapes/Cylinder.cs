using System;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Integrate.Shapes
{
    class Cylinder : Shape
    {
        // Number of vertices per circle is fixed at a number
        // Simplifies processing and increases speed
        const int nVertices = 32;

        // List of vertices that describe the circle
        //Vector3d[] Vertices = new Vector3d[2 * nVertices];

        // attached to property below

        public Cylinder(Vector3d Position, double Radius, double Height) : base(2 * nVertices, Position)
        {
            // Since Shapes does the work of setting up the vertices array, we can jump straight into calculating!

            // Run through and calculate the vertices relative to 
            // the position with r = Radius
            Calculate(Radius, Height);
        }

        protected override void Calculate(double Radius, double Height)
        {
            double theta = 0, dtheta = MathHelper.TwoPi / nVertices;

            for (int i = 0; i < Vertices.Length; i += 2)
            {
                // Set back circle's info
                Vertices[i].Y += Radius * Math.Cos(theta);
                Vertices[i].Z += Radius * Math.Sin(theta);

                // Set front circle's into
                Vertices[i + 1].Y += Vertices[i].Y;
                Vertices[i + 1].Z += Vertices[i].Z;
                // Add the height to the position to get
                // an identical circle, but forward some
                Vertices[i + 1].X += Height;

                // Increment the angle measure
                theta += dtheta;
            }
        }

        /// <summary>
        /// Draw the cylinder as it's stored
        /// </summary>
        public override void Draw()
        {
            int i = 0; // premptive init of i because there's a couple loops
                       // in here that use it (but one after the other)
            GL.Color4(_Color);

            // Draw the rear circle (even indices)
            GL.Begin(PrimitiveType.Polygon);
            {
                for (i = 0; i < Vertices.Length; i += 2)
                {
                    GL.Vertex3(Vertices[i]);
                }
            }
            GL.End();

            // Draw the front circle (odd indices)
            GL.Begin(PrimitiveType.Polygon);
            {
                for (i = 1; i < Vertices.Length; i += 2)
                {
                    GL.Vertex3(Vertices[i]);
                }
            }
            GL.End();

            // Draw the connecting bits
            GL.Begin(PrimitiveType.TriangleStrip);
            {

                for (i = 0; i < Vertices.Length; i += 2)
                {
                    GL.Vertex3(Vertices[i]);
                    GL.Vertex3(Vertices[i + 1]);
                }
            }
            GL.End();
        
            // Draw lines along the sides of the thing to give it contours
            // and junk til i can get shading figured out
            if (Properties.Settings.Default.DrawSideOutlines)
            {
                GL.Begin(PrimitiveType.Lines);
                {
                    GL.Color4(Color4.Black);
                    for (i = 0; i < Vertices.Length; i += 2)
                    {
                        GL.Vertex3(MoveOutwards(Vertices[i]));
                        GL.Vertex3(MoveOutwards(Vertices[i + 1]));
                    }
                }
                GL.End();
            }
            // If the user wants to draw outlines, do so
            if (Properties.Settings.Default.DrawOutlines)
            {
                GL.Color4(Color4.Black);
                GL.Begin(PrimitiveType.LineLoop);
                {
                    // Back circle
                    for (i = 0; i < Vertices.Length; i += 2)
                    {
                        GL.Vertex3(MoveOutwards(Vertices[i]));
                    }
                }
                GL.End();

                GL.Begin(PrimitiveType.LineLoop);
                {
                    // Front circle
                    for (i = 1; i < Vertices.Length; i += 2)
                    {
                        GL.Vertex3(MoveOutwards(Vertices[i]));
                    }
                }
                GL.End();
            }
        }
    }
}
