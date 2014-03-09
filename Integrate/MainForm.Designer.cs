namespace Integrate
{
    partial class MainForm
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
            this.Viewport = new AAGLControlLib.AAGLControl();
            this.CamControlBox = new System.Windows.Forms.GroupBox();
            this.CamUpBtn = new System.Windows.Forms.Button();
            this.CamDownBtn = new System.Windows.Forms.Button();
            this.ToggleModeButton = new System.Windows.Forms.Button();
            this.CamRightBtn = new System.Windows.Forms.Button();
            this.CamResetBtn = new System.Windows.Forms.Button();
            this.CamLeftBtn = new System.Windows.Forms.Button();
            this.FuncSelectBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLimB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLimA = new System.Windows.Forms.TextBox();
            this.txtSubdiv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.HelpBtn = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnShowOptions = new System.Windows.Forms.Button();
            this.CamBackBtn = new System.Windows.Forms.Button();
            this.CamFwdBtn = new System.Windows.Forms.Button();
            this.PanRotLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CamControlBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Viewport
            // 
            this.Viewport.BackColor = System.Drawing.Color.Black;
            this.Viewport.Location = new System.Drawing.Point(13, 13);
            this.Viewport.Name = "Viewport";
            this.Viewport.Size = new System.Drawing.Size(563, 424);
            this.Viewport.TabIndex = 0;
            this.Viewport.VSync = true;
            this.Viewport.Load += new System.EventHandler(this.Viewport_Load);
            this.Viewport.Paint += new System.Windows.Forms.PaintEventHandler(this.Viewport_Paint);
            this.Viewport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Viewport_KeyPress);
            // 
            // CamControlBox
            // 
            this.CamControlBox.Controls.Add(this.label4);
            this.CamControlBox.Controls.Add(this.PanRotLabel);
            this.CamControlBox.Controls.Add(this.CamUpBtn);
            this.CamControlBox.Controls.Add(this.CamDownBtn);
            this.CamControlBox.Controls.Add(this.ToggleModeButton);
            this.CamControlBox.Controls.Add(this.CamRightBtn);
            this.CamControlBox.Controls.Add(this.CamResetBtn);
            this.CamControlBox.Controls.Add(this.CamFwdBtn);
            this.CamControlBox.Controls.Add(this.CamBackBtn);
            this.CamControlBox.Controls.Add(this.CamLeftBtn);
            this.CamControlBox.Location = new System.Drawing.Point(582, 13);
            this.CamControlBox.Name = "CamControlBox";
            this.CamControlBox.Size = new System.Drawing.Size(218, 424);
            this.CamControlBox.TabIndex = 1;
            this.CamControlBox.TabStop = false;
            this.CamControlBox.Text = "Camera Controls";
            // 
            // CamUpBtn
            // 
            this.CamUpBtn.Location = new System.Drawing.Point(76, 19);
            this.CamUpBtn.Name = "CamUpBtn";
            this.CamUpBtn.Size = new System.Drawing.Size(64, 64);
            this.CamUpBtn.TabIndex = 0;
            this.CamUpBtn.Text = "Up";
            this.CamUpBtn.UseVisualStyleBackColor = true;
            this.CamUpBtn.Click += new System.EventHandler(this.CamUpBtn_Click);
            // 
            // CamDownBtn
            // 
            this.CamDownBtn.Location = new System.Drawing.Point(76, 159);
            this.CamDownBtn.Name = "CamDownBtn";
            this.CamDownBtn.Size = new System.Drawing.Size(64, 64);
            this.CamDownBtn.TabIndex = 0;
            this.CamDownBtn.Text = "Down";
            this.CamDownBtn.UseVisualStyleBackColor = true;
            this.CamDownBtn.Click += new System.EventHandler(this.CamDownBtn_Click);
            // 
            // ToggleModeButton
            // 
            this.ToggleModeButton.Location = new System.Drawing.Point(6, 354);
            this.ToggleModeButton.Name = "ToggleModeButton";
            this.ToggleModeButton.Size = new System.Drawing.Size(204, 64);
            this.ToggleModeButton.TabIndex = 0;
            this.ToggleModeButton.Text = "Pan/Rotate Toggle";
            this.ToggleModeButton.UseVisualStyleBackColor = true;
            this.ToggleModeButton.Click += new System.EventHandler(this.ToggleModeButton_Click);
            // 
            // CamRightBtn
            // 
            this.CamRightBtn.Location = new System.Drawing.Point(146, 89);
            this.CamRightBtn.Name = "CamRightBtn";
            this.CamRightBtn.Size = new System.Drawing.Size(64, 64);
            this.CamRightBtn.TabIndex = 0;
            this.CamRightBtn.Text = "Right";
            this.CamRightBtn.UseVisualStyleBackColor = true;
            this.CamRightBtn.Click += new System.EventHandler(this.CamRightBtn_Click);
            // 
            // CamResetBtn
            // 
            this.CamResetBtn.Location = new System.Drawing.Point(76, 89);
            this.CamResetBtn.Name = "CamResetBtn";
            this.CamResetBtn.Size = new System.Drawing.Size(64, 64);
            this.CamResetBtn.TabIndex = 0;
            this.CamResetBtn.Text = "Reset";
            this.CamResetBtn.UseVisualStyleBackColor = true;
            this.CamResetBtn.Click += new System.EventHandler(this.CamResetBtn_Click);
            // 
            // CamLeftBtn
            // 
            this.CamLeftBtn.Location = new System.Drawing.Point(6, 89);
            this.CamLeftBtn.Name = "CamLeftBtn";
            this.CamLeftBtn.Size = new System.Drawing.Size(64, 64);
            this.CamLeftBtn.TabIndex = 0;
            this.CamLeftBtn.Text = "Left";
            this.CamLeftBtn.UseVisualStyleBackColor = true;
            this.CamLeftBtn.Click += new System.EventHandler(this.CamLeftBtn_Click);
            // 
            // FuncSelectBox
            // 
            this.FuncSelectBox.FormattingEnabled = true;
            this.FuncSelectBox.Items.AddRange(new object[] {
            "f(x) = x",
            "f(x) = x^2",
            "f(x) = x ^ 3",
            "f(x) = sin(x)",
            "f(x) = cos(x)",
            "f(x) = 0"});
            this.FuncSelectBox.Location = new System.Drawing.Point(81, 471);
            this.FuncSelectBox.Name = "FuncSelectBox";
            this.FuncSelectBox.Size = new System.Drawing.Size(173, 21);
            this.FuncSelectBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 446);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select a Function";
            // 
            // txtLimB
            // 
            this.txtLimB.Location = new System.Drawing.Point(51, 455);
            this.txtLimB.Name = "txtLimB";
            this.txtLimB.Size = new System.Drawing.Size(21, 20);
            this.txtLimB.TabIndex = 4;
            this.txtLimB.Text = "2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 474);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Limits";
            // 
            // txtLimA
            // 
            this.txtLimA.Location = new System.Drawing.Point(51, 481);
            this.txtLimA.Name = "txtLimA";
            this.txtLimA.Size = new System.Drawing.Size(21, 20);
            this.txtLimA.TabIndex = 4;
            this.txtLimA.Text = "-2";
            // 
            // txtSubdiv
            // 
            this.txtSubdiv.Location = new System.Drawing.Point(271, 471);
            this.txtSubdiv.Name = "txtSubdiv";
            this.txtSubdiv.Size = new System.Drawing.Size(21, 20);
            this.txtSubdiv.TabIndex = 4;
            this.txtSubdiv.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(298, 474);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Subdivisions";
            // 
            // HelpBtn
            // 
            this.HelpBtn.Enabled = false;
            this.HelpBtn.Location = new System.Drawing.Point(716, 446);
            this.HelpBtn.Name = "HelpBtn";
            this.HelpBtn.Size = new System.Drawing.Size(75, 54);
            this.HelpBtn.TabIndex = 7;
            this.HelpBtn.Text = "Help!";
            this.HelpBtn.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(443, 463);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 8;
            this.btnApply.Text = "Apply Changes";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnShowOptions
            // 
            this.btnShowOptions.Enabled = false;
            this.btnShowOptions.Location = new System.Drawing.Point(635, 447);
            this.btnShowOptions.Name = "btnShowOptions";
            this.btnShowOptions.Size = new System.Drawing.Size(75, 54);
            this.btnShowOptions.TabIndex = 7;
            this.btnShowOptions.Text = "Options";
            this.btnShowOptions.UseVisualStyleBackColor = true;
            this.btnShowOptions.Click += new System.EventHandler(this.btnShowOptions_Click);
            // 
            // CamBackBtn
            // 
            this.CamBackBtn.Location = new System.Drawing.Point(145, 229);
            this.CamBackBtn.Name = "CamBackBtn";
            this.CamBackBtn.Size = new System.Drawing.Size(64, 64);
            this.CamBackBtn.TabIndex = 0;
            this.CamBackBtn.Text = "Away";
            this.CamBackBtn.UseVisualStyleBackColor = true;
            this.CamBackBtn.Click += new System.EventHandler(this.CamBackBtn_Click);
            // 
            // CamFwdBtn
            // 
            this.CamFwdBtn.Location = new System.Drawing.Point(6, 229);
            this.CamFwdBtn.Name = "CamFwdBtn";
            this.CamFwdBtn.Size = new System.Drawing.Size(64, 64);
            this.CamFwdBtn.TabIndex = 0;
            this.CamFwdBtn.Text = "Towards";
            this.CamFwdBtn.UseVisualStyleBackColor = true;
            this.CamFwdBtn.Click += new System.EventHandler(this.CamFwdBtn_Click);
            // 
            // PanRotLabel
            // 
            this.PanRotLabel.AutoSize = true;
            this.PanRotLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanRotLabel.Location = new System.Drawing.Point(104, 331);
            this.PanRotLabel.Name = "PanRotLabel";
            this.PanRotLabel.Size = new System.Drawing.Size(67, 20);
            this.PanRotLabel.TabIndex = 1;
            this.PanRotLabel.Text = "Panning";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 337);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Camera Mode:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 512);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnShowOptions);
            this.Controls.Add(this.HelpBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSubdiv);
            this.Controls.Add(this.txtLimA);
            this.Controls.Add(this.txtLimB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FuncSelectBox);
            this.Controls.Add(this.CamControlBox);
            this.Controls.Add(this.Viewport);
            this.Name = "MainForm";
            this.Text = "Integrate";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.CamControlBox.ResumeLayout(false);
            this.CamControlBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AAGLControlLib.AAGLControl Viewport;
        private System.Windows.Forms.GroupBox CamControlBox;
        private System.Windows.Forms.Button CamLeftBtn;
        private System.Windows.Forms.Button CamUpBtn;
        private System.Windows.Forms.Button CamDownBtn;
        private System.Windows.Forms.Button ToggleModeButton;
        private System.Windows.Forms.Button CamRightBtn;
        private System.Windows.Forms.Button CamResetBtn;
        private System.Windows.Forms.ComboBox FuncSelectBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLimB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLimA;
        private System.Windows.Forms.TextBox txtSubdiv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button HelpBtn;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnShowOptions;
        private System.Windows.Forms.Button CamFwdBtn;
        private System.Windows.Forms.Button CamBackBtn;
        private System.Windows.Forms.Label PanRotLabel;
        private System.Windows.Forms.Label label4;

    }
}

