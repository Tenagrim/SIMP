using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMP
{
    [Serializable]
    class Point
    {
        public int x;
        public int y;
        public int state;
        public bool Selected { get; set; }
        public PointF PointF { get { return new PointF((float)x, (float)y); } }
        public Shape Parent { get; set; }



        public Point(int x, int y, bool selected) : this(x, y)
        {
            Selected = selected;
        }
        public Point(int x, int y, int state) : this(x, y)
        {
            this.state = state;
        }
        public Point(int x, int y) :this()
        {
            this.x = x;
            this.y = y;
        }
        public Point()
        {
            x = 0;
            y = 0;
            state = 0;
            Selected = false;
            Parent = null;
        }

        public Point(Point re)
        {
            x = re.x;
            y = re.y;
            state = re.state;
            Selected = false;
        }

        public bool IsInRect(Point a, Point b)
        {
            return x >= Math.Min(a.x, b.x) && x <= Math.Max(a.x, b.x) && y >= Math.Min(a.y, b.y) && y <= Math.Max(a.y, b.y);
        }

        public void Select(Point a, Point b, bool selecting = true)
        {
            if (IsInRect(a, b))
                Selected = selecting;
        }

        public void Draw(Graphics field)
        {
            if (Selected)
            {

                field.FillRectangle(Brushes.White, x - 3, y - 3, 7, 7);
                field.FillRectangle(Brushes.Black, x - 1, y - 1, 3, 3);
            }
            else
            {
                field.FillRectangle(Brushes.White, x, y, 1, 1);
            }
        }

        public static List<Point> ToList(Point a, Point b)
        {
            List<Point> res = new List<Point>();
            res.Add(a);
            res.Add(b);
            return res;
        }

        public static float Dist(Point a, Point b)
        {
            return (float)Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2));
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);
        }

        public static bool operator ==(Point a, Point b)
        {
            return (a.x == b.x && a.y == b.y);
        }
        public static bool operator !=(Point a, Point b)
        {
            return !(a.x != b.x || a.y != b.y);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"x = {x}  y = {y} ";
        }
    }
}
