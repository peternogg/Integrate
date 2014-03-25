namespace Integrate
{
    partial class OptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbtnLeftSum = new System.Windows.Forms.RadioButton();
            this.rbtnMidSum = new System.Windows.Forms.RadioButton();
            this.rbtnRightSum = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.chkDrawIntegral = new System.Windows.Forms.CheckBox();
            this.chkDrawOutlines = new System.Windows.Forms.CheckBox();
            this.cmbShapeSelector = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rbtnLeftSum
            // 
            this.rbtnLeftSum.AutoSize = true;
            this.rbtnLeftSum.Location = new System.Drawing.Point(98, 13);
            this.rbtnLeftSum.Name = "rbtnLeftSum";
            this.rbtnLeftSum.Size = new System.Drawing.Size(43, 17);
            this.rbtnLeftSum.TabIndex = 0;
            this.rbtnLeftSum.TabStop = true;
            this.rbtnLeftSum.Text = "Left";
            this.rbtnLeftSum.UseVisualStyleBackColor = true;
            // 
            // rbtnMidSum
            // 
            this.rbtnMidSum.AutoSize = true;
            this.rbtnMidSum.Location = new System.Drawing.Point(98, 36);
            this.rbtnMidSum.Name = "rbtnMidSum";
            this.rbtnMidSum.Size = new System.Drawing.Size(65, 17);
            this.rbtnMidSum.TabIndex = 0;
            this.rbtnMidSum.TabStop = true;
            this.rbtnMidSum.Text = "Midpoint";
            this.rbtnMidSum.UseVisualStyleBackColor = true;
            // 
            // rbtnRightSum
            // 
            this.rbtnRightSum.AutoSize = true;
            this.rbtnRightSum.Location = new System.Drawing.Point(98, 59);
            this.rbtnRightSum.Name = "rbtnRightSum";
            this.rbtnRightSum.Size = new System.Drawing.Size(50, 17);
            this.rbtnRightSum.TabIndex = 0;
            this.rbtnRightSum.TabStop = true;
            this.rbtnRightSum.Text = "Right";
            this.rbtnRightSum.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reimann Mode";
            // 
            // chkDrawIntegral
            // 
            this.chkDrawIntegral.AutoSize = true;
            this.chkDrawIntegral.Location = new System.Drawing.Point(12, 80);
            this.chkDrawIntegral.Name = "chkDrawIntegral";
            this.chkDrawIntegral.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDrawIntegral.Size = new System.Drawing.Size(175, 17);
            this.chkDrawIntegral.TabIndex = 3;
            this.chkDrawIntegral.Text = "Draw Integral Cylinders/Shapes";
            this.chkDrawIntegral.UseVisualStyleBackColor = true;
            // 
            // chkDrawOutlines
            // 
            this.chkDrawOutlines.AutoSize = true;
            this.chkDrawOutlines.Location = new System.Drawing.Point(61, 103);
            this.chkDrawOutlines.Name = "chkDrawOutlines";
            this.chkDrawOutlines.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDrawOutlines.Size = new System.Drawing.Size(126, 17);
            this.chkDrawOutlines.TabIndex = 3;
            this.chkDrawOutlines.Text = "Draw Shape Outlines";
            this.chkDrawOutlines.UseVisualStyleBackColor = true;
            // 
            // cmbShapeSelector
            // 
            this.cmbShapeSelector.FormattingEnabled = true;
            this.cmbShapeSelector.Items.AddRange(new object[] {
            "Cylinder",
            "Flat Rectangle"});
            this.cmbShapeSelector.Location = new System.Drawing.Point(16, 168);
            this.cmbShapeSelector.Name = "cmbShapeSelector";
            this.cmbShapeSelector.Size = new System.Drawing.Size(256, 21);
            this.cmbShapeSelector.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Integral Shape";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbShapeSelector);
            this.Controls.Add(this.chkDrawOutlines);
            this.Controls.Add(this.chkDrawIntegral);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbtnRightSum);
            this.Controls.Add(this.rbtnMidSum);
            this.Controls.Add(this.rbtnLeftSum);
            this.Name = "OptionsForm";
            this.Text = "OptionsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnLeftSum;
        private System.Windows.Forms.RadioButton rbtnMidSum;
        private System.Windows.Forms.RadioButton rbtnRightSum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkDrawIntegral;
        private System.Windows.Forms.CheckBox chkDrawOutlines;
        private System.Windows.Forms.ComboBox cmbShapeSelector;
        private System.Windows.Forms.Label label2;

    }
}