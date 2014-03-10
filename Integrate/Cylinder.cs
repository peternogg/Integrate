using System;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Integrate
{
    class Cylinder
    {
        // Number of vertices per circle is fixed at a number
        // Simplifies processing and increases speed
        const int nVertices = 32;

        // List of vertices that describe the circle
        Vector3d[] Vertices = new Vector3d[2 * nVertices];

        // attached to property below
        private Color4 _Color = Color4.DarkSeaGreen;
        public Color4 Color
        {
            get
            {
                return _Color;
            }
            set
            {
                _Color = value;
            }
        }

        public Cylinder(Vector3d Position, double Radius, double Height)
        {
            // Probably won't happen but just to remind myself (catastrophically)
            if (nVertices % 2 != 0) throw new IndexOutOfRangeException("nVertices must be a multiple of 2");


            // Set all the vertices to the 'center' of the circle
            // so that they can be added to later
            for (int i = 0; i < Vertices.Length; i++)
            {
                Vertices[i] = (Vector3d)Position;
            }

            // Run through and calculate the vertices relative to 
            // the position with r = Radius
            CalcVertices(Radius, Height);
        }

        private void CalcVertices(double Radius, double Height)
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

//#if DEBUG
//                Console.WriteLine("Back: {0}\tFront: {1}", Vertices[i], Vertices[i + 1]);
//#endif

                // Increment the angle measure
                theta += dtheta;
            }
        }

        /// <summary>
        /// Draw the cylinder as it's stored
        /// </summary>
        public void Draw()
        {
            int i = 0; // premptive init of i because there's a couple loops
                       // in here that use it (but one after the other)
            if (!OptionBank.Wireframe)
            {
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
            }
            // Draw lines along the sides of the thing to give it contours
            // and junk til i can get shading figured out
            else // if wireframe
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
            
            // Always draw caps
            GL.Begin(PrimitiveType.LineLoop);
            {
                GL.Color4(Color4.Black);
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

        private Vector3d MoveOutwards(Vector3d ToMove)
        {
            try
            {
                ToMove.Y += Math.Sign(ToMove.Y) * 0.001;
                ToMove.Z += Math.Sign(ToMove.Z) * 0.001;
            }
                // Breaks on 1/x for some reason? gives ([decimal], NaN, Infinity) in ToMove
            catch (ArithmeticException e)
            {
                Console.WriteLine("Error in MoveOutwards (probably because 1/x or smth");
            }

            return ToMove;
        }
    }
}
