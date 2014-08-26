using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

using NCalc;

namespace Integrate
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        Integral integ;
        Expression exp = new Expression("X");
        float CamMoveSpeed = 0.1f, CamRotateSpeed = MathHelper.PiOver6 / 4f;
        bool RotateCameraMode = false;
        const int DEFAULT_SUBDIVISONS = 10;

        // Primary form loading event
        private void MainForm_Load(object sender, EventArgs e)
        {
            Console.SetOut(new System.IO.StreamWriter("log.txt"));
        }

        // Loading and prepping the GL renderer
        private void Viewport_Load(object sender, EventArgs e)
        {
            // Primary init (view setup)
            Matrix4 Pers = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 2, Viewport.Width / Viewport.Height, .1f, 100f);
            Matrix4 LookAt = Matrix4.LookAt(new Vector3(0, 0f, 3.5f), Vector3.Zero, Vector3.UnitY);
            
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

            // Set up the initial integral
            integ = new Integral(
                function: exp,
                Divisions: 10,
                Start: -2,
                End: 2);

            //IntegValueDisplay.Text = Math.Round(integ.Evaluate(), 4).ToString();

            // Draw the first frame on the viewport
            Viewport.Invalidate();
        }

        // Renders the scene into the viewport
        private void Viewport_Paint(object sender, PaintEventArgs e)
        {
            GL.ClearColor(Color4.CornflowerBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Draw world axes
            GL.Begin(PrimitiveType.Lines);
            {
                GL.Color4(Color4.Red);
                GL.Vertex3(-50f, 0f, 0f);
                GL.Vertex3(50f, 0f, 0f);
                
                // Draw the grid lines/markers from -50 to 50 units out
                // TODO: Make these adjustable
                for (int i = -50; i < 50; i++)
                {
                    GL.Vertex3(i, 0.125, 0);
                    GL.Vertex3(i, -0.125, 0);
                }

                GL.Color4(Color4.Blue);
                GL.Vertex3(0f, -50f, 0f);
                GL.Vertex3(0f, 50f, 0f);

                // Draw Y-axis markers
                for (int i = -50; i < 50; i++)
                {
                    GL.Vertex3(0.125, i, 0);
                    GL.Vertex3(-0.125, i, 0);
                }

                GL.Color4(Color.Green);
                GL.Vertex3(0f, 0f, -50f);
                GL.Vertex3(0f, 0f, 50f);

                // Draw Z-axis markers
                for (int i = -50; i < 50; i++)
                {
                    GL.Vertex3(0, 0.125, i);
                    GL.Vertex3(0, -0.125, i);
                }
            }
            GL.End();

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
                    CameraMove(-CamMoveSpeed, 0f, 0f);
                    break;
                case 'd':
                    CameraMove(CamMoveSpeed, 0f, 0f);
                    break;
                case 'w':
                    CameraMove(0f, CamMoveSpeed, 0f);
                    break;
                case 's':
                    CameraMove(0f, -CamMoveSpeed, 0f);
                    break;

                    // Camera Translation (Z)
                case 'r':
                    CameraMove(0f, 0f, -CamMoveSpeed);
                    break;
                case 'f':
                    CameraMove(0f, 0f, CamMoveSpeed);
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
                    CameraRotate(CamRotateSpeed, Vector3.UnitX);
                    break;
                case 'g':
                    CameraRotate(-CamRotateSpeed, Vector3.UnitX);
                    break;

            }

            Viewport.Invalidate();

            Console.WriteLine(e.KeyChar);
        }

        private void ShowError(string ErrorText)
        {
            MessageBox.Show(ErrorText, "Error!", MessageBoxButtons.OK);
        }

        /// <summary>
        /// Reformats a string expression for NCalc to accept
        /// by ensuring that only the first letter of every word is
        /// capitalized. 
        /// </summary>
        /// <param name="Exp"></param>
        /// <returns></returns>
        private string FixExpression(string Exp)
        {
            char[] TempArray = Exp.ToCharArray();

            // Have regex find the beginnings of words (space or not) and put them into m
            foreach (Match m in Regex.Matches(Exp, @"\w+"))
            {
                // TempArray is a 1:1 copy of FuncEntryBox.Text but in a different type
                // so indexing into it gives the same result as indexing into .Text
                // which is to say that it's the same character in the same spot
                TempArray[m.Index] = Char.ToUpper(Exp[m.Index]);
                // This bit takes that character and UpperCases it if it's at the beginning
                // of a word, then stores it at the same place it came from in TempArray
                // The result is that x + sin(x) becomes X + Sin(X)
            }

            // Next up we have to make sure that all of the non-beginning characters are lower-case
            foreach (Match m in Regex.Matches(Exp, @"\B\w+"))
            {
                // Starting at the index of the match, go to the match + the length of that matching string
                for (int i = m.Index; i < (m.Index + m.Length); i++)
                {
                    TempArray[i] = Char.ToLower(Exp[i]);
                }
            }

            // This loop removes and non-word values that aren't +, -, *, \, a space or parenthesis
            foreach (Match m in Regex.Matches(Exp, @"(?(\W)[^\+\-\/\*\s\(\)]|\W)"))
            {
                TempArray[m.Index] = '\0';
            }
            int RemoveIndex = 0;
            string TempString = new string(TempArray);
            while ((RemoveIndex = TempString.IndexOf('\0')) > -1)
            {
                TempString = TempString.Remove(RemoveIndex, 1);
            }

            // The final effect of those two loops is that sIN(x) + cOs(X) becomes Sin(X) + Cos(X)
            // And, in general, the first letter of any word becomes capitalized, while all of the rest
            // are lower-cased. Anyway, now that we have everthing ready, send it back as a new string

            return new string(TempArray);

        }

        private bool VerifyEquationIsGood(string Equation)
        {
            bool Error = false;
            exp = new Expression(Equation);
            // Test out the expression to catch any undefined variables
            // This method is much easier and faster than checking w/ a regex
            // because it's hard to find EXACTLY what I want :B
            try
            {
                // Give X some simple value to define it and don't define any
                // other variables
                exp.Parameters["X"] = 1;
                exp.Evaluate();
            }
            catch (ArgumentException ae)
            {
                if (ae.Message.Contains("not defined"))
                {
                    ShowError("Undefined variable found; only x/X may be used.");
                    Error = true;
                }
            }

            return Error;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            /*\
             
             NOTE: there's gotos here but they all go to one place okay step off the linux kernel does it it's cool man
                          
            \*/

            float A, B;
            int N;


            // If the subdivisons box is empty, set it to the default value
            if (txtSubdiv.Text == "") txtSubdiv.Text = DEFAULT_SUBDIVISONS.ToString();

            // Check limit A, limit B and the subdivisions individually, using the same method
            if (!float.TryParse(txtLimA.Text, out A)) {
                // Todo: Better error message?
                ShowError("Limit A is invalid!");
                goto ERROR;
            }
            if (!float.TryParse(txtLimB.Text, out B)) {
                ShowError("Limit B is invalid!");
                goto ERROR;
            }
            if (!int.TryParse(txtSubdiv.Text, out N)) {
                ShowError("Subdivisons is invalid!");
                goto ERROR;
            }

            // Check that the function entered is good
            string Exp = FuncEntryBox.Text;
            if (FuncEntryBox.Text != "") Exp = FixExpression(Exp);
            else ShowError("You need to enter a function in the box.");

// ------------- If anything goes wrong, hop down here and quit checking. 
        ERROR:
            // Extra error stuff?
            return;
            
            #region Old Junk
            /*else if (float.TryParse(txtLimA.Text, out A)) 
            {
                if (float.TryParse(txtLimB.Text, out B))
                {
                    if (int.TryParse(txtSubdiv.Text, out N))
                    {
                        if (FuncEntryBox.Text != "") {
                            // Looks good, let's reformat the function so that NCalc will take it
                            // Convert the string to an array for a bit so that individual elements can
                            // be edited
                            char[] TempArray = FuncEntryBox.Text.ToCharArray();

                            // Have regex find the beginnings of words (space or not) and put them into
                            // m
                            foreach (Match m in Regex.Matches(FuncEntryBox.Text, @"\w+"))
                            {
                                // TempArray is a 1:1 copy of FuncEntryBox.Text but in a different type
                                // so indexing into it gives the same result as indexing into .Text
                                // which is to say that it's the same character in the same spot
                                TempArray[m.Index] = Char.ToUpper(FuncEntryBox.Text[m.Index]);
                                // This bit takes that character and UpperCases it if it's at the beginning
                                // of a word, then stores it at the same place it came from in TempArray
                                // The result is that x + sin(x) becomes X + Sin(X)
                            }

                            // Next up we have to make sure that all of the non-beginning characters are lower-case
                            foreach (Match m in Regex.Matches(FuncEntryBox.Text, @"\B\w+"))
                            {
                                // Starting at the index of the match, go to the match + the length of that matching string
                                for (int i = m.Index; i < (m.Index + m.Length); i++)
                                {
                                    TempArray[i] = Char.ToLower(FuncEntryBox.Text[i]);
                                }
                            }

                            // This loop removes and non-word values that aren't +, -, *, \, a space or parenthesis
                            foreach (Match m in Regex.Matches(FuncEntryBox.Text, @"(?(\W)[^\+\-\/\*\s\(\)]|\W)"))
                            {
                                TempArray[m.Index] = '\0';
                            }
                            int RemoveIndex = 0;
                            string TempString = new string(TempArray);
                            while ((RemoveIndex = TempString.IndexOf('\0')) > -1)
                            {
                                TempString = TempString.Remove(RemoveIndex, 1);
                            }

                            // The final effect of those two loops is that sIN(x) + cOs(X) becomes Sin(X) + Cos(X)

                            // Now convert the char[] back into a string and put it in FuncEntryBox so that
                            // everything works good and the user sees how to format it in the future
                            FuncEntryBox.Text = TempString;

                            exp = new Expression(FuncEntryBox.Text);

                            // Test out the expression to catch any undefined variables
                            // This method is much easier and faster than checking w/ a regex
                            // because it's hard to find EXACTLY what I want :B
                            try 
                            {
                                // Give X some simple value to define it and don't define any
                                // other variables
                                exp.Parameters["X"] = 1;
                                exp.Evaluate(); 
                            }
                            catch (ArgumentException ae)
                            {
                                if (ae.Message.Contains("not defined"))
                                {
                                    MessageBox.Show("You can only use X as a variable!");
                                    ExtraVariablesInExp = true;
                                }
                            }

                            if (!ExtraVariablesInExp) 
                            {
                                if (exp.HasErrors())
                                {
                                    MessageBox.Show("The function you entered is invalid.", "Function Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    // THIS IS IT
                                    // THE MEAT OF THE PROGRAM, RIGHT HERE
                                    // FINALLY
                                    integ = new Integral(
                                        function: exp,
                                        Divisions: N,
                                        Start: A,
                                        End: B
                                     );
                                    
                                    // Evaluate the integral using simpson's rule in the class
                                    EvalIntegral();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("You have to enter something in the box!", "Function Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
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
        */
            #endregion
        }


        private void EvalIntegral()
        {
            // Evaluates the integral, assuming that it's flat
            // that is, it doesn't take into account what exactly the integral is displayed as
            // it only evaluates the graph of the integral
            double FirstEval = integ.Evaluate();
            string FinalResult = "";

            // If there's a cylinder, then it shows 2 * (pi) * Evaluate(), then the approx. value in parenthesis
            // so 2π·Number (approx.)
            // While with a flat rectangle, it'll just be the number returned by FirstEval

            switch (Properties.Settings.Default.IntegralShape) {
                // But here, add in the 2 * pi bit
                case (int)Integral.IntegralTypes.CYLINDER:
                    FinalResult = "2π·" + Math.Round(FirstEval, 5).ToString()
                        + "(~" + Math.Round(FirstEval * 2 * Math.PI, 5).ToString() + ")";
                    break;
                // Do nothing for this one since it's basically what Evaluate() does anyway
                case (int)Integral.IntegralTypes.FLAT_RECTANGLE:
                    FinalResult = Math.Round(FirstEval, 5).ToString();
                    break;
            }

            // Display value via something
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
                CameraMove(-CamMoveSpeed, 0f, 0f);
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
                CameraMove(CamMoveSpeed, 0f, 0f);
            }
            Viewport.Invalidate();
        }

        private void CamResetBtn_Click(object sender, EventArgs e)
        {
            Matrix4 LookAt = Matrix4.LookAt(new Vector3(0, 0f, 5f), Vector3.Zero, Vector3.UnitY);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref LookAt);

            Viewport.Invalidate();
        }

        private void ToggleModeButton_Click(object sender, EventArgs e)
        {
            RotateCameraMode = !RotateCameraMode;
            if (RotateCameraMode) PanRotLabel.Text = "Rotating"; else PanRotLabel.Text = "Panning";
            SwapButtonLabels();
#if DEBUG
            Console.WriteLine(RotateCameraMode);
#endif
        }

        private void SwapButtonLabels()
        {
            if (RotateCameraMode)
            {
                CamUpBtn.Text = "Over";
                CamDownBtn.Text = "Under";
            }
            else
            {
                CamUpBtn.Text = "Up";
                CamDownBtn.Text = "Down";
            }
        }

        private void CamFwdBtn_Click(object sender, EventArgs e)
        {
            // Doesn't deal with toggle stuff
            CameraMove(0f, 0f, -CamMoveSpeed);
            Viewport.Invalidate();
        }

        private void CamBackBtn_Click(object sender, EventArgs e)
        {
            CameraMove(0f, 0f, CamMoveSpeed);
            Viewport.Invalidate();
        }

        private void LimitBoxes_Enter(object sender, EventArgs e)
        {
            // Fuck you microsoft I don't need your shitty objects B)
            TextBox Sender = (TextBox)sender;
            Sender.ForeColor = Color.Black;
        }
    }
}
