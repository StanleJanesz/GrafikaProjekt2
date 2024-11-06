using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;
using System.Globalization;
using System.Net.Http;
using System.Security.AccessControl;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace GrafikaProjekt2.Mesh
{
    internal class Mesh
    {
        List<Triangle> triangles;
        List<Vector3> controlPoints;
        List<Vector3> rotatedPoints;
        int pointsNumber;
        Matrix4x4 rotationMatrix;
        public int alfa,beta;
        const int CONTROLPOINTNUMBER = 4;
        public int m;
        public float ks;
        public float kd;
        public Vector3 z;
        void LoadMesh()
        {
            using (FileStream fs = File.Open("./Mesh.txt", FileMode.OpenOrCreate, FileAccess.Read))
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
        public void SetAlfa (int alfa)
        {
            this.alfa = alfa;
            rotatedPoints = new List<Vector3>();
            CalculateRotationMatrix();

            foreach (var p in controlPoints)
            {
                Vector4 vector4 = new Vector4(1, 1, 1, 0);
                vector4 = System.Numerics.Vector4.Transform(p, rotationMatrix);
               
                rotatedPoints.Add(new Vector3(vector4.X,vector4.Y,vector4.Z));
            }
        }
        public void SetM (int m)
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
            rotatedPoints = new List<Vector3>();
            CalculateRotationMatrix();
            foreach (var p in controlPoints)
            {
                Vector4 vector4 = new Vector4(1, 1, 1, 0);
                vector4 = System.Numerics.Vector4.Transform(p, rotationMatrix);

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
            triangles.Clear();
            float step = 1 / (float)pointsNumber;
            Vector3[,] tab = new Vector3[pointsNumber+1, pointsNumber+1];
            Vector3[,] tabPu = new Vector3[pointsNumber + 1, pointsNumber + 1];
            Vector3[,] tabPv = new Vector3[pointsNumber + 1, pointsNumber + 1];
            float bi, bj;
            Vector3 v;
            for (int i = 0; i < pointsNumber+1; i++)
            {
                for (int j = 0; j < pointsNumber+1; j++)
                {
                     v = new Vector3(0, 0, 0);
                    for (int k = 0; k < CONTROLPOINTNUMBER; k++)
                    {
                        bi = EqCoeff(step * i, k, CONTROLPOINTNUMBER);
                        for (int w = 0; w < CONTROLPOINTNUMBER; w++)
                        {
                            bj = EqCoeff(step * j, w, CONTROLPOINTNUMBER);
                            v += rotatedPoints[k * 4 + w]*bj*bi;
                        }
                    }
                    tab[i,j] = v;
                    v = new Vector3(0, 0, 0);
                    for (int k = 0; k < CONTROLPOINTNUMBER-1; k++)
                    {
                        bi = EqCoeff(step * i, k, CONTROLPOINTNUMBER);
                        for (int w = 0; w < CONTROLPOINTNUMBER; w++)
                        {
                            bj = EqCoeff(step * j, w, CONTROLPOINTNUMBER);
                            v += (rotatedPoints[(k+1) * 4 + w] - rotatedPoints[k * 4 + w]) * bj * bi;
                        }
                    }
                    tabPu[i, j] = CONTROLPOINTNUMBER * v;
                    v = new Vector3(0, 0, 0);
                    for (int k = 0; k < CONTROLPOINTNUMBER ; k++)
                    {
                        bi = EqCoeff(step * i, k, CONTROLPOINTNUMBER);
                        for (int w = 0; w < CONTROLPOINTNUMBER - 1; w++)
                        {
                            bj = EqCoeff(step * j, w, CONTROLPOINTNUMBER - 1);
                            v += (rotatedPoints[k  * 4 + w+1] - rotatedPoints[k * 4 + w]) * bj * bi;
                        }
                    }
                    tabPv[i, j] = CONTROLPOINTNUMBER * v;
                }
            }
            
            for (int i = 0; i < pointsNumber ; i++)
            {
                for (int j = 0; j < pointsNumber ; j++)
                {
                    Vertex v1 = new Vertex(tab[i, j], i, j, tabPu[i, j], tabPv[i,j]);
                    Vertex v2 = new Vertex(tab[i,j+1],i,j+1, tabPu[i, j + 1], tabPv[i, j + 1]);
                    Vertex v3 = new Vertex(tab[i+1,j],i+1,j, tabPu[i + 1, j], tabPv[i + 1, j]);
                    Vertex v4 = new Vertex(tab[i + 1, j + 1], i + 1, j + 1, tabPu[i + 1, j + 1], tabPv[i + 1, j + 1]);
                    triangles.Add(new Triangle(v1,v2,v3));
                    triangles.Add(new Triangle(v4,v2,v3));
                }
            }
        }
        float EqCoeff(float u, int k, int n)
        {
            return (float)binomialCoeff(k,n)*(float)Math.Pow(u, k)*(float)Math.Pow((double)(1-u),(double)(CONTROLPOINTNUMBER-1-k));
        }
        int binomialCoeff( int k,int n)
        {
            if ((k < 0) || (k > n - 1)) return 0;
            k = (k > n - 1 / 2) ? n - 1 - k : k;
            double a = 1;
            for (int i = 1; i <= k; i++) a = (a * (n - 1 - k + i)) / i;
            return (int)(a + 0.5);
        }
        public void Draw(Graphics g,Bitmap b)
        {
            CreateTriangles();
            
            foreach (var p in triangles)
                p.Fill(g, this); // g.FillRectangle((Brush)Brushes.Black, p.X, p.Y, 2, 2);
            //foreach (var p in triangles)
            //    p.Draw(g); // g.FillRectangle((Brush)Brushes.Black, p.X, p.Y, 2, 2);
            foreach (var p  in rotatedPoints)
            g.FillRectangle((Brush)Brushes.Red, p.X-4,p.Y-4,8,8);
            for (int i = 0; i < CONTROLPOINTNUMBER; i++)
            {
                for (int j = 0; j < CONTROLPOINTNUMBER-1; j++)
                {
                    g.DrawLine(new Pen(Color.Black, 2), (int)rotatedPoints[4*i+j].X, (int)rotatedPoints[4 * i + j].Y, (int)rotatedPoints[4 * i + j+1].X, (int)rotatedPoints[4 * i + j+1].Y);
                    g.DrawLine(new Pen(Color.Black, 2), (int)rotatedPoints[4*j+i].X, (int)rotatedPoints[4 * j + i].Y, (int)rotatedPoints[4 * (j + 1) + i].X, (int)rotatedPoints[4 * (j+1) + i].Y);
                }
            }
            //CreateTriangles();
            //foreach (var p in triangles)
            //    p.Draw(g); // g.FillRectangle((Brush)Brushes.Black, p.X, p.Y, 2, 2);
            
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
            pointsNumber = 80;
            m = 50;
            ks = 0.5F;
            kd = 0.5F;
            z = new Vector3(0,-300,-250);
            //z = Vector3.Normalize(z);
        }
        
    }
}
