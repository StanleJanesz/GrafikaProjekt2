using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Data;
namespace GrafikaProjekt2.Mesh
{
    internal class Triangle
    {
        Vertex vertex1;
        Vertex vertex2;
        Vertex vertex3;
        public Triangle(Vertex vertex1, Vertex vertex2,Vertex vertex3)  
        {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            this.vertex3 = vertex3;
        }
        public void Draw(Graphics g)
        {
            g.DrawLine(new Pen(Color.Black, 1), vertex1.afterRot.X, vertex1.afterRot.Y, vertex2.afterRot.X, vertex2.afterRot.Y);
            g.DrawLine(new Pen(Color.Black, 1), vertex1.afterRot.X, vertex1.afterRot.Y, vertex3.afterRot.X, vertex3.afterRot.Y);
            g.DrawLine(new Pen(Color.Black, 1), vertex3.afterRot.X, vertex3.afterRot.Y, vertex2.afterRot.X, vertex2.afterRot.Y);
            //g.FillRectangle((Brush)Brushes.Black, vertex1.afterRot.X, vertex1.afterRot.Y, 2, 2);
            //g.FillRectangle((Brush)Brushes.Black, vertex2.afterRot.X, vertex2.afterRot.Y, 2, 2);
            //g.FillRectangle((Brush)Brushes.Black, vertex3.afterRot.X, vertex3.afterRot.Y, 2, 2);
        }
        public void Fill (Graphics g,Mesh mesh)
        {
            Vector3 color = new Vector3(1F, 0F, 0.1F);
            Vector3 L = Vector3.Normalize(-vertex3.afterRot + mesh.z);
                Vector3 I = Vector3.Zero;
            var A = (float)Vector3.Dot(Vector3.Normalize((Vector3.UnitZ)), 2 * Vector3.Dot(vertex3.rotN, L) * (vertex3.rotN - L));
            if (A > 0)
                 I +=  mesh.ks*color*(float)Math.Pow(A,mesh.m) ;
            if (Vector3.Dot(vertex3.rotN, L) > 0)
                I += mesh.kd * color * Vector3.Dot(vertex3.rotN, L);

            I *= 255;
            I.X = Math.Min(I.X, 255);
            I.Y = Math.Min(I.Y, 255);
            I.Z = Math.Min(I.Z, 255);
            FillPolygon( g,  mesh);
        }
        // Compute barycentric coordinates (u, v, w) for
        // point p with respect to triangle (a, b, c)
        (float u,float v, float w) Barycentric(Vector2 p, Vector2 a, Vector2 b, Vector2 c)
        {
            Vector2 v0 = b - a, v1 = c - a, v2 = p - a;
            float d00 = Vector2.Dot(v0, v0);
            float d01 = Vector2.Dot(v0, v1);
            float d11 = Vector2.Dot(v1, v1);
            float d20 = Vector2.Dot(v2, v0);
            float d21 = Vector2.Dot(v2, v1);
            float denom = d00 * d11 - d01 * d01;
            float v = (d11 * d20 - d01 * d21) / denom;
            float w = (d00 * d21 - d01 * d20) / denom;
            float u = 1.0f - v - w;
            return (u, v, w);
        }
        (Vector3 pos, Vector3 norm) CalculateVertex(int x,int y)
        {
            float u, v, w;
            (u, v, w) = Barycentric(new Vector2(x, y), new Vector2(vertex1.afterRot.X, vertex1.afterRot.Y), new Vector2(vertex2.afterRot.X, vertex2.afterRot.Y), new Vector2(vertex3.afterRot.X, vertex3.afterRot.Y));
            Vector3 pos = (u * vertex1.afterRot + v * vertex2.afterRot + w * vertex3.afterRot);
            Vector3 norm = u*vertex1.N + v * vertex2.N + w * vertex3.N;
            return (pos, norm);
        }
        public void FillPixel(int x, int y, Graphics g, Mesh mesh)
        {
            Vector3 color = new Vector3(1F, 0F, 0.1F);
            Vector3 pos, norm;
            (pos,norm) = CalculateVertex(x,y);
            Vector3 L = Vector3.Normalize(-pos + mesh.z);
            Vector3 I = Vector3.Zero;
            var A = (float)Vector3.Dot(Vector3.Normalize((Vector3.UnitZ)), 2 * Vector3.Dot(norm, L) * (norm - L));
            if (A > 0)
                I += mesh.ks * color * (float)Math.Pow(A, mesh.m);
            if (Vector3.Dot(norm, L) > 0)
                I += mesh.kd * color * Vector3.Dot(norm, L);
            I *= 255;
            I.X = Math.Min(I.X, 255);
            I.Y = Math.Min(I.Y, 255);
            I.Z = Math.Min(I.Z, 255);
            I.X = Math.Max(I.X, 0);
            I.Y = Math.Max(I.Y, 0);
            I.Z = Math.Max(I.Z, 0);
            Brush brush = new SolidBrush(Color.FromArgb((int)I.X, (int)I.Y, (int)I.Z));
            g.FillRectangle(brush, x, y, 1, 1);
        }
        public void FillLine(List<AET> AETs, int y, Graphics g, Mesh mesh)
        {
            int i = AETs.Count;
            if (AETs.Count == 3)
            {
                if (float.IsNaN(vertex1.N.X))
                    return;
                Brush brush = new SolidBrush(Color.FromArgb(123, 123, 123));
                for (int x = (int)AETs[0].x; x < (int)AETs[2].x; x++)
                {
                    FillPixel(x, y, g, mesh);
                }
            }
            List<AET> AETs1  =  AETs.Where(t => t.ymax < 6).ToList();
            for (int j = 0; j + 1 < i; j += 2)
            {
                Brush brush = new SolidBrush(Color.FromArgb(123, 123, 123));
                for (int x = (int)AETs[j].x; x < (int)AETs[j + 1].x; x++)
                {
                    FillPixel(x, y, g, mesh);
                }


            }


            
        }

