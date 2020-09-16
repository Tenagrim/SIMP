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
        public Line(Point a, Point b) : base(Point.ToList(a,b))
        {
            Position = new Point(Math.Min(a.x, b.x), Math.Min(a.y, b.y));
        }

        public override void Draw(System.Drawing.Graphics field, System.Drawing.Pen pen)
        {
            field.DrawLine(pen, verticies[0].x, verticies[0].y, verticies[1].x, verticies[1].y);
            verticies[0].Draw(field);
            verticies[1].Draw(field);

        }
    }
}
