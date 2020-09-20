using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMP
{
    class Document
    {
        //public List<Layer> Layers { get { return layers; } }

        public List<Entity> Entities { get { return entities; } }
        public Entity CurrentEntity { get { return currentEntity; } }
        public List<Point> SelectedPoints { get { return CurrentEntity.SelectedPoints; } }
        public Entity LastAdded { get{ return last_added; } }

        public List<Point> TempPoints { get; set; }

        private Entity currentEntity;
        private List<Layer> layers;
        private List<Entity> entities;
        private Entity last_added;
        private int last_id;

        public Document()
        {
            last_id = 1;
            entities = new List<Entity>();
            entities.Add(new Layer(1, 1));
            TempPoints = new List<Point>();
            currentEntity = entities[0];

        }
        public void NewLayer()
        {
            last_id++;
            Layer l = new Layer(last_id, last_id);
            entities.Add(l);
            currentEntity = l;
            last_added = l;

        }
        public void NewFolder()
        {
            last_id++;
            Folder f = new Folder(last_id, last_id);
            entities.Add(f);
            last_added = f;
            //currentEntity = f;
        }

        public void ChangeVisible(int id, bool f)
        {
            Entity en = GetEntity(id);
            if (en != null)
                en.Visible = f;
        }

        private Entity GetEntity(int id)
        {
            var sel = from e in entities
                      where e.ID == id
                      select e;
            if (sel.Count() != 0)
                return sel.First();
            return null;
        }

        public void SelectPoints(Point a, Point b, bool selecting)
        {
            CurrentEntity.SelectPoints(a, b, selecting);
        }
        public void SelectPoints(Point a,  bool selecting)
        {
            CurrentEntity.SelectPoints(a,  selecting);
        }

        private int CountFolders()
        {
            var res = (from p in entities
                       where p is Folder
                       select p).Count();
            return res;
        }
        private int CountLayers()
        {
            var res = (from p in entities
                       where p is Layer
                       select p).Count();
            return res;
        }

        public void SelectShapes(Point a, Point b, bool selecting)
        {
            CurrentEntity.SelectShapes(a, b, selecting);
        }
        public void SelectShapes(Point a,  bool selecting)
        {
            CurrentEntity.SelectShapes(a, selecting);
        }
        public void Unselect()
        {
            CurrentEntity.Unselect();
        }
        public void UnselectAll()
        {
            foreach (var e in entities)
                e.Unselect();
        }

        public void SelectAll()
        {
            CurrentEntity.SelectAll();
        }

        public bool DeleteSelected()
        {
           return CurrentEntity.DeleteSelected();
        }

        public bool ScaleSelected(float a,float d, Point pivot = null)
        {
            CurrentEntity.ScaleSelected(a, d,pivot);
            return true;
        }

        public void RotateSelected(float angle, Point pivot = null)
        {
            CurrentEntity.RotateSelected(angle);
        }

        public Shape GetShape(Point a)
        {
            return CurrentEntity.GetShape(a);
        }

        public void SetCurrentEntity(int id)
        {
            //current_layer = n < layers.Count && n >= 0 ? n : current_layer;
            Entity en = GetEntity(id);
            if (en != null)
                currentEntity = en;
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
            if(CurrentEntity is Layer)
            ((Layer)CurrentEntity).AddShape(new Shape(TempPoints, is_path));
            TempPoints = new List<Point>();
        }
        public void AddShape(Shape shape)
        {
            if (TempPoints.Count == 0)
                return;
            if (CurrentEntity is Layer)
                ((Layer)CurrentEntity).AddShape(shape);
            TempPoints = new List<Point>();
        }

        public void Display(System.Drawing.Graphics field, System.Drawing.Pen pen)
        {
            foreach (var e in entities)
                e.Display(field, pen);
            DisplayTempPoints(field);
        }

        public void ClearTempVerticies()
        {
            TempPoints.Clear();
        }

        public void center(System.Drawing.Graphics f)
        {
            CurrentEntity.center(f);
        }
    }
}
