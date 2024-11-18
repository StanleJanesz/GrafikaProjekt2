using System.Globalization;
using System.Numerics;
namespace GrafikaProjekt2.Mesh
{
    internal class Mesh
    {
        public Vector3 color;
        public Vector3 lightColor;
        List<Triangle> triangles;
        List<Vector3> controlPoints;
        List<Vector3> rotatedPoints;
        int pointsNumber { get;  set; }
        Matrix4x4 rotationMatrix;
        public int alfa, beta;
        const int CONTROLPOINTNUMBER = 4;
        public int m;
        public float ks;
        public float kd;
        public bool VisMesh;
        public bool isTexture;
        public bool isColor;
        public bool isControl;
        public Vector3 z;
        public Vector3 rotZ;
        public Bitmap image1;
        public Bitmap image2;
        public Bitmap image3;
        public Bitmap image4;
        public Bitmap image5;
        public Bitmap ColorImage;
        public int counter = 0;
        public int counter2 = 0;
        void LoadMesh()
        {
            using (FileStream fs = File.Open("../../../Mesh/Mesh.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                    {


                        string content = reader.ReadLine();
                        Console.WriteLine(content);
                        var info = content.Split(" ");
                        float a = float.Parse(info[0], CultureInfo.InvariantCulture.NumberFormat);
                        float b = float.Parse(info[1], CultureInfo.InvariantCulture.NumberFormat);
                        float c = float.Parse(info[2], CultureInfo.InvariantCulture.NumberFormat);
                        controlPoints.Add(new Vector3(a, b, c));
                    }
                }
            }

        }
        public void SetPointNumber(int pointNumber)
        {
            this.pointsNumber = pointNumber;
        }
        public void SetAlfa(int alfa)
        {
            this.alfa = alfa;
            rotatedPoints = new List<Vector3>();
            CalculateRotationMatrix();

            foreach (var p in controlPoints)
            {
                Vector4 vector4 = System.Numerics.Vector4.Transform(p, rotationMatrix);

                rotatedPoints.Add(new Vector3(vector4.X, vector4.Y, vector4.Z));
            }
        }
        public void SetM(int m)
        {
            this.m = m;
        }
        public void SetKs(float k)
        {
            this.ks = k;
        }
        public void SetKd(float kd)
        {
            this.kd = kd;
        }
        public void SetBeta(int beta)
        {
            this.beta = beta;
            rotatedPoints.Clear();
            CalculateRotationMatrix();
            foreach (var p in controlPoints)
            {
                Vector4 vector4 = System.Numerics.Vector4.Transform(p, rotationMatrix);

                rotatedPoints.Add(new Vector3(vector4.X, vector4.Y, vector4.Z));
            }
        }
        public void CalculateRotationMatrix()
        {
            var m = new Matrix4x4(
                        (float)Math.Cos((Math.PI / 180) * alfa), -(float)Math.Sin((Math.PI / 180) * alfa), 0, 0,
                        (float)Math.Sin((Math.PI / 180) * alfa), (float)Math.Cos((Math.PI / 180) * alfa), 0, 0,
                        0, 0, 1, 0,
                       0, 0, 0, 1
                      );
            var m1 = new Matrix4x4(
                                   1, 0, 0, 0,
                                   0, (float)Math.Cos((Math.PI / 180) * beta), -(float)Math.Sin((Math.PI / 180) * beta), 0,
                                   0, (float)Math.Sin((Math.PI / 180) * beta), (float)Math.Cos((Math.PI / 180) * beta), 0,
                                   0, 0, 0, 1
                                  );
            rotationMatrix = Matrix4x4.Multiply(m, m1);
        }
        void CreateTriangles()
        {
            counter = 0;
            triangles.Clear();
            float step = 1 / (float)pointsNumber;
            Vector3[,] tab = new Vector3[pointsNumber + 1, pointsNumber + 1];
            Vector3[,] tabPu = new Vector3[pointsNumber + 1, pointsNumber + 1];
            Vector3[,] tabPv = new Vector3[pointsNumber + 1, pointsNumber + 1];
            float bi, bj;
            Vector3 v;
            for (int i = 0; i < pointsNumber + 1; i++)
            {
                for (int j = 0; j < pointsNumber + 1; j++)
                {
                    v = new Vector3(0, 0, 0);
                    for (int k = 0; k < CONTROLPOINTNUMBER; k++)
                    {
                        bi = EqCoeff(step * i, k, CONTROLPOINTNUMBER);
                        for (int w = 0; w < CONTROLPOINTNUMBER; w++)
                        {
                            bj = EqCoeff(step * j, w, CONTROLPOINTNUMBER);
                            v += controlPoints[k * 4 + w] * bj * bi;
                        }
                    }
                    tab[i, j] = v;
                    v = new Vector3(0, 0, 0);
                    for (int k = 0; k < CONTROLPOINTNUMBER - 1; k++)
                    {
                        bi = EqCoeff(step * i, k, CONTROLPOINTNUMBER-1);
                        for (int w = 0; w < CONTROLPOINTNUMBER; w++)
                        {
                            bj = EqCoeff(step * j, w, CONTROLPOINTNUMBER);
                            v += (controlPoints[(k + 1) * 4 + w] - controlPoints[k * 4 + w]) * bj * bi;
                        }
                    }
                    tabPu[i, j] = CONTROLPOINTNUMBER * v;
                    v = new Vector3(0, 0, 0);
                    for (int k = 0; k < CONTROLPOINTNUMBER; k++)
                    {
                        bi = EqCoeff(step * i, k, CONTROLPOINTNUMBER);
                        for (int w = 0; w < CONTROLPOINTNUMBER - 1; w++)
                        {
                            bj = EqCoeff(step * j, w, CONTROLPOINTNUMBER - 1);
                            v += (controlPoints[k * 4 + w + 1] - controlPoints[k * 4 + w]) * bj * bi;
                        }
                    }
                    tabPv[i, j] = CONTROLPOINTNUMBER * v;
                    if (tabPu[i, j].Equals(Vector3.Zero))
                    {
                        return;
                    }


                }
            }

            for (int i = 0; i < pointsNumber; i++)
            {
                for (int j = 0; j < pointsNumber; j++)
                {
                    Vertex v1 = new Vertex(tab[i, j], i, j, tabPu[i, j], tabPv[i, j]);
                    Vertex v2 = new Vertex(tab[i, j + 1], i, j + 1, tabPu[i, j + 1], tabPv[i, j + 1]);
                    Vertex v3 = new Vertex(tab[i + 1, j], i + 1, j, tabPu[i + 1, j], tabPv[i + 1, j]);
                    Vertex v4 = new Vertex(tab[i + 1, j + 1], i + 1, j + 1, tabPu[i + 1, j + 1], tabPv[i + 1, j + 1]);
                    triangles.Add(new Triangle(v1, v2, v3));
                    triangles.Add(new Triangle(v4, v2, v3));
                }
            }
            foreach (var t in triangles)
            {
                t.Rotate(rotationMatrix);
            }
        }
        float EqCoeff(float u, int k, int n)
        {
            return (float)binomialCoeff(k, n) * (float)Math.Pow(u, k) * (float)Math.Pow((double)(1 - u), (double)(n - 1 - k));
        }
        int binomialCoeff(int k, int n)
        {
            if ((k < 0) || (k > n - 1)) return 0;
            k = (k > n - 1 / 2) ? n - 1 - k : k;
            double a = 1;
            for (int i = 1; i <= k; i++) a = (a * (n - 1 - k + i)) / i;
            return (int)(a + 0.5);
        }
        public void Draw(Graphics g, Bitmap b)
        {
            CreateTriangles();
            if(isColor)
            foreach (var p in triangles)
                p.Fill(g, this); 
            if (VisMesh)
                foreach (var p in triangles)
                    p.Draw(g); 
            if (isControl)
            {
                foreach (var p in rotatedPoints)
                    g.FillRectangle((Brush)Brushes.Red, p.X - 4, p.Y - 4, 8, 8);
                for (int i = 0; i < CONTROLPOINTNUMBER; i++)
                {
                    for (int j = 0; j < CONTROLPOINTNUMBER - 1; j++)
                    {
                        g.DrawLine(new Pen(Color.Black, 2), (int)rotatedPoints[4 * i + j].X, (int)rotatedPoints[4 * i + j].Y, (int)rotatedPoints[4 * i + j + 1].X, (int)rotatedPoints[4 * i + j + 1].Y);
                        g.DrawLine(new Pen(Color.Black, 2), (int)rotatedPoints[4 * j + i].X, (int)rotatedPoints[4 * j + i].Y, (int)rotatedPoints[4 * (j + 1) + i].X, (int)rotatedPoints[4 * (j + 1) + i].Y);
                    }
                }
            }
            
            g.FillRectangle((Brush)Brushes.Black, rotZ.X - 4, rotZ.Y - 4, 14, 14);
        }

