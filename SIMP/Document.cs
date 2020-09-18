using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMP
{
    class Document
    {
        public List<Layer> Layers { get { return layers; } }
        public Layer CurrentLayer { get { return layers[current_layer]; } }
        public int CurrentLayerIndex { get { return current_layer; } }
        public List<Point> SelectedPoints { get { return CurrentLayer.SelectedPoints; } }

        public List<Point> TempPoints { get; set; }

        private int current_layer;
        private List<Layer> layers;

        public Document()
        {
            layers = new List<Layer>();
            layers.Add(new Layer(1));
            TempPoints = new List<Point>();
            current_layer = 0;
        }
        public void NewLayer()
        {
            layers.Add(new Layer(layers.Count));
            current_layer = layers.Count - 1;
        }

        public void SelectPoints(Point a, Point b, bool selecting)
        {
            CurrentLayer.SelectPoints(a, b, selecting);
        }
        public void SelectPoints(Point a,  bool selecting)
        {
            CurrentLayer.SelectPoints(a,  selecting);
        }

        public void SelectShapes(Point a, Point b, bool selecting)
        {
            CurrentLayer.SelectShapes(a, b, selecting);
        }
        public void SelectShapes(Point a,  bool selecting)
        {
            CurrentLayer.SelectShapes(a, selecting);
        }
        public void Unselect()
        {
            CurrentLayer.Unselect();
        }
        public void UnselectAll()
        {
            foreach (var l in layers)
                l.Unselect();
        }

        public void SelectAll()
        {
            CurrentLayer.SelectAll();
        }

        public bool DeleteSelected()
        {
           return CurrentLayer.DeleteSelected();
        }

        public bool ScaleSelected(float a,float d, Point pivot = null)
        {
            CurrentLayer.ScaleSelected(a, d,pivot);
            return true;
        }

        public void RotateSelected(float angle, Point pivot = null)
        {
            CurrentLayer.RotateSelected(angle);
        }

        public Shape GetShape(Point a)
        {
            return CurrentLayer.GetShape(a);
        }

        public void SetCurrentLayer(int n)
        {
            current_layer = n < layers.Count && n >= 0 ? n : current_layer;
        }

        public void DisplayTempPoints(System.Drawing.Graphics field)
        {
            if (TempPoints.Count == 0)
                return;
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.White, 2.0F);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            Shape.DrawAsShape(field, TempPoints, pen);
            pen.Dispose();
        }

        public void AddShape(bool is_path = false)
        {
            if (TempPoints.Count == 0)
                return;
            CurrentLayer.AddShape(new Shape(TempPoints, is_path));
            TempPoints = new List<Point>();
        }

        public void Display(System.Drawing.Graphics field, System.Drawing.Pen pen)
        {
            foreach (var l in layers)
                if (l.Visible)
                    l.Display(field, pen);
            DisplayTempPoints(field);
        }

        public void ClearTempVerticies()
        {
            TempPoints.Clear();
        }

        public void center(System.Drawing.Graphics f)
        {
            CurrentLayer.center(f);
        }
    }
}
