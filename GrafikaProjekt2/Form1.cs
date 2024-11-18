using GrafikaProjekt2.Mesh;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GrafikaProjekt2
{
    public partial class Form1 : Form
    {
        Mesh.Mesh mesh;
        Task task;
        System.Windows.Forms.Timer timer;
        public Form1()
        {
            InitializeComponent();
            mesh = new Mesh.Mesh();
            trackBar3.Value = 60;
            trackBar4.Value = (int)(mesh.kd * 100);
            trackBar5.Value = (int)(mesh.ks*100);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 20;
            timer.Tick += new EventHandler(MoveLight);
            timer.Start();

        }

        void MoveLight(object sender, EventArgs e)
        {
            if (trackBar8.Value < trackBar8.Maximum) trackBar8.Value++;
            else trackBar8.Value = trackBar8.Minimum;
            trackBar8_Scroll(sender, e);
            if (trackBar7.Value + 4 < trackBar7.Maximum) trackBar7.Value += 4;
            else trackBar7.Value = trackBar7.Minimum;
            trackBar8_Scroll(sender, e);
            pictureBox1.Invalidate();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.ScaleTransform(1, -1);
            g.TranslateTransform(pictureBox1.Width / 2, -pictureBox1.Height / 2);
            Bitmap bitmap = new Bitmap(12, 21);
            mesh.Draw(g, bitmap);
        }


        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            var a = e.ScrollOrientation;

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            mesh.SetAlfa(trackBar1.Value);
            pictureBox1.Invalidate();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            mesh.SetBeta(trackBar2.Value);
            pictureBox1.Invalidate();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            mesh.SetPointNumber(trackBar3.Value);
            pictureBox1.Invalidate();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            mesh.SetKd(trackBar4.Value / 99.0F);
            pictureBox1.Invalidate();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            mesh.SetKs(trackBar5.Value / 99.0F);
            pictureBox1.Invalidate();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            mesh.SetM(trackBar6.Value);
            pictureBox1.Invalidate();
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            int alfa = trackBar7.Value;
            var m = new Matrix4x4(
                        (float)Math.Cos((Math.PI / 180) * alfa), -(float)Math.Sin((Math.PI / 180) * alfa), 0, 0,
                        (float)Math.Sin((Math.PI / 180) * alfa), (float)Math.Cos((Math.PI / 180) * alfa), 0, 0,
                        0, 0, 1, 0,
                       0, 0, 0, 1
                      );
            Vector4 vector4 = new Vector4(1, 1, 1, 0);
            vector4 = System.Numerics.Vector4.Transform(mesh.z, m);

            mesh.rotZ = new Vector3(vector4.X, vector4.Y, vector4.Z);

            pictureBox1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            MyDialog.Color = Color.FromArgb((int)(255 * mesh.color.X), (int)(255 * mesh.color.Y), (int)(255 * mesh.color.Z));
            mesh.ColorImage = null;  
            if (MyDialog.ShowDialog() == DialogResult.OK)
                mesh.color = new System.Numerics.Vector3(MyDialog.Color.R / 255f, MyDialog.Color.G / 255f, MyDialog.Color.B / 255f);
            pictureBox1.Invalidate();

        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            mesh.z.X = trackBar8.Value;
            mesh.z.Y = trackBar8.Value;
            trackBar7_Scroll(sender, e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                mesh.VisMesh = true;
            }
            else
            {
                mesh.VisMesh = false;
            }
            pictureBox1.Invalidate();
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            mesh.z.Z = trackBar9.Value;
            mesh.rotZ.Z = trackBar9.Value;
            pictureBox1.Invalidate();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox2.Checked)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            MyDialog.Color = Color.FromArgb((int)(255 * mesh.lightColor.X), (int)(255 * mesh.lightColor.Y), (int)(255 * mesh.lightColor.Z));
            if (MyDialog.ShowDialog() == DialogResult.OK)
                mesh.lightColor = new System.Numerics.Vector3(MyDialog.Color.R / 255f, MyDialog.Color.G / 255f, MyDialog.Color.B / 255f);
            mesh.lightColor = Vector3.Normalize(mesh.lightColor);
            pictureBox1.Invalidate();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox3.Checked)
            {
                mesh.isTexture = false;
            }
            else
            {
                mesh.isTexture = true;
                radioButton3.Checked = true;
            }
            pictureBox1.Invalidate();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox5.Checked)
            {
                mesh.isControl = false;
            }
            else
            {
                mesh.isControl = true;

            }
            pictureBox1.Invalidate();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox4.Checked)
            {
                mesh.isColor = false;
            }
            else
            {
                mesh.isColor = true;

            }
            pictureBox1.Invalidate();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                mesh.image1 = mesh.image2;
                pictureBox1.Invalidate();
            }
        }


        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                mesh.image1 = mesh.image4;
                pictureBox1.Invalidate();
            }
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                mesh.image1 = mesh.image3;
                pictureBox1.Invalidate();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {


                var fileContent = string.Empty;
                var filePath = string.Empty;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        mesh.image5 = mesh.ScaleImage(new Bitmap(openFileDialog.FileName, true), 400, 400);
                        mesh.image1 = mesh.image5;
                    }
                    else
                    {
                        radioButton1.Checked = true;
                    }
                }
            }
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    mesh.ColorImage = mesh.ScaleImage(new Bitmap(openFileDialog.FileName, true),400,400);
                }
            }
        }
    }
}
