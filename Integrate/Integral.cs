using System;
using System.Collections.Generic;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

using NCalc;

namespace Integrate
{
    class Integral
    {
        // 2-element vectors are smaller and so consume less space
        Vector2d[] GraphPoints;
        Cylinder[] Disks;
        Color4 _Color = Color4.LightGray;
        public Integral(Expression function, int Divisions, double Start, double End)
        {
            GraphPoints = new Vector2d[Divisions];
            Disks = new Cylinder[Divisions];

            Calculate(function, Divisions, Start, End);
        }

        private void Calculate(Expression F, int Divisions, double Start, double End)
        {
            // Create the difference in X values to generate 
            // the actual X values
            double dx = (End - Start) / Divisions;

            // Generate and store the graph points in double length Vectors
            for (int i = 0; i < GraphPoints.Length; i++)
            {
                // Set X = the X value at the point and store it in F and GraphPoints
                F.Parameters["x"] = GraphPoints[i].X = Start + (dx * i);
                Console.WriteLine(F.Evaluate());
                GraphPoints[i].Y = Convert.ToDouble(F.Evaluate());
                if (double.IsInfinity(GraphPoints[i].Y)) GraphPoints[i].Y = float.MaxValue;
            }

            // Build the cylinders
            // Position to create the cylinder at
            Vector3d currPos = new Vector3d(Start, 0, 0);

            for (int i = 0; i < Disks.Length; i++)
            {
                // CurrPos is the distance along the X axis
                // GraphPoints is the radius of the cylinder
                // and dx is how long it is, along the x axis
                // TODO: Fix the calculations; there's something up that's making it 
                // act really weird (not in the right place)
                F.Parameters["x"] = Start + (dx * i);
                Disks[i] = new Cylinder(currPos, Convert.ToDouble(F.Evaluate()), dx);
                // Is it possible to do async constructors? Because it might help
                // with speed a bit.

                // Move the position along the X axis in the same increments
                // that the graph has
                currPos.X += dx;
            }

            // Everything's made and done, cool!
        }

        public void Draw()
        {
            // Start by drawing the line describing the graph
            // so that it's visible and can be matched to the cylinders

            GL.Begin(PrimitiveType.LineStrip);
            {
                // Should add a color variable
                GL.Color4(_Color);
                for (int i = 0; i < GraphPoints.Length; i++)
                {
                    GL.Vertex2(GraphPoints[i]);
                }
            }
            GL.End();

            // Now draw all of the cylinders that we've made
            for (int i = 0; i < Disks.Length; i++)
            {
                Disks[i].Draw();
            }
        }
    }
}