        public Mesh()
        {
            triangles = new List<Triangle>();
            controlPoints = new List<Vector3>();
            LoadMesh();
            rotatedPoints = new List<Vector3>();
            foreach (var p in controlPoints)
            {
                rotatedPoints.Add(p);
            }
            alfa = 0;
            beta = 0;
            pointsNumber = 60;
            m = 5;
            ks = 0.2F;
            kd = 0.8F;
            z = new Vector3(100, 100, 350);
            rotationMatrix = Matrix4x4.Identity;
            color = new Vector3(0F, 1, 1F);
            rotZ = z;
            VisMesh = false;
            isTexture = false;
            isColor = true;
            isControl = false;
            LoadTexture();
            lightColor = Vector3.One;
            ColorImage = null;
        }
        public void LoadTexture()
        {
            image2 = ScaleImage( new Bitmap(@"../../../textures/0a88dafa79826a35c4c701eb6703d81c.jpg", true),400,400);
            image3 = ScaleImage(new Bitmap(@"../../../textures/tex2.png", true), 400, 400);
            image4 = ScaleImage(new Bitmap(@"../../../textures/R.png", true), 400, 400);
            image1 = image4;
        }
        public Bitmap ScaleImage(Bitmap bmp, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / bmp.Width;
            var ratioY = (double)maxHeight / bmp.Height; 
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(bmp.Width * ratio);
            var newHeight = (int)(bmp.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(bmp, 0, 0, newWidth, newHeight);

            return newImage;
        }
        public Vector4 MapVector(Color pixelColor, Vector3 norm, Vector3 pV, Vector3 pU, Vector3 pos)
        {
            Matrix4x4 matrix = Matrix4x4.Identity;
            matrix[0, 0] = norm.X;
            matrix[1, 0] = norm.Y;
            matrix[2, 0] = norm.Z;

            matrix[0, 1] = pV.X;
            matrix[1, 1] = pV.Y;
            matrix[2, 1] = pV.Z;

            matrix[0, 2] = pU.X;
            matrix[1, 2] = pU.Y;
            matrix[2, 2] = pU.Z;
            Vector3 p = new Vector3(pixelColor.R / 255f * 2 - 1, pixelColor.G / 255f * 2 - 1, Math.Max(pixelColor.B / 255f * 2 - 1,0));
            Vector4 vector4 = System.Numerics.Vector4.Transform(p, matrix);
            return vector4;
        }



    }
}
