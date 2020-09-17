using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMP
{
    class Matrix
    {
        public float[,] _Matrix { get { return matrix; } }
        public int Rows { get { return matrix.GetLength(0); } }
        public int Cols { get { return matrix.GetLength(1); } }
        private float[,] matrix;

        public Matrix(int rows, int cols)
        {
            matrix = new float[rows, cols];
        }
        public Matrix(float[,] array)
        {
            matrix = array;
        }

        public Matrix(List<Point> points)
        {
            matrix = new float[points.Count, 3];
            for (int i = 0; i < points.Count; i++)
            {
                matrix[i, 0] = points[i].x;
                matrix[i, 1] = points[i].y;
                matrix[i, 2] = points[i].z;
            }

        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Cols != b.Rows)
                throw new Exception("Invalid matrix multiplication");
            float[,] res = new float[a.Rows, b.Cols];
            float sum;
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Rows; j++)
                {
                    sum = 0;
                    for (int k = 0; k < b.Cols; k++)
                    {
                        sum += a.matrix[i, k] * b.matrix[k, j];
                    }
                    res[i, j] = sum;
                }
            }
            return new Matrix(res);
        }

        public static Matrix Scale(float a, float d)
        {
            float[,] res = new float[3, 3] {
                { a, 0, 0 },
                { 0, d, 0 },
                { 0, 0, 1 } };

            return new Matrix(res);
        }
        public static Matrix Translate(float m, float n)
        {
            float[,] res = new float[3, 3] {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { m, n, 1 } };

            return new Matrix(res);
        }

        public static Matrix Rotate(Point pivot, float angle)
        {
            float cosT = (float)Math.Cos(angle);
            float sinT = (float)Math.Sin(angle);
            float[,] res = new float[3, 3] {
                { cosT, sinT, 0 },
                { -sinT, cosT, 0 },
                { -pivot.x *(cosT-1) + pivot.y* sinT, -pivot.x *(sinT) - pivot.y* (cosT-1), 1 } };

            return new Matrix(res);
        }


    }
}
