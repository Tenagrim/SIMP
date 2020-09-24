using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMP
{
    class Projection
    {
        public float Phi { get { return phi; } set { phi = value; matrix = GetMatrix(); } }
        public float Thetha { get { return thetha; } set { thetha = value; matrix = GetMatrix(); } }
        public float Zc { get { return zc; } set { zc = value; matrix = GetMatrix(); } }
        public float PosX { get { return pos_x; } set { pos_x = value; matrix = GetMatrix(); } }
        public float PosY { get { return pos_y; } set { pos_y = value; matrix = GetMatrix(); } }
        public float PosZ { get { return pos_z; } set { pos_z = value; matrix = GetMatrix(); } }
        public bool Perspective { get { return perspective; } set { perspective = value; matrix = GetMatrix(); } } 
        public Matrix Matrix { get { return matrix; } }
        public Point ViewSize { get; set; }

        private Matrix matrix;
        private float phi;
        private float thetha;
        private float zc;
        private bool perspective;
        private float pos_x;
        private float pos_y;
        private float pos_z;


        public Projection(Point ViewSize)
        {
            perspective = false;
            phi = 0;
            thetha = 0;
            zc = 1000;
            pos_x = 0;
            pos_y = 0;
            pos_z = 0;
            this.ViewSize = ViewSize;
            matrix = GetMatrix();
        }

        private Matrix GetMatrix()
        {
            float cosT = (float)Math.Cos(thetha);
            float sinT = (float)Math.Sin(thetha);
            float cosF = (float)Math.Cos(phi);
            float sinF =  (float)Math.Sin(phi);
            float[,] res;
            if(perspective)
             res = new float[,]
            {
                {cosF,   sinF*sinT,     0,  (sinF*cosT)/ zc },
                {0,      cosT,          0,  -(sinT/zc)},
                {sinF,   -cosF*sinT,    0,  -((cosF * cosT)/zc) },
                {0,      0,             0,   1 }
            };
            else
                res = new float[,]
                {
                    {cosF,   sinF*sinT,     0,  0 },
                    {0,      cosT,          0,  0},
                    {sinF,   -cosF*sinT,    0,  0 },
                    {0,      0,             0,   1 }
                };
            return new Matrix(res);
        }

        public Matrix Project(Matrix data)
        {
            if (!perspective)
            {
                Matrix m1 = matrix * SIMP.Matrix.Translate((ViewSize.x / 2 + pos_x), (ViewSize.y / 2 + pos_y), -pos_z);
                Matrix m2 = data * m1;
                //Matrix m3 = m2 * SIMP.Matrix.Translate(ViewSize.x / 2 + pos_x, ViewSize.y / 2 + pos_y, pos_z);
                return m2;
            }
            else 
            {
                Matrix m1 = data * matrix;
                //Matrix m2 = m1 * SIMP.Matrix.Translate((ViewSize.x / 2 + pos_x), (ViewSize.y / 2 + pos_y), -pos_z);
                return m1;
            }
        }
    }
}
