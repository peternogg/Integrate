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
        
        private void OptionsForm_Load(object sender, EventArgs e)
        {
            // Get copies of the settings for easy of reference :V
            double LocalSum = Properties.Settings.Default.ReimannSumLMR;

            // Setting up the Reimann Mode radio buttons
            if (LocalSum == 0) rbtnLeftSum.Checked = true;
            else if (LocalSum == 0.5) rbtnMidSum.Checked = true;
            else if (LocalSum == 1) rbtnRightSum.Checked = true;

            // Set the integral drawing options to settings in memory
            chkDrawIntegral.Checked = Properties.Settings.Default.DrawIntegral;
            chkDrawOutlines.Checked = Properties.Settings.Default.DrawOutlines;

            cmbShapeSelector.SelectedIndex = Properties.Settings.Default.IntegralShape;
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save the changed options
            if (rbtnLeftSum.Checked) Properties.Settings.Default.ReimannSumLMR = 0;
            else if (rbtnMidSum.Checked) Properties.Settings.Default.ReimannSumLMR = 0.5;
            else if (rbtnRightSum.Checked) Properties.Settings.Default.ReimannSumLMR = 1;

            Properties.Settings.Default.DrawIntegral = chkDrawIntegral.Checked;
            Properties.Settings.Default.DrawOutlines = chkDrawOutlines.Checked;

            Properties.Settings.Default.IntegralShape = cmbShapeSelector.SelectedIndex;

            Properties.Settings.Default.Save();
        }
    }
}
