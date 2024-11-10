using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace GrafikaProjekt2
{
    public partial class Form1 : Form
    {
        Mesh.Mesh mesh;
        public Form1()
        {
            InitializeComponent();
            mesh = new Mesh.Mesh();
            trackBar3.Value = 80;
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

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
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = Color.FromArgb((int)(255 * mesh.color.X), (int)(255 * mesh.color.Y), (int)(255 * mesh.color.Z));

            // Update the text box color if the user clicks OK 
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
    }
}
