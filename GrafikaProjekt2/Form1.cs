using System.Security.Cryptography.X509Certificates;

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
            mesh.SetKd( trackBar4.Value / 99.0F);
            pictureBox1.Invalidate();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            mesh.SetKs( trackBar5.Value / 99.0F);
            pictureBox1.Invalidate();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            mesh.SetM(trackBar6.Value);
            pictureBox1.Invalidate();
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            mesh.z.Z = trackBar6.Value;
            pictureBox1.Invalidate();
        }
    }
}
