namespace CubWinForm
{
    partial class CubForm
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
            this.glControl1 = new OpenTK.GLControl();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.sliderX = new System.Windows.Forms.TrackBar();
            this.sliderY = new System.Windows.Forms.TrackBar();
            this.sliderZ = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.sliderRed = new System.Windows.Forms.TrackBar();
            this.sliderGreen = new System.Windows.Forms.TrackBar();
            this.sliderBlue = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.sliderX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(12, 21);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(502, 355);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(543, 32);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(79, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Show Axes";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(516, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ox";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.ForestGreen;
            this.label2.Location = new System.Drawing.Point(516, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Oy";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(517, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Oz";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Bisque;
            this.button1.Location = new System.Drawing.Point(542, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Draw Cube";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sliderX
            // 
            this.sliderX.Location = new System.Drawing.Point(542, 114);
            this.sliderX.Maximum = 100;
            this.sliderX.Name = "sliderX";
            this.sliderX.Size = new System.Drawing.Size(246, 45);
            this.sliderX.TabIndex = 6;
            // 
            // sliderY
            // 
            this.sliderY.Location = new System.Drawing.Point(542, 166);
            this.sliderY.Maximum = 100;
            this.sliderY.Name = "sliderY";
            this.sliderY.Size = new System.Drawing.Size(246, 45);
            this.sliderY.TabIndex = 7;
            // 
            // sliderZ
            // 
            this.sliderZ.Location = new System.Drawing.Point(543, 226);
            this.sliderZ.Maximum = 100;
            this.sliderZ.Name = "sliderZ";
            this.sliderZ.Size = new System.Drawing.Size(245, 45);
            this.sliderZ.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label4.Location = new System.Drawing.Point(609, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cursor Culoare(RGB)";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // sliderRed
            // 
            this.sliderRed.Location = new System.Drawing.Point(563, 298);
            this.sliderRed.Maximum = 100;
            this.sliderRed.Name = "sliderRed";
            this.sliderRed.Size = new System.Drawing.Size(225, 45);
            this.sliderRed.TabIndex = 11;
            this.sliderRed.Value = 100;
            // 
            // sliderGreen
            // 
            this.sliderGreen.Location = new System.Drawing.Point(563, 349);
            this.sliderGreen.Maximum = 100;
            this.sliderGreen.Name = "sliderGreen";
            this.sliderGreen.Size = new System.Drawing.Size(225, 45);
            this.sliderGreen.TabIndex = 12;
            // 
            // sliderBlue
            // 
            this.sliderBlue.Location = new System.Drawing.Point(568, 400);
            this.sliderBlue.Maximum = 100;
            this.sliderBlue.Name = "sliderBlue";
            this.sliderBlue.Size = new System.Drawing.Size(220, 45);
            this.sliderBlue.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(527, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Red";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.ForestGreen;
            this.label6.Location = new System.Drawing.Point(521, 349);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Green";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.DodgerBlue;
            this.label7.Location = new System.Drawing.Point(526, 400);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Blue";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(651, 32);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(76, 17);
            this.checkBox2.TabIndex = 17;
            this.checkBox2.Text = "Hide Cube";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // CubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 574);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sliderBlue);
            this.Controls.Add(this.sliderGreen);
            this.Controls.Add(this.sliderRed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sliderZ);
            this.Controls.Add(this.sliderY);
            this.Controls.Add(this.sliderX);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.glControl1);
            this.Name = "CubForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.CubForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sliderX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderBlue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar sliderX;
        private System.Windows.Forms.TrackBar sliderY;
        private System.Windows.Forms.TrackBar sliderZ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar sliderRed;
        private System.Windows.Forms.TrackBar sliderGreen;
        private System.Windows.Forms.TrackBar sliderBlue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}

