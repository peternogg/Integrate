using System;
using System.Windows.Forms;

using OpenTK.Graphics;

namespace AAGLControlLib
{
    public partial class AAGLControl : OpenTK.GLControl
    {
        public AAGLControl()
            : base(new GraphicsMode(32, 24, 8, 4), 3, 0, GraphicsContextFlags.ForwardCompatible)
        {
            InitializeComponent();
        }
    }
}
