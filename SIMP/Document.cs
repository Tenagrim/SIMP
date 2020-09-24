using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMP
{
    [Serializable]
    class Document
    {
        //public List<Layer> Layers { get { return layers; } }
        public List<Entity> Entities { get { return entities; } }
        public Entity CurrentEntity { get { return currentEntity; } }
        public List<Point> SelectedPoints { get { return CurrentEntity.SelectedPoints; } }
        public List<Shape> SelectedShapes { get { return GetSelectedShapes(); } }
        public Entity LastAdded { get { return last_added; } }
        public Projection Projection { get; set; }

        public Point ViewPortSize { get; set; }
        public List<Point> TempPoints { get; set; }
        private Entity currentEntity;
        private List<Entity> entities;
        private Entity last_added;
        private int last_id;

        public Document(Point VewSize) : this()
        {
            ViewPortSize = VewSize;
            Projection = new Projection(ViewPortSize);
        }
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
            List<Shape> selected = SelectedShapes;
            Layer l;
            last_id++;
            if (selected.Count == 0)
                l = new Layer(last_id, last_id);
            else
                l = new Layer(last_id, last_id, selected);

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
            Entity res = null;
            var sel = from e in entities
                      where e.ID == id
                      select e;
            if (sel.Count() != 0)
                return sel.First();
            else
            {
                foreach (var c in entities)
                {
                    if (c is Folder)
                        res = ((Folder)c).GetEntity(id);
                    if (res != null)
                        return res;
                }
            }
            return null;
        }
        private List<Entity> GetEntities(int[] ids)
        {
            List<Entity> res = new List<Entity>();
            Entity tmp;
            foreach (var i in ids)
            {
                tmp = GetEntity(i);
                if (tmp != null)
                    res.Add(tmp);
            }
            return res;
        }
        public void SelectPoints(Point a, Point b, bool selecting)
        {
            CurrentEntity.SelectPoints(a, b, selecting);
        }
        public void SelectPoints(Point a, bool selecting)
        {
            CurrentEntity.SelectPoints(a, selecting);
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
        public void SelectShapes(Point a, bool selecting)
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
        public void UnsetChilds(int[] ids)
        {
            List<Entity> ents = GetEntities(ids);
            foreach (var e in ents)
            {
                e.RemoveMe();
                entities.Add(e);
            }
        }
        public void SelectAll()
        {
            CurrentEntity.SelectAll();
        }
        public bool DeleteSelected()
        {
            return CurrentEntity.DeleteSelected();
        }
        public bool ScaleSelected(float a, float d, Point pivot = null)
        {
            CurrentEntity.ScaleSelected(a, d, pivot);
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
        public void DeleteEntity(int[] ids)
        {
            foreach (var i in ids)
                DeleteEntity(i);
        }
        public void DeleteEntity(int id)
        {
            Entity ent = GetEntity(id);
            DeleteEntity(ent);
        }
        private void DeleteEntity(Entity ent)
        {
            if (ent != null)
            {
                if (ent.Parent == null)
                    entities.Remove(ent);
                else
                    ent.RemoveMe();
                if (ent is Folder)
                    ((Folder)ent).DeleteChilds();
            }
        }
        private void DeleteChilds(int id)
        {
            Entity ent = GetEntity(id);
            if (!(ent is Folder))
                return;
            ((Folder)ent).DeleteChilds();
        }
        public void AddChilds(int parent_id, int[] new_childs)
        {
            Entity parent = GetEntity(parent_id);
            List<Entity> childs = GetEntities(new_childs);
            if (parent != null && parent is Folder)
                ((Folder)parent).AddChilds(childs);
            RemoveEntities(childs);
        }
        public void RemoveEntities(List<Entity> ents)
        {
            foreach (var e in ents)
                entities.Remove(e);
        }
        private List<Shape> GetSelectedShapes()
        {
            List<Shape> res = new List<Shape>();
            foreach (var c in entities)
                res.AddRange(c.SelectedShapes);
            return res;
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
            Shape.DrawAsShape(Projection, field, TempPoints, pen);
            pen.Dispose();
        }
        public void AddShape(bool is_path = false)
        {
            if (TempPoints.Count == 0)
                return;
            if (CurrentEntity is Layer)
                ((Layer)CurrentEntity).AddShape(new Shape((Layer)CurrentEntity, TempPoints, is_path));
            TempPoints = new List<Point>();
        }
        public void AddLine()
        {
            if (!(CurrentEntity is Layer))
                throw new ArgumentException();

            if (TempPoints.Count >= 2)
            {
                Line l = new Line((Layer)CurrentEntity, TempPoints[0], TempPoints[1]);
                AddShape(l);
                TempPoints.Clear();
            }
        }
        public void AddShape(Shape shape)
        {
 //           if (TempPoints.Count == 0)
 //               return;
            if (CurrentEntity is Layer)
                ((Layer)CurrentEntity).AddShape(shape);
 //           TempPoints = new List<Point>();
        }
        public void Display(System.Drawing.Graphics field, System.Drawing.Pen pen)
        {
            foreach (var e in entities)
                e.Display(field, pen, Projection);
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
        public void SyncUi(WindowsFormsControlLibrary1.DocumentStructureViewer dc)
        {
            foreach (var e in entities)
            {
                if (e is Folder)
                {
                    dc.AddFolder(e.Name, e.ID);
                    SyncFolder(dc, (Folder)e);
                }
                else if (e is Layer)
                {
                    dc.AddLayer(e.Name, e.ID);
                }
            }
            if (currentEntity != null)
                dc.SetCurrentEntity(currentEntity.ID);
            dc.UpdateList();
        }
        private void SyncFolder(WindowsFormsControlLibrary1.DocumentStructureViewer dc, Folder folder)
        {
            foreach (var e in folder.childs)
            {
                if (e is Folder)
                {
                    dc.AddFolder(e.Name, e.ID);
                    dc.AddChild(e.ID, folder.ID);
                    SyncFolder(dc, (Folder)e);
                }
                else if (e is Layer)
                {
                    dc.AddLayer(e.Name, e.ID);
                    dc.AddChild(e.ID, folder.ID);
                }
            }
        }
    }
}
