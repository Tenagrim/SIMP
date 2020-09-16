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
        private List<Shape> shapes;

        public  Layer()
        {
            shapes = new List<Shape>();
        }

        public void AddShape(Shape shape)
        {
            shapes.Add(shape);
        }

        public void Display(Graphics field, Pen pen)
        {
            foreach (var s in shapes)
                s.Draw(field, pen);
        }
    }
}
