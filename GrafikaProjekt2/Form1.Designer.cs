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
            colorDialog1 = new ColorDialog();
            button1 = new Button();
            trackBar8 = new TrackBar();
            checkBox1 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar8).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(14, 16);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(574, 555);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(615, 12);
            label1.Name = "label1";
            label1.Size = new Size(36, 20);
            label1.TabIndex = 9;
            label1.Text = "Alfa";
            label1.Click += label1_Click;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(615, 36);
            trackBar1.Margin = new Padding(3, 4, 3, 4);
            trackBar1.Maximum = 45;
            trackBar1.Minimum = -45;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(286, 56);
            trackBar1.TabIndex = 10;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(615, 104);
            trackBar2.Margin = new Padding(3, 4, 3, 4);
            trackBar2.Minimum = -10;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(286, 56);
            trackBar2.TabIndex = 11;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(615, 187);
            trackBar3.Margin = new Padding(3, 4, 3, 4);
            trackBar3.Maximum = 100;
            trackBar3.Minimum = 2;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(286, 56);
            trackBar3.TabIndex = 12;
            trackBar3.Value = 2;
            trackBar3.Scroll += trackBar3_Scroll;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(615, 80);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 13;
            label2.Text = "Beta";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(615, 163);
            label3.Name = "label3";
            label3.Size = new Size(128, 20);
            label3.TabIndex = 14;
            label3.Text = "triangle ammount";
            // 
            // trackBar4
            // 
            trackBar4.Location = new Point(615, 255);
            trackBar4.Margin = new Padding(3, 4, 3, 4);
            trackBar4.Maximum = 100;
            trackBar4.Minimum = 1;
            trackBar4.Name = "trackBar4";
            trackBar4.Size = new Size(286, 56);
            trackBar4.TabIndex = 15;
            trackBar4.Value = 1;
            trackBar4.Scroll += trackBar4_Scroll;
            // 
            // trackBar5
            // 
            trackBar5.Location = new Point(615, 308);
            trackBar5.Margin = new Padding(3, 4, 3, 4);
            trackBar5.Maximum = 100;
            trackBar5.Minimum = 1;
            trackBar5.Name = "trackBar5";
            trackBar5.Size = new Size(286, 56);
            trackBar5.TabIndex = 16;
            trackBar5.Value = 1;
            trackBar5.Scroll += trackBar5_Scroll;
            // 
            // trackBar6
            // 
            trackBar6.Location = new Point(615, 376);
            trackBar6.Margin = new Padding(3, 4, 3, 4);
            trackBar6.Maximum = 45;
            trackBar6.Name = "trackBar6";
            trackBar6.Size = new Size(286, 56);
            trackBar6.TabIndex = 17;
            trackBar6.Value = 1;
            trackBar6.Scroll += trackBar6_Scroll;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(615, 231);
            label4.Name = "label4";
            label4.Size = new Size(25, 20);
            label4.TabIndex = 18;
            label4.Text = "kd";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(615, 295);
            label5.Name = "label5";
            label5.Size = new Size(22, 20);
            label5.TabIndex = 19;
            label5.Text = "ks";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(622, 352);
            label6.Name = "label6";
            label6.Size = new Size(22, 20);
            label6.TabIndex = 20;
            label6.Text = "m";
            // 
            // trackBar7
            // 
            trackBar7.Location = new Point(622, 447);
            trackBar7.Margin = new Padding(3, 4, 3, 4);
            trackBar7.Maximum = 180;
            trackBar7.Minimum = -180;
            trackBar7.Name = "trackBar7";
            trackBar7.Size = new Size(279, 56);
            trackBar7.TabIndex = 21;
            trackBar7.Scroll += trackBar7_Scroll;
            // 
            // button1
            // 
            button1.Location = new Point(955, 36);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 22;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // trackBar8
            // 
            trackBar8.Location = new Point(622, 513);
            trackBar8.Maximum = 200;
            trackBar8.Name = "trackBar8";
            trackBar8.Size = new Size(279, 56);
            trackBar8.TabIndex = 23;
            trackBar8.Value = 100;
            trackBar8.Scroll += trackBar8_Scroll;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(955, 80);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(101, 24);
            checkBox1.TabIndex = 24;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1167, 600);
            Controls.Add(checkBox1);
            Controls.Add(trackBar8);
            Controls.Add(button1);
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
            Margin = new Padding(3, 4, 3, 4);
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
            ((System.ComponentModel.ISupportInitialize)trackBar8).EndInit();
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
        private ColorDialog colorDialog1;
        private Button button1;
        private TrackBar trackBar8;
        private CheckBox checkBox1;
    }
}
