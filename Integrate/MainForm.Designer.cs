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
            this.CamControlBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PanRotLabel = new System.Windows.Forms.Label();
            this.CamUpBtn = new System.Windows.Forms.Button();
            this.CamDownBtn = new System.Windows.Forms.Button();
            this.ToggleModeButton = new System.Windows.Forms.Button();
            this.CamRightBtn = new System.Windows.Forms.Button();
            this.CamResetBtn = new System.Windows.Forms.Button();
            this.CamFwdBtn = new System.Windows.Forms.Button();
            this.CamBackBtn = new System.Windows.Forms.Button();
            this.CamLeftBtn = new System.Windows.Forms.Button();
            this.txtUpperLimit = new System.Windows.Forms.TextBox();
            this.txtLowerLimit = new System.Windows.Forms.TextBox();
            this.txtSubdiv = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.FuncEntryBox = new System.Windows.Forms.TextBox();
            //this.Viewport = new AAGLControlLib.AAGLControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CamControlBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.CamControlBox.Location = new System.Drawing.Point(808, 12);
            this.CamControlBox.Name = "CamControlBox";
            this.CamControlBox.Size = new System.Drawing.Size(218, 424);
            this.CamControlBox.TabIndex = 1;
            this.CamControlBox.TabStop = false;
            this.CamControlBox.Text = "Camera Controls";
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
            // txtUpperLimit
            // 
            this.txtUpperLimit.Location = new System.Drawing.Point(44, 105);
            this.txtUpperLimit.Name = "txtUpperLimit";
            this.txtUpperLimit.Size = new System.Drawing.Size(21, 20);
            this.txtUpperLimit.TabIndex = 4;
            this.txtUpperLimit.Text = "2";
            this.txtUpperLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUpperLimit.Enter += new System.EventHandler(this.LimitBoxes_Enter);
            // 
            // txtLowerLimit
            // 
            this.txtLowerLimit.Location = new System.Drawing.Point(44, 131);
            this.txtLowerLimit.Name = "txtLowerLimit";
            this.txtLowerLimit.Size = new System.Drawing.Size(21, 20);
            this.txtLowerLimit.TabIndex = 5;
            this.txtLowerLimit.Text = "-2";
            this.txtLowerLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSubdiv
            // 
            this.txtSubdiv.Location = new System.Drawing.Point(6, 377);
            this.txtSubdiv.Name = "txtSubdiv";
            this.txtSubdiv.Size = new System.Drawing.Size(21, 20);
            this.txtSubdiv.TabIndex = 7;
            this.txtSubdiv.Text = "10";
            this.txtSubdiv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(152, 349);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(64, 64);
            this.btnApply.TabIndex = 8;
            this.btnApply.Text = "Apply Changes";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // FuncEntryBox
            // 
            this.FuncEntryBox.Location = new System.Drawing.Point(36, 252);
            this.FuncEntryBox.Name = "FuncEntryBox";
            this.FuncEntryBox.Size = new System.Drawing.Size(161, 20);
            this.FuncEntryBox.TabIndex = 6;
            this.FuncEntryBox.Text = "x";
            // 
            // Viewport
            // 
//            this.Viewport.BackColor = System.Drawing.Color.Black;
//            this.Viewport.Location = new System.Drawing.Point(239, 12);
//            this.Viewport.Name = "Viewport";
//            this.Viewport.Size = new System.Drawing.Size(563, 424);
//            this.Viewport.TabIndex = 0;
//            this.Viewport.VSync = true;
//            this.Viewport.Load += new System.EventHandler(this.Viewport_Load);
//            this.Viewport.Paint += new System.Windows.Forms.PaintEventHandler(this.Viewport_Paint);
//            this.Viewport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Viewport_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSubdiv);
            this.groupBox1.Controls.Add(this.FuncEntryBox);
            this.groupBox1.Controls.Add(this.txtLowerLimit);
            this.groupBox1.Controls.Add(this.txtUpperLimit);
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 424);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera Controls";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 453);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CamControlBox);
            //this.Controls.Add(this.Viewport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Integrate";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.CamControlBox.ResumeLayout(false);
            this.CamControlBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        //private AAGLControlLib.AAGLControl Viewport;
        private System.Windows.Forms.GroupBox CamControlBox;
        private System.Windows.Forms.Button CamLeftBtn;
        private System.Windows.Forms.Button CamUpBtn;
        private System.Windows.Forms.Button CamDownBtn;
        private System.Windows.Forms.Button ToggleModeButton;
        private System.Windows.Forms.Button CamRightBtn;
        private System.Windows.Forms.Button CamResetBtn;
        private System.Windows.Forms.TextBox txtUpperLimit;
        private System.Windows.Forms.TextBox txtLowerLimit;
        private System.Windows.Forms.TextBox txtSubdiv;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button CamFwdBtn;
        private System.Windows.Forms.Button CamBackBtn;
        private System.Windows.Forms.Label PanRotLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FuncEntryBox;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}

