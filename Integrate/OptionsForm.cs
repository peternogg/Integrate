using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Integrate
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        // Local options to set and deal with
        bool TrunkLines, CapLines, WireframeMode;
        // Other options added here

        private void chkCylWireframe_CheckedChanged(object sender, EventArgs e)
        {
            OptionBank.Wireframe = chkCylWireframe.Checked;
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            chkCylWireframe.Checked = OptionBank.Wireframe;

            WireframeMode = OptionBank.Wireframe;
        }
    }
}
