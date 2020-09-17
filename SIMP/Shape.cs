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
        public Point Position { get; set; }
        public Point Begin { get { return verticies[0]; } }

        public System.Drawing.Pen pen { get; set; }

        public bool Selected { get { return selected; }  }

        private bool is_path;
        private bool selected;
        public Shape(List<Point> verts, bool is_path) : this(verts)
        {
            this.is_path = is_path;
        }

        public Shape(List<Point> verts)
        {
            Position = new Point();
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
    }
}
