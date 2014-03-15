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
        Vector2d[] GraphPoints; // The (x,y) points of the line of the function
        Cylinder[] Disks; // The disks made from that function
        Color4 _Color = Color4.LightGray; // The color of the line (cylinders handle their own color)
        double ReimannSetting = 0; // A local copy of the reimann setting so that a) I don't have to retype the thing every time and 
                                   //                                             b) so I can check if it's changed and recalculate if it has
        // These are copies of what's passed in so that they can be reused instead of being thrown away
        Expression SavedFunction; // A copy of the function that generated the graph so that it can be recalculated
        int Divisions; // The number of subdivisions in use for calculation
        double Start, End; // The limits of integration (a and b)

        public Integral(Expression function, int Divisions, double Start, double End)
        {
            // Set up the storage containers
            GraphPoints = new Vector2d[Divisions + 1];
            Disks = new Cylinder[Divisions + 1];

            // Save the input info for later
            SavedFunction = function;
            this.Divisions = Divisions;
            this.Start = Start; this.End = End;
            
            // Calculate and build the actual fun bits
            Calculate(SavedFunction, Divisions, Start, End);
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
                F.Parameters["X"] = GraphPoints[i].X = Start + (i * dx);
                Console.WriteLine(F.Evaluate());
                GraphPoints[i].Y = Convert.ToDouble(F.Evaluate());
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
                F.Parameters["X"] = Start + ((i - ReimannSetting) * dx);
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
            // Start by checking to see if any relevant settings have changed
            if (Properties.Settings.Default.ReimannSumLMR != ReimannSetting)
            {
                ReimannSetting = Properties.Settings.Default.ReimannSumLMR;
                // If it has, recalculate the integral
                Console.WriteLine("Reimann changed, recalculating...");

                Calculate(SavedFunction, Divisions, Start, End);
                Console.WriteLine("Done calculating!");

            }


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

            // Toggle to draw/not draw the cylinders or whatever
            if (Properties.Settings.Default.DrawIntegral)
            {
                // Now draw all of the cylinders that we've made
                for (int i = 0; i < Disks.Length; i++)
                {
                    Disks[i].Draw();
                }
            }
        }
    }
}
