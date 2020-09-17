using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMP
{
    class Shape
    {
        public List<Point> verticies { get; set; }
        public Point Center { get { return GetCenter(verticies); } }
        public Point Begin { get { return verticies[0]; } }
        public Matrix Matrix { get { return GetMatrix(); } }
        public Pen pen { get; set; }
        public bool Selected { get { return selected; }  }

        private bool is_path;
        private bool selected;
        public Shape(List<Point> verts, bool is_path) : this(verts)
        {
            this.is_path = is_path;
        }

        public Shape(List<Point> verts)
        {
            verticies = verts;
            is_path = false;
            selected = false;
            pen = new Pen(System.Drawing.Color.White, 2.0F);
            for (int i = 0; i < verticies.Count; i++)
                verticies[i].Parent = this;
        }

        public virtual void Draw(Graphics field)
        {
            /*
            var pointfs = from v in verticies
                          select (v + Position).PointF;
            */
            //field.DrawClosedCurve(pen, pointfs.ToArray());
            DrawAsShape(field, verticies, pen, is_path);
        }

        public static void DrawAsShape(Graphics field, List<Point> verticies, Pen pen, bool is_path = false)
        {
            for (int i = 1; i < verticies.Count; i++)
            {
                field.DrawLine(pen, verticies[i - 1].x, verticies[i - 1].y, verticies[i].x, verticies[i].y);
                verticies[i-1].Draw(field);
            }
            verticies[verticies.Count-1].Draw(field);

            if (is_path)
                field.DrawLine(pen, verticies[0].x, verticies[0].y, verticies[verticies.Count - 1].x, verticies[verticies.Count - 1].y);
        }

        public void Select(bool selecting = true)
        {
            pen.Color = selecting? Color.Coral : Color.White;
            selected = selecting;
            for (int i = 0; i < verticies.Count; i++)
                verticies[i].Selected = selecting;
        }

        public void Unselect()
        {
            pen.Color = Color.White;
            selected = false;
            for (int i = 0; i < verticies.Count; i++)
                verticies[i].Selected = false;
        }

        private Matrix GetMatrix()
        {
            float[,] res = new float[verticies.Count, 3];
            for (int i = 0; i < verticies.Count; i++)
            {
                res[i, 0] = verticies[i].x;
                res[i, 1] = verticies[i].y;
                res[i, 2] = verticies[i].z;
            }
            return new Matrix(res);
        }



        public void Scale(float a, float d)
        {
            Transform(verticies, Matrix.Scale(a, d));
        }

        public static Point GetCenter(List<Point> verticies)
        {
            var xs = from v in verticies
                     select v.x;
            var ys = from v in verticies
                     select v.y;
            return new Point(xs.Sum() / xs.Count(), ys.Sum() / ys.Count());
        }

        public static void Transform(List<Point> verticies, Matrix transform)
        {
            Matrix tr_matrix = new Matrix(verticies) * transform;

            if (tr_matrix.Rows != verticies.Count || tr_matrix.Cols != 3)
                throw new Exception("Invalid tranformation matrix");

            for (int i = 0; i < tr_matrix.Rows; i++)
            {
                verticies[i].x = (int)tr_matrix._Matrix[i, 0];
                verticies[i].y = (int)tr_matrix._Matrix[i, 1];
                verticies[i].z = (int)tr_matrix._Matrix[i, 2];
            }
        }
    }
}
