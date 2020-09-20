using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMP
{
    class Layer : Entity
    {
        public List<Shape> Shapes { get { return shapes; } }
        public override List<Shape> SelectedShapes { get { return GetSelectedShapes(); } }
        public override List<Point> SelectedPoints
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



        private List<Shape> shapes;


        public Layer()
        {
            shapes = new List<Shape>();
            Visible = true;
            Name = "Layer";
            Parent = null;
        }

        public Layer(string name, int id) : this()
        {
            Name = name;
            this.id = id;
        }

        public Layer(int name, int id, List<Shape> shapes = null) 
        {
            Name = $"Layer {name}";
            this.id = id;
            if (shapes != null)
            {
                this.shapes = shapes;
                foreach (var s in shapes)
                {
                    s.Unselect();
                    s.RemoveMe();
                }               
            }
            else
                this.shapes = new List<Shape>();
            Visible = true;
            Parent = null;
        }

        private List<Shape> GetSelectedShapes()
        {
            var sel = (from s in shapes
                       where s.Selected == true
                       select s).ToList();
            return (sel);
        }

        public void AddShape(Shape shape)
        {
            shapes.Add(shape);
            shape.Unselect();
        }

        public void RemoveChild(Shape child)
        {
            shapes.Remove(child);
        }
        public override Shape GetShape(Point a)
        {
            foreach (var s in shapes)
                foreach (var v in s.verticies)
                    if (Point.Dist(a, v) <= 5)
                        return s;
            return null;
        }

        public override void Display(Graphics field, Pen pen)
        {
            if (!Visible)
                return;
            foreach (var s in shapes)
                s.Draw(field);
        }

        public override void SelectPoints(Point a, Point b, bool selecting)
        {
            foreach (var s in shapes)
                foreach (var p in s.verticies)
                    p.Select(a, b, selecting);
        }
        public override void SelectPoints(Point a, bool selecting)
        {
            foreach (var s in shapes)
                foreach (var p in s.verticies)
                    p.Select(a, selecting);
        }

        public override void SelectShapes(Point a, Point b, bool selecting)
        {
            foreach (var s in shapes)
                foreach (var p in s.verticies)
                {
                    if (p.IsInRect(a, b) && s.Selected != selecting)
                        s.Select(selecting);
                }
        }

        public override void SelectShapes(Point a, bool selecting)
        {
            foreach (var s in shapes)
                foreach (var p in s.verticies)
                {
                    if (Point.Dist(p, a) <= 5 && s.Selected != selecting)
                        s.Select(selecting);
                }
        }

        public override void Unselect()
        {
            foreach (var s in shapes)
                s.Unselect();
        }

        public override void SelectAll()
        {
            foreach (var s in shapes)
                s.Select();
        }

        public override bool DeleteSelected()
        {
            bool f;
            do
            {
                f = false;
                foreach (var s in shapes)
                    if (s.Selected)
                    {
                        shapes.Remove(s);
                        f = true;
                        break;
                    }
            } while (f);
            return f;
        }

        public override bool ScaleSelected(float a, float d, Point pivot = null)
        {
            List<Point> points = SelectedPoints;
            if (points.Count <= 1)
                return false;

            Point center1 = Shape.GetCenter(points);
            Matrix scale = Matrix.Scale(a, d);
            Shape.Transform(points, scale);
            Point center2 = Shape.GetCenter(points);
            Matrix translate = Matrix.Translate(center1.x - center2.x, center1.y - center2.y);
            Shape.Transform(points, translate);
            return true;
        }

        public override void RotateSelected(float angle, Point pivot = null)
        {
            Point center;
            List<Point> points = SelectedPoints;
            if (points.Count <= 1)
                return;
            if (pivot == null)
                center = Shape.GetCenter(points);
            else 
                center = pivot;
            Matrix rotation = Matrix.Rotate(center, angle);
            Shape.Transform(points, rotation);
        }

        public override void center(Graphics f)
        {
            List<Point> points = SelectedPoints;
            if (points.Count <= 1)
                return;

            Point center = Shape.GetCenter(points);
            center.Select(center);
            center.Draw(f);
        }

        public override string ToString()
        {
            string res = $"{Name}  [{shapes.Count}]";
            res += Visible ? " " : " ";
            return res;
        }
    }
}
