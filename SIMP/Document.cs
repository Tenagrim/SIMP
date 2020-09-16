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

        private int current_layer;
        private List<Layer> layers;

        public Document()
        {
            layers = new List<Layer>();
            layers.Add(new Layer(1));
            current_layer = 0;
        }
        public void NewLayer()
        {
            layers.Add(new Layer(layers.Count));
            current_layer = layers.Count - 1;
        }

        public void SelectPoints(Point a, Point b)
        {
            CurrentLayer.SelectPoints(a,b);
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

        public void SetCurrentLayer(int n)
        {
            current_layer = n < layers.Count && n >= 0 ? n : current_layer;
        }

        public void Display(System.Drawing.Graphics field, System.Drawing.Pen pen)
        {
            foreach (var l in layers)
                if (l.Visible)
                    l.Display(field, pen);
        }
    }
}
