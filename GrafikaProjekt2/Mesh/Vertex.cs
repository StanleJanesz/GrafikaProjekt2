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
        Vector3 point;
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
            
            rotN = N;
        }
        int u, v;
    }
}
