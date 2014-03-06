using System;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Integrate
{
    // Basically straight from http://neokabuto.blogspot.com/2014/01/opentk-tutorial-5-basic-camera.html
    // Note: Learn how this shit works. Something about Euler angles.
    class Camera
    {
        public Vector3 Position = Vector3.Zero;
        public Vector3 Orientation = new Vector3(MathHelper.Pi, 0, 0);

        public Matrix4 GetViewMatrix()
        {
            Vector3 lookat = new Vector3();

            lookat.X = (float)(Math.Sin(Orientation.X) * Math.Cos(Orientation.Y));
            lookat.Y = (float)Math.Sin(Orientation.Y);
            lookat.Z = (float)(Math.Cos(Orientation.X) * Math.Cos(Orientation.Y));

            Vector3 PosLook;
            Vector3.Add(ref Position, ref lookat, out PosLook);


            return Matrix4.LookAt(Position, PosLook, Vector3.UnitY);
        }

        public void Move(float x, float y, float z)
        {
            Vector3 offset = new Vector3();

            Vector3 forward = new Vector3((float)Math.Sin(Orientation.X), 0, (float)Math.Cos(Orientation.X));
            Vector3 right = new Vector3(-forward.Z, 0, forward.X);

            offset = Vector3.Add(x * right, offset);
            offset = Vector3.Add(y * forward, offset);
            offset.Y += z;

            offset.NormalizeFast();

            Position = Vector3.Add(Position, offset);
        }

        public void AddRotation(float x, float y)
        {
            Orientation.X = (Orientation.X + x) % MathHelper.TwoPi;
            Orientation.Y = Math.Max(Math.Min(Orientation.Y + y, (MathHelper.PiOver2 - 0.1f)), -MathHelper.PiOver2 + 0.1f);
        }
    }
}
