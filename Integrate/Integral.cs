using System;
using System.Collections.Generic;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

using NCalc;

// Import the shapes folder/library in this project
using Integrate.Shapes;

namespace Integrate
{
    class Integral
    {
        // 2-element vectors are smaller and so consume less space
        Vector2d[] GraphPoints; // The (x,y) points of the line of the function
        Shape[] Shapes; // The Shapes made from that function
        Color4 _Color = Color4.LightGray; // The color of the line (cylinders handle their own color)
        double ReimannSetting = 0; // A local copy of the reimann setting so that a) I don't have to retype the thing every time and 
                                   //                                             b) so I can check if it's changed and recalculate if it has
        // These are copies of what's passed in so that they can be reused instead of being thrown away
        Expression SavedFunction; // A copy of the function that generated the graph so that it can be recalculated
        int Divisions; // The number of subdivisions in use for calculation
        double Start, End; // The limits of integration (a and b)

        public enum IntegralTypes
        {
            CYLINDER,
            FLAT_RECTANGLE
        }

        public Integral(Expression function, int Divisions, double Start, double End)
        {
            // Set up the storage containers
            GraphPoints = new Vector2d[Divisions + 1];
            Shapes = new Shape[Divisions];
            //Shapes = new Cylinder[Divisions + 1];

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

            for (int i = 0; i < Shapes.Length; i++)
            {
                // CurrPos is the distance along the X axis
                // GraphPoints is the radius of the cylinder
                // and dx is how long it is, along the x axis
                // TODO: Fix the calculations; there's something up that's making it 
                // act really weird (not in the right place)
                F.Parameters["X"] = Start + ((i + ReimannSetting) * dx);

                switch (Properties.Settings.Default.IntegralShape) {
                    // They're already 'ints' but the type isn't right so it's gotta be converted
                    // They're stored as ints tho so it all works out
                    case (int)IntegralTypes.CYLINDER       : Shapes[i] = new Cylinder(currPos, Convert.ToDouble(F.Evaluate()), dx);      break;
                    case (int)IntegralTypes.FLAT_RECTANGLE : Shapes[i] = new FlatRectangle(currPos, dx, Convert.ToDouble(F.Evaluate())); break;
                }

                // Is it possible to do async constructors? Because it might help
                // with speed a bit.

                // Move the position along the X axis in the same increments
                // that the graph has
                currPos.X += dx;
            }

            // Everything's made and done, cool!
        }

        /// <summary>
        /// Just recalculate the integral with current values to update the shapes
        /// </summary>
        public void Recalculate()
        {
            Calculate(SavedFunction, Divisions, Start, End);
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
                for (int i = 0; i < Shapes.Length; i++)
                {
                    Shapes[i].Draw();
                }
            }
        }

        public double Evaluate()
        {
            // Start by building the values to use
            // with n + 10,000 for LOTSA ACCURACY
            int n = 10000; double dx = (End - Start) / n;

            double[] Vals = MakeYValues(dx, n);
            return Simpson(Vals, dx);
        }
        private double[] MakeYValues(double dx, int n)
        {
            double[] Values = new double[n + 1];
            // Starts at 0 and goes to b (from dx * n)
            for (int k = 0; k <= n; k++) {
                SavedFunction.Parameters["X"] = Start + (k * dx);
                Values[k] = Convert.ToDouble(SavedFunction.Evaluate());
            }

            return Values;
        }
        private double Simpson(double[] Values, double dx)
        {
            double accum = 0;
            // Add the first and last values which are always multiplied by 1
            accum += Values[0];
            // this loop goes from Values[1] to Values[MaxK - 1] or Values[Length - 2]
            // since < doesn't include the number, [MaxK] is never accessed
            for (int i = 1; i < Values.Length - 1; i++) {
                // if i is an EVEN number then it's multiplied by 2 and stored
                // if it's odd, it's multiplied by 4 and stored
                if (i % 2 == 0) accum += (Values[i] *= 2);
                else accum += (Values[i] *= 4);
            }
            accum += Values[Values.Length - 1];
            double temp = dx / 3;
            // Multiply everything by a third of dx and store it back into accum
            accum *= temp;

            // the final result
            return Math.Round(accum, 8);
        }
    }
}
