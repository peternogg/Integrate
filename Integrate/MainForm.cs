using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// for MessageBox
using Microsoft.VisualBasic;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Integrate
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
        }

        Integral integ;
        List<Func<double, double>> Functions = new List<Func<double,double>>(); // How generic
        float CamMoveSpeed = 0.1f, CamRotateSpeed = 0.1f;
        bool RotateCameraMode = false;

        // Primary form loading event
        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        // Loading and prepping the GL renderer
        private void Viewport_Load(object sender, EventArgs e)
        {
            // Primary init (view setup)
            Matrix4 Pers = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 2, 4f / 3f, .1f, 100f);
            Matrix4 LookAt = Matrix4.LookAt(new Vector3(0, 0f, -5f), Vector3.Zero, Vector3.UnitY);
            
            // Load the view matricies into OpenGL
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref Pers);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref LookAt);

            // Give OpenGL the viewport dimensions
            GL.Viewport(0, 0, Viewport.Width, Viewport.Height);

            // This should be changable as "background color"
            GL.ClearColor(Color4.CornflowerBlue);


            // Make it so appearance is based on position from the camera
            GL.Enable(EnableCap.DepthTest);

            GL.LineWidth(2f);

            // Adding functions to the available list
            // This is directly linked to the function list so that
            // and index of that should DIRECTLY correspond to the 
            // same function in this list. That is, index 0 (f(x) = x) is
            // the index of x => return x; here.
            Functions.Add(x => { return x; });
            Functions.Add(x => { return x * x; });
            Functions.Add(x => { return x * x * x; });
            Functions.Add(x => { return Math.Sin(x); });
            Functions.Add(x => { return Math.Cos(x); });

            // Setup the initial integral
            integ = new Integral(
                function: Functions[0],            
                Divisions:     10,
                Start:         -2,
                End:            2);

            // Draw the first frame on the viewport
            Viewport.Invalidate();
        }

        // Renders the scene into the viewport
        private void Viewport_Paint(object sender, PaintEventArgs e)
        {


            GL.ClearColor(Color4.CornflowerBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

#if DEBUG
            // Debug code to draw some stuff
            GL.Begin(PrimitiveType.Lines);
            {
                GL.Color4(Color4.Red);
                GL.Vertex3(-2f, 0f, 0f);
                GL.Vertex3(2f, 0f, 0f);

                GL.Color4(Color4.Blue);
                GL.Vertex3(0f, -2f, 0f);
                GL.Vertex3(0f, 2f, 0f);

                GL.Color4(Color.Green);
                GL.Vertex3(0f, 2f, 0f);
                GL.Vertex3(0f, 2f, 1f);
            }
            GL.End();


#endif

            integ.Draw();

            // FUCKIng
            // Draw the frame to the viewport
            Viewport.SwapBuffers();
        }

        private void CameraMove(float x, float y, float z)
        {
            Matrix4 Translate = Matrix4.CreateTranslation(-x, -y, -z);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.MultMatrix(ref Translate);
        }

        private void CameraRotate(float Angle, Vector3 axis)
        {
            Matrix4 Rotate = Matrix4.CreateFromAxisAngle(axis, Angle);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.MultMatrix(ref Rotate);
        }

        // Handle any keyboard input coming in
        private void Viewport_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToLower(e.KeyChar);
            switch (e.KeyChar)
            {
                    // Camera Translation (X, Y)
                case 'a':
                    CameraMove(CamMoveSpeed, 0f, 0f);
                    break;
                case 'd':
                    CameraMove(-CamMoveSpeed, 0f, 0f);
                    break;
                case 'w':
                    CameraMove(0f, CamMoveSpeed, 0f);
                    break;
                case 's':
                    CameraMove(0f, -CamMoveSpeed, 0f);
                    break;

                    // Camera Translation (Z)
                case 'r':
                    CameraMove(0f, 0f, CamMoveSpeed);
                    break;
                case 'f':
                    CameraMove(0f, 0f, -CamMoveSpeed);
                    break;
                    
                    // Camera rotation about the Y Axis
                case 'q':
                    CameraRotate(CamRotateSpeed, Vector3.UnitY);
                    break;
                case 'e':
                    CameraRotate(-CamRotateSpeed, Vector3.UnitY);
                    break;

                    // Camera rotation about the X axis (above and below)
                case 't':
                    CameraRotate(-CamRotateSpeed, Vector3.UnitX);
                    break;
                case 'g':
                    CameraRotate(CamRotateSpeed, Vector3.UnitX);
                    break;

            }

            Viewport.Invalidate();

            Console.WriteLine(e.KeyChar);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            float A, B;
            int N;

            if (txtLimA.Text == "" || txtLimB.Text == "" || txtSubdiv.Text == "")
            {
                MessageBox.Show("You can't have blank limits!", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // Nothing else is executed and the frame is
                // refreshed with current values
            }
            else if (float.TryParse(txtLimA.Text, out A)) 
            {
                if (float.TryParse(txtLimB.Text, out B))
                {
                    if (int.TryParse(txtSubdiv.Text, out N))
                    {
                        // All things are good, do the stuff
                        // Remake the integral so that it's
                        // recalculated
                        integ = new Integral(
                            function: Functions[FuncSelectBox.SelectedIndex],
                            Divisions: N,
                            Start: A,
                            End: B
                         );
                    }
                    else
                    {
                        // N isn't a valid integer
                        MessageBox.Show("Your subdivision count is malformed! Please check it again.", "Limit Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    // B is a bad limit
                    MessageBox.Show("Your upper limit is malformed! Please check it again.", "Limit Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                // A is a bad limit
                MessageBox.Show("Your lower limit is malformed! Please check it again.", "Limit Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            // Request a frame refresh
            Viewport.Invalidate();
        }

        private void CamUpBtn_Click(object sender, EventArgs e)
        {
            if (RotateCameraMode)
            {
                CameraRotate(-CamRotateSpeed, Vector3.UnitX);
            }
            else
            {
                CameraMove(0f, CamMoveSpeed, 0f);
            }
            Viewport.Invalidate();
        }

        private void CamLeftBtn_Click(object sender, EventArgs e)
        {
            if (RotateCameraMode)
            {
                CameraRotate(CamRotateSpeed, Vector3.UnitY);
            }
            else
            {
                CameraMove(CamMoveSpeed, 0f, 0f);
            }
            Viewport.Invalidate();
        }

        private void CamDownBtn_Click(object sender, EventArgs e)
        {
            if (RotateCameraMode)
            {
                CameraRotate(CamRotateSpeed, Vector3.UnitX);
            }
            else
            {
                CameraMove(0f, -CamMoveSpeed, 0f);
            }
            Viewport.Invalidate();
        }

        private void CamRightBtn_Click(object sender, EventArgs e)
        {
            if (RotateCameraMode)
            {
                CameraRotate(-CamRotateSpeed, Vector3.UnitY);
            }
            else
            {
                CameraMove(-CamMoveSpeed, 0f, 0f);
            }
            Viewport.Invalidate();
        }

        private void CamResetBtn_Click(object sender, EventArgs e)
        {
            Matrix4 LookAt = Matrix4.LookAt(new Vector3(0, 0f, -5f), Vector3.Zero, Vector3.UnitY);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref LookAt);

            Viewport.Invalidate();
        }

        private void ToggleModeButton_Click(object sender, EventArgs e)
        {
            RotateCameraMode = !RotateCameraMode;
#if DEBUG
            Console.WriteLine(RotateCameraMode);
#endif
        }
    }
}
