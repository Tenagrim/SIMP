using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SIMP
{
    class Line : Shape
    {

        public string Formula { get { return CalcForm(); } }
        public Line(Point a, Point b) : base(Point.ToList(a, b))
        {
            Position = new Point(Math.Min(a.x, b.x), Math.Min(a.y, b.y));
            //CalcForm();
        }

        public override void Draw(System.Drawing.Graphics field)
        {
            field.DrawLine(pen, verticies[0].x, verticies[0].y, verticies[1].x, verticies[1].y);
            verticies[0].Draw(field);
            verticies[1].Draw(field);
        }

        private string CalcForm()
        {
            //string res = "y=";

            if (verticies[0].x == verticies[1].x)
                return $"x = {verticies[0].x}";
            if (verticies[0].y == verticies[1].y)
                return $"y = {verticies[0].y}";

            float[] y = new float[3];
            y[0] = verticies[0].y;
            y[1] = verticies[1].y;

            float[,] a = new float[2, 2];
            a[0, 0] = verticies[0].x;
            a[0, 1] = 1;
            a[1, 0] = verticies[1].x;
            a[1, 1] = 1;

            float[] x = Gauss(a, y, 2);

            return $"y={x[0]} * X + {x[1]}";
        }

        private float[] Gauss(float[,] a, float[] y, int n)
        {
            float[] x = new float[n];
            float max, tmp;
            float eps = 0.00001F;
            int k, index;
            k = 0;
            while (k < n)
            {
                max = Math.Abs(a[k, k]);
                index = k;
                for (int i = k + 1; i < n; i++)
                {
                    if (Math.Abs(a[i, k]) > max)
                    {
                        max = Math.Abs(a[i, k]);
                        index = i;
                    }
                }
                if (max < eps)
                {
                    // Решения нет
                    return null;
                }
                for (int j = 0; j < n; j++)
                {
                    tmp = a[k, j];
                    a[k, j] = a[index, j];
                    a[index, j] = tmp;
                }
                tmp = y[k];
                y[k] = y[index];
                y[index] = tmp;
                for (int i = k; i < n; i++)
                {
                    tmp = a[i, k];
                    if (Math.Abs(tmp) < eps) continue;
                    for (int j = 0; j < n; j++)
                        a[i, j] = a[i, j] / tmp;
                    y[i] = y[i] / tmp;
                    if (i == k) continue;
                    for (int j = 0; j < n; j++)
                        a[i, j] = a[i, j] - a[k, j];
                    y[i] = y[i] - y[k];
                }
                k++;
            }
            for (k = n - 1; k >= 0; k--)
            {
                x[k] = y[k];
                for (int i = 0; i < k; i++)
                    y[i] = y[i] - a[i, k] * x[k];
            }
            return x;
        }
    }
}
