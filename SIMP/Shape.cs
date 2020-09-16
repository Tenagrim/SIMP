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

        public Shape(List<Point> verts)
        {
            Position = new Point();
            verticies = verts;
        }

        public virtual void Draw(Graphics field, Pen pen)
        {
            var pointfs = from v in verticies
                          select (v + Position).PointF;
            field.DrawClosedCurve(pen, pointfs.ToArray());
        }

        public void Select()
        {
            for (int i = 0; i < verticies.Count; i++)
                verticies[i].Selected = true;
        }

        public void Unselect()
        {
            for (int i = 0; i < verticies.Count; i++)
                verticies[i].Selected = false;
        }
    }
}
