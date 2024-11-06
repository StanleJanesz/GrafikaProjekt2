namespace GrafikaProjekt2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            label1 = new Label();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            trackBar3 = new TrackBar();
            label2 = new Label();
            label3 = new Label();
            trackBar4 = new TrackBar();
            trackBar5 = new TrackBar();
            trackBar6 = new TrackBar();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            trackBar7 = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar7).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(502, 416);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(538, 9);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 9;
            label1.Text = "Alfa";
            label1.Click += label1_Click;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(538, 27);
            trackBar1.Maximum = 45;
            trackBar1.Minimum = -45;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(250, 45);
            trackBar1.TabIndex = 10;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(538, 78);
            trackBar2.Minimum = -10;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(250, 45);
            trackBar2.TabIndex = 11;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(538, 140);
            trackBar3.Maximum = 100;
            trackBar3.Minimum = 2;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(250, 45);
            trackBar3.TabIndex = 12;
            trackBar3.Value = 2;
            trackBar3.Scroll += trackBar3_Scroll;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(538, 60);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 13;
            label2.Text = "Beta";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(538, 122);
            label3.Name = "label3";
            label3.Size = new Size(103, 15);
            label3.TabIndex = 14;
            label3.Text = "triangle ammount";
            // 
            // trackBar4
            // 
            trackBar4.Location = new Point(538, 191);
            trackBar4.Maximum = 100;
            trackBar4.Minimum = 1;
            trackBar4.Name = "trackBar4";
            trackBar4.Size = new Size(250, 45);
            trackBar4.TabIndex = 15;
            trackBar4.Value = 1;
            trackBar4.Scroll += trackBar4_Scroll;
            // 
            // trackBar5
            // 
            trackBar5.Location = new Point(538, 231);
            trackBar5.Maximum = 100;
            trackBar5.Minimum = 1;
            trackBar5.Name = "trackBar5";
            trackBar5.Size = new Size(250, 45);
            trackBar5.TabIndex = 16;
            trackBar5.Value = 1;
            trackBar5.Scroll += trackBar5_Scroll;
            // 
            // trackBar6
            // 
            trackBar6.Location = new Point(538, 282);
            trackBar6.Maximum = 100;
            trackBar6.Minimum = 1;
            trackBar6.Name = "trackBar6";
            trackBar6.Size = new Size(250, 45);
            trackBar6.TabIndex = 17;
            trackBar6.Value = 1;
            trackBar6.Scroll += trackBar6_Scroll;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(538, 173);
            label4.Name = "label4";
            label4.Size = new Size(20, 15);
            label4.TabIndex = 18;
            label4.Text = "kd";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(538, 221);
            label5.Name = "label5";
            label5.Size = new Size(18, 15);
            label5.TabIndex = 19;
            label5.Text = "ks";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(544, 264);
            label6.Name = "label6";
            label6.Size = new Size(18, 15);
            label6.TabIndex = 20;
            label6.Text = "m";
            // 
            // trackBar7
            // 
            trackBar7.Location = new Point(544, 335);
            trackBar7.Maximum = 10000;
            trackBar7.Name = "trackBar7";
            trackBar7.Size = new Size(244, 45);
            trackBar7.TabIndex = 21;
            trackBar7.Scroll += trackBar7_Scroll;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(trackBar7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(trackBar6);
            Controls.Add(trackBar5);
            Controls.Add(trackBar4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(trackBar3);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar5).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar6).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private TrackBar trackBar3;
        private Label label2;
        private Label label3;
        private TrackBar trackBar4;
        private TrackBar trackBar5;
        private TrackBar trackBar6;
        private Label label4;
        private Label label5;
        private Label label6;
        private TrackBar trackBar7;
    }
}
