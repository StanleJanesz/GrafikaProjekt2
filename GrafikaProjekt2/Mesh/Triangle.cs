using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
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

            List<PointF> pointFs = new List<PointF>();
            pointFs.Add(new PointF(vertex1.afterRot.X, vertex1.afterRot.Y));
            pointFs.Add(new PointF(vertex2.afterRot.X, vertex2.afterRot.Y));
            pointFs.Add(new PointF(vertex3.afterRot.X, vertex3.afterRot.Y));
            I *= 255;
            I.X = Math.Min(I.X, 255);
            I.Y = Math.Min(I.Y, 255);
            I.Z = Math.Min(I.Z, 255);
            Brush brush = new SolidBrush( Color.FromArgb((int)I.X,(int)I.Y , (int)I.Z ));
            g.FillPolygon(brush,pointFs.ToArray());
        }

    }
}
