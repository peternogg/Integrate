using System;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Integrate.Shapes
{
    abstract class Shape
    {
        protected Vector3d[] Vertices;
        protected Color4 _Color = Color4.DarkSeaGreen;
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
        /// <summary>
        /// Base initializer for all shapes
        /// </summary>
        /// <param name="vertices">The number of vertices that make up the shape</param>
        /// <param name="Position">The zero position of the vertices (these are shifted around with Calculate())</param>
        public Shape(int vertices, Vector3d Position)
        {
            this.Vertices = new Vector3d[vertices];
            for (int i = 0; i < Vertices.Length; i++) {
                Vertices[i] = Position;
            }
        }

        public abstract void Draw();
        protected abstract void Calculate(double width, double height);
        protected Vector3d MoveOutwards(Vector3d ToMove)
        {
            try {
                ToMove.Y += Math.Sign(ToMove.Y) * 0.001;
                ToMove.Z += Math.Sign(ToMove.Z) * 0.001;
            }
            // Breaks on 1/x for some reason? gives ([decimal], NaN, Infinity) in ToMove
            catch (ArithmeticException e) {
                Console.WriteLine("Error in MoveOutwards (probably because 1/x or smth)");
            }

            return ToMove;
        }
    }
}
