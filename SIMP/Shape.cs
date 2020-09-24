using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIMP
{
    [Serializable]
    class Shape
    {
        public List<Point> verticies { get; set; }
        public Point Center { get { return GetCenter(verticies); } }
        public Point Begin { get { return verticies[0]; } }
        public Matrix Matrix { get { return GetMatrix(); } }
        public Layer Parent { get; set; }
        public bool Selected { get { return selected; } }

        [NonSerialized]
        public Pen pen;
        private bool is_path;
        private bool selected;

        [OnDeserialized]
        internal void Reinitialize(StreamingContext context)
        {
            pen = new Pen(Color.White, 2.0F);
        }

        public Shape(Layer parent, List<Point> verts, bool is_path) : this(verts)
        {
            this.is_path = is_path;
            Parent = parent;
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

        public void RemoveMe()
        {
            if (Parent != null)
                Parent.RemoveChild(this);
        }

        public virtual void Draw(Graphics field, Projection proj)
        {
            /*
            var pointfs = from v in verticies
                          select (v + Position).PointF;
            */
            //field.DrawClosedCurve(pen, pointfs.ToArray());
            DrawAsShape(proj, field, verticies, pen, is_path);
        }

        public static void DrawAsShape(Projection proj, Graphics field, List<Point> verticies, Pen pen, bool is_path = false)
        {
            Matrix data = new Matrix(verticies);
            //Matrix transform = proj.Matrix;
            //Matrix res = data * transform;
            Matrix res = proj.Project(data);

            for (int i = 1; i < res.Rows; i++)
            {
                field.DrawLine(pen, res._Matrix[i-1,0], res._Matrix[i -1, 1], res._Matrix[i , 0], res._Matrix[i , 1]);
                //verticies[i-1].Draw(field);
                Point.Draw(field, res._Matrix[i - 1, 0], res._Matrix[i - 1, 1], verticies[i - 1].Selected);
            }
            //verticies[verticies.Count-1].Draw(field);
            Point.Draw(field, res._Matrix[res.Rows - 1, 0], res._Matrix[res.Rows - 1, 1], verticies[res.Rows - 1].Selected);

            if (is_path)
                field.DrawLine(pen, res._Matrix[0,0] , res._Matrix[0, 1] , res._Matrix[res.Rows-1, 0] , res._Matrix[res.Rows - 1, 1] );
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
            float[,] res = new float[verticies.Count, 4];
            for (int i = 0; i < verticies.Count; i++)
            {
                res[i, 0] = verticies[i].x;
                res[i, 1] = verticies[i].y;
                res[i, 2] = verticies[i].z;
                res[i, 3] = 1;
            }
            return new Matrix(res);
        }



        public void Scale(float Dx, float Dy, float Dz = 1 )
        {
            Transform(verticies, Matrix.Scale(Dx, Dy, Dz));
        }

        public static Point GetCenter(List<Point> verticies)
        {
            var xs = from v in verticies
                     select v.x;
            var ys = from v in verticies
                     select v.y;
            float x_max = xs.Max();
            float x_min = xs.Min();
            float y_max = ys.Max();
            float y_min = ys.Min();

            return new Point(x_max - (x_max - x_min)/2, y_max - (y_max - y_min)/2);
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
