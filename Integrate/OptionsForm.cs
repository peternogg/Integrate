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

        private void chkCylTrunk_CheckedChanged(object sender, EventArgs e)
        {
            OptionBank.DrawTrunkLines = chkCylTrunk.Checked;
        }

        private void chkCylCap_CheckedChanged(object sender, EventArgs e)
        {
            OptionBank.DrawCapLines = chkCylCap.Checked;
        }

        private void chkCylWireframe_CheckedChanged(object sender, EventArgs e)
        {
            OptionBank.Wireframe = chkCylWireframe.Checked;
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            chkCylWireframe.Checked = OptionBank.Wireframe;
            chkCylTrunk.Checked = OptionBank.DrawTrunkLines;
            chkCylCap.Checked = OptionBank.DrawCapLines;
        }
    }
}
