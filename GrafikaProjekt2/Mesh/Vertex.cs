using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Net.NetworkInformation;
namespace GrafikaProjekt2.Mesh
{
    internal class Vertex
    {
        public Vector3 point;
        public Vector3 afterRot;
        public Vector3 Pu, Pv, N;
        public Vector3 rotPu, rotPv, rotN;

        public Vertex(Vector3 vector,int u,int v, Vector3 Pu,Vector3 Pv)
        {
            point = vector;
            afterRot = vector;
            this.u = u;
            this.v = v;
            this.Pu = Vector3.Normalize(Pu);
            this.Pv = Vector3.Normalize(Pv);
            rotPu = this.Pu;
            rotPv = this.Pv;
            N = Vector3.Cross(this.Pu, this.Pv);
            if (float.IsNaN(N.X))
            {
                N = Vector3.Zero;//Vector3.Normalize(Vector3.One);
                N.X = -1;
            }
            rotN = N;
        }
        public void Rotate(Matrix4x4 rotationMatrix)
        {
            Vector4 vector4 = new Vector4(1, 1, 1, 0);
            vector4 = System.Numerics.Vector4.Transform(point, rotationMatrix);

            afterRot = (new Vector3(vector4.X, vector4.Y, vector4.Z));
            vector4 = System.Numerics.Vector4.Transform(N, rotationMatrix);

            rotN = (new Vector3(vector4.X, vector4.Y, vector4.Z));

        }
        int u, v;
    }
}
