using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMP
{
    class Folder : Entity
    {
        public List<Entity> childs;

        public override List<Point> SelectedPoints
        {
            get
            {
                var folders_points = (from c in childs
                             where c is Folder
                             from p in ((Folder)c).SelectedPoints
                             select p);

                var layers_points = (from c in childs
                                    where c is Layer
                                    from s in ((Layer)c).Shapes
                                    from p in s.verticies
                                    where p.Selected == true
                                    select p);

                var res = folders_points.Union(layers_points).ToList();

                return res;
            }
        }

        public Folder(string name, int id) : this()
        {
            Name = name;
            this.id = id;
        }

        public Folder(int name, int id) : this()
        {
            Name = $"Folder {name}";
            this.id = id;
        }

        public Folder()
        {
            childs = new List<Entity>();
            Visible = true;
            Name = "Folder";
        }

        public override void SelectPoints(Point a, Point b, bool selecting)
        {
            foreach (var c in childs)
            {
                if (c is Folder)
                    ((Folder)c).SelectPoints(a,b,selecting);
                else if (c is Layer)
                {
                    foreach (var s in ((Layer)c).Shapes)
                        foreach (var p in s.verticies)
                            p.Select(a, b, selecting);
                }
            }
        }
        public override void SelectPoints(Point a, bool selecting)
        {
            foreach (var c in childs)
            {
                if (c is Folder)
                    ((Folder)c).SelectPoints(a,  selecting);
                else if (c is Layer)
                {
                    foreach (var s in ((Layer)c).Shapes)
                        foreach (var p in s.verticies)
                            p.Select(a,  selecting);
                }
            }
        }

        public override void SelectShapes(Point a, Point b, bool selecting)
        {
            foreach (var c in childs)
            {
                if (c is Folder)
                    ((Folder)c).SelectShapes(a, b, selecting);
                else if (c is Layer)
                {
                    foreach (var s in ((Layer)c).Shapes)
                        foreach (var p in s.verticies)
                        {
                            if (p.IsInRect(a, b) && s.Selected != selecting)
                                s.Select(selecting);
                        }
                }
            }
        }

        public override void SelectShapes(Point a, bool selecting)
        {
            foreach (var c in childs)
            {
                if (c is Folder)
                    ((Folder)c).SelectShapes(a, selecting);
                else if (c is Layer)
                {
                    foreach (var s in ((Layer)c).Shapes)
                        foreach (var p in s.verticies)
                        {
                            if (Point.Dist(p, a) <= 5 && s.Selected != selecting)
                                s.Select(selecting);
                        }
                }
            }
        }

        public override void Unselect()
        {
            foreach (var c in childs)
            {
                if (c is Folder)
                    ((Folder)c).Unselect();
                else if (c is Layer)
                {
                    foreach (var s in ((Layer)c).Shapes)
                        s.Unselect();
                }
            }
        }

        public override  void SelectAll()
        {
            foreach (var c in childs)
            {
                if (c is Folder)
                    ((Folder)c).SelectAll();
                else if (c is Layer)
                {
                    foreach (var s in ((Layer)c).Shapes)
                        s.Select();
                }
            }
        }
        public override bool DeleteSelected()
        {
            bool f = false;
            foreach (var c in childs)
            {
                if (c is Folder)
                    ((Folder)c).DeleteSelected();
                else if (c is Layer)
                {

                    do
                    {
                        f = false;
                        foreach (var s in ((Layer)c).Shapes)
                            if (s.Selected)
                            {
                                ((Layer)c).Shapes.Remove(s);
                                f = true;
                                break;
                            }
                    } while (f);
                }
            }
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

        public override void center(System.Drawing.Graphics f)
        {
            List<Point> points = SelectedPoints;
            if (points.Count <= 1)
                return;

            Point center = Shape.GetCenter(points);
            center.Select(center);
            center.Draw(f);
        }

        public override Shape GetShape(Point a)
        {
            foreach (var c in childs)
            {
                if (c is Folder)
                  return  ((Folder)c).GetShape(a);
                else if (c is Layer)
                {
                    foreach (var s in ((Layer)c).Shapes)
                        foreach (var v in s.verticies)
                            if (Point.Dist(a, v) <= 5)
                                return s;
                }
            }

            return null;
        }

        public override void Display(System.Drawing.Graphics field, System.Drawing.Pen pen)
        {
            if (!Visible)
                return;
            foreach (var c in childs)
            {
                if (c is Folder)
                 ((Folder)c).Display(field, pen);
                else if (c is Layer)
                {
                    ((Layer)c).Display(field,pen);
                }
            }
        }
    }
}