        public void FillPolygon(Graphics g, Mesh mesh)
        {
            int min, max;
            (min, max) = MinMax();
            List<AET>[] ET = CreateET(min,max);
            List<AET> AETs = new List<AET>();
            List<AET> del = new List<AET>();
            int ETcounter = 3;
            int y = min;
            while ( (ETcounter > 0 || AETs.Count > 0 ) && y <= max) 
            { 
                if (ET[y -min] != null)
                {
                    AETs.AddRange(ET[y - min]);
                    ETcounter -= ET[y - min].Count;
                }
                AETs = AETs.OrderBy(o => o.x).ToList();
                AETs.Sort((x, y) => x.x.CompareTo(y.x));
                FillLine(AETs, y, g, mesh);  // fill line 
                foreach (AET aET in AETs) { if (aET.ymax <= y) del.Add(aET); }
                if (del.Count > 0)
                {
                    foreach (AET aET in del)
                    {
                        AETs.Remove(aET);
                    }
                    del.Clear();
                }

                ++y;
                foreach (AET aET in AETs)
                {
                    aET.x += aET.step;
                }
            }

        }
        List<AET>[] CreateET(int min, int max)
        {
            List<AET>[] aETs = new List<AET>[max-min+1];
            Vertex v1, v2;
            if ( vertex1.afterRot.Y < vertex2.afterRot.Y )
            {
                v1 = vertex1;
                v2 = vertex2;
            }
            else
            {
                v1 = vertex2;
                v2 = vertex1;
            }
            aETs[ (int)v1.afterRot.Y - min] = new List<AET>();
            if ((int)v2.afterRot.Y - (int)v1.afterRot.Y == 0) //Console.WriteLine("lol");
            aETs[(int)v1.afterRot.Y - min].Add(new AET((int)v2.afterRot.Y , v1.afterRot.X, 0));
            else
                aETs[ (int)v1.afterRot.Y - min].Add(new AET((int)v2.afterRot.Y , v1.afterRot.X, (float)((int)v2.afterRot.X - (int)v1.afterRot.X) / (float)((int)v2.afterRot.Y - (int)v1.afterRot.Y)));
            if (vertex1.afterRot.Y < vertex3.afterRot.Y)
            {
                v1 = vertex1;
                v2 = vertex3;
            }
            else
            {
                v1 = vertex3;
                v2 = vertex1;
            }
            if (aETs[(int)v1.afterRot.Y - min] == null)
                aETs[(int)v1.afterRot.Y - min] = new List<AET>();
            if (v2.afterRot.Y - v1.afterRot.Y == 0) //Console.WriteLine("");
                aETs[(int)v1.afterRot.Y - min].Add(new AET((int)v2.afterRot.Y , v1.afterRot.X, 0));
            else
                aETs[(int)v1.afterRot.Y - min].Add(new AET((int)v2.afterRot.Y , v1.afterRot.X, (float)((int)v2.afterRot.X - (int)v1.afterRot.X) / (float)((int)v2.afterRot.Y - (int)v1.afterRot.Y)));
           
            if (vertex2.afterRot.Y < vertex3.afterRot.Y)
            {
                v1 = vertex2;
                v2 = vertex3;
            }
            else
            {
                v1 = vertex3;
                v2 = vertex2;
            }
            if (aETs[(int)v1.afterRot.Y - min] == null)
                aETs[(int)v1.afterRot.Y - min] = new List<AET>();
            if (v2.afterRot.Y - v1.afterRot.Y == 0) //Console.WriteLine("");
                aETs[(int)v1.afterRot.Y - min].Add(new AET((int)v2.afterRot.Y , v1.afterRot.X, 0));
            else

                aETs[(int)v1.afterRot.Y - min].Add(new AET((int)v2.afterRot.Y , v1.afterRot.X, (float)((int)v2.afterRot.X - (int)v1.afterRot.X) / (float)((int)v2.afterRot.Y - (int)v1.afterRot.Y)));
            return aETs;
        }
        (int min, int max) MinMax()
        {
            int min = (int)vertex1.afterRot.Y;
            int max = (int)vertex1.afterRot.Y;
            if((int)vertex2.afterRot.Y > max) max = (int)vertex2.afterRot.Y;
            if((int)vertex3.afterRot.Y > max) max = (int)vertex3.afterRot.Y;
            if((int)vertex3.afterRot.Y < min) min = (int)vertex3.afterRot.Y;
            if((int)vertex2.afterRot.Y < min) min = (int)vertex2.afterRot.Y;
            return (min, max);
        }

    }
    public class AET
    {
        public int ymax;
        public float x;
        public float step;
        public AET(int ymax, float x, float step)
        {
            this.ymax = ymax;
            this.x = x;
            this.step = step;
        }
    
    }

}
