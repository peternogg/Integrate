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
            this.chkCylWireframe = new System.Windows.Forms.CheckBox();
            this.chkCylCap = new System.Windows.Forms.CheckBox();
            this.chkCylTrunk = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkCylWireframe
            // 
            this.chkCylWireframe.AutoSize = true;
            this.chkCylWireframe.Location = new System.Drawing.Point(13, 13);
            this.chkCylWireframe.Name = "chkCylWireframe";
            this.chkCylWireframe.Size = new System.Drawing.Size(80, 17);
            this.chkCylWireframe.TabIndex = 0;
            this.chkCylWireframe.Text = "checkBox1";
            this.chkCylWireframe.UseVisualStyleBackColor = true;
            this.chkCylWireframe.CheckedChanged += new System.EventHandler(this.chkCylWireframe_CheckedChanged);
            // 
            // chkCylCap
            // 
            this.chkCylCap.AutoSize = true;
            this.chkCylCap.Location = new System.Drawing.Point(12, 36);
            this.chkCylCap.Name = "chkCylCap";
            this.chkCylCap.Size = new System.Drawing.Size(80, 17);
            this.chkCylCap.TabIndex = 0;
            this.chkCylCap.Text = "checkBox1";
            this.chkCylCap.UseVisualStyleBackColor = true;
            this.chkCylCap.CheckedChanged += new System.EventHandler(this.chkCylCap_CheckedChanged);
            // 
            // chkCylTrunk
            // 
            this.chkCylTrunk.AutoSize = true;
            this.chkCylTrunk.Location = new System.Drawing.Point(13, 59);
            this.chkCylTrunk.Name = "chkCylTrunk";
            this.chkCylTrunk.Size = new System.Drawing.Size(80, 17);
            this.chkCylTrunk.TabIndex = 0;
            this.chkCylTrunk.Text = "checkBox1";
            this.chkCylTrunk.UseVisualStyleBackColor = true;
            this.chkCylTrunk.CheckedChanged += new System.EventHandler(this.chkCylTrunk_CheckedChanged);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.chkCylTrunk);
            this.Controls.Add(this.chkCylCap);
            this.Controls.Add(this.chkCylWireframe);
            this.Name = "OptionsForm";
            this.Text = "OptionsForm";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkCylWireframe;
        private System.Windows.Forms.CheckBox chkCylCap;
        private System.Windows.Forms.CheckBox chkCylTrunk;
    }
}