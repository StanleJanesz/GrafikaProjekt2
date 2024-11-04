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
            hScrollBar1 = new HScrollBar();
            hScrollBar2 = new HScrollBar();
            vScrollBar1 = new VScrollBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(683, 416);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // hScrollBar1
            // 
            hScrollBar1.Location = new Point(12, 430);
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(340, 17);
            hScrollBar1.TabIndex = 1;
            // 
            // hScrollBar2
            // 
            hScrollBar2.Location = new Point(352, 430);
            hScrollBar2.Name = "hScrollBar2";
            hScrollBar2.Size = new Size(343, 17);
            hScrollBar2.TabIndex = 2;
            // 
            // vScrollBar1
            // 
            vScrollBar1.Location = new Point(698, 12);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(17, 416);
            vScrollBar1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(vScrollBar1);
            Controls.Add(hScrollBar2);
            Controls.Add(hScrollBar1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private HScrollBar hScrollBar1;
        private HScrollBar hScrollBar2;
        private VScrollBar vScrollBar1;
    }
}
