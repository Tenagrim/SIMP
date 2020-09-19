using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary1
{
    public partial class Panel : UserControl
    {

        public int ID { get { return id; } }
        public string Name_ { get { return name; } set { label1.Text = value; name = value; } }

        public FolderPanel Parent_ { get { return parent; } set { parent = value; } }

        public bool IsVisible { get { return checkBox1.Checked; } }
        public bool IsSelected { get { return selected; } }

        protected bool selected;
        protected FolderPanel parent;
        protected string name;
        protected DocumentStructureViewer superParent;
        protected bool isCurrent;

        protected int id;


        public Panel(string name) : this()
        {
            Name_ = name;
        }

        public Panel()
        {
            InitializeComponent();
            selected = false;
            isCurrent = false;
        }

        public void ChangeSelection()
        {
            selected = !selected;
            BackColor = selected ? SystemColors.ControlDark : SystemColors.Control;
        }

        public void ChangeIsCurrent()
        {
            isCurrent = !isCurrent;
            BackColor = isCurrent ? SystemColors.ActiveCaption : SystemColors.Control;
        }

        public void RemoveMe()
        {
            if (parent != null)
                parent.RemoveChild(this);
        }
        
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x0084;
            const int HTTRANSPARENT = (-1);

            if (m.Msg == WM_NCHITTEST)
            {
                m.Result = (IntPtr)HTTRANSPARENT;
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            superParent.VisibleChanged_(this);
        }
    }
}
