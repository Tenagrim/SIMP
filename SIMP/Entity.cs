using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMP
{
    abstract class Entity
    {
        public bool Visible { get; set; }
        public int ID { get { return id; } }
        public string Name { get; set; }
        public virtual List<Point> SelectedPoints { get; set; }

        protected int id;
        public virtual void SelectPoints(Point a, Point b, bool selecting)
        { 
        }
        public virtual void SelectPoints(Point a, bool selecting)
        {    
        }

        public virtual void SelectShapes(Point a, Point b, bool selecting)
        {
        }

        public virtual void SelectShapes(Point a, bool selecting)
        {
        }

        public virtual void Unselect()
        {
        }

        public virtual void SelectAll()
        {
        }

        public virtual bool DeleteSelected()
        {   
            return false;
        }

        public virtual bool ScaleSelected(float a, float d, Point pivot = null)
        {
            return false;
        }

        public virtual void RotateSelected(float angle, Point pivot = null)
        {

        }

        public virtual void center(System.Drawing.Graphics f)
        {

        }

        public virtual Shape GetShape(Point a)
        {
            return null;
        }

        public virtual void Display(System.Drawing.Graphics field, System.Drawing.Pen pen)
        {
        }
    }
}
