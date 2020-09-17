using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMP
{
    class Layer
    {
        public List<Shape> Shapes { get { return shapes; } }
        public List<Point> SelectedPoints
        {
            get
            {
                var points = from s in shapes
                             from p in s.verticies
                             where p.Selected
                             select p;
                return points.ToList();
            }
        }
        public bool Visible { get; set; }
        public string Name { get; set; }

        private List<Shape> shapes;


        public Layer()
        {
            shapes = new List<Shape>();
            Visible = true;
            Name = "Layer";
        }

        public Layer(string name) : this()
        {
            Name = name;
        }

        public Layer(int n) : this()
        {
            Name = $"Layer {n}";
        }

        public void AddShape(Shape shape)
        {
            shapes.Add(shape);
            shape.Unselect();
        }

        public Shape GetShape(Point a)
        {
            foreach (var s in shapes)
                foreach (var v in s.verticies)
                    if (Point.Dist(a, v) <= 5)
                        return s;
            return null;
        }

        public void Display(Graphics field, Pen pen)
        {
            foreach (var s in shapes)
                s.Draw(field);
        }

        public void SelectPoints(Point a, Point b, bool selecting)
        {
            foreach (var s in shapes)
                foreach (var p in s.verticies)
                    p.Select(a, b, selecting);
        }

        public void SelectShapes(Point a, Point b, bool selecting)
        {
            foreach (var s in shapes)
                foreach (var p in s.verticies)
                {
                    if (p.IsInRect(a, b) && s.Selected != selecting)
                        s.Select(selecting);
                }
        }

            public void Unselect()
        {
            foreach (var s in shapes)
                s.Unselect();
        }

        public void SelectAll()
        {
            foreach (var s in shapes)
                s.Select();
        }

        public override string ToString()
        {
            string res = $"{Name}  [{shapes.Count}]";
            res += Visible ? " " : " ";
            return res;
        }
    }
}
