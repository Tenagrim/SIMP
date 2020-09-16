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

        public Shape(List<Point> verts, Point pos)
        {
            Position = pos;
            verticies = verts;
        }

        public virtual void Draw(Graphics field, Pen pen)
        {
            var pointfs = from v in verticies
                          select (v + Position).PointF;
            field.DrawClosedCurve(pen, pointfs.ToArray());
        }
    }
}
