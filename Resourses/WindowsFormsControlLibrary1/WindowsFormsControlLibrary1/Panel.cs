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
        public string Name { get { return Name; } set { label1.Text = value; } }
        
        
        public bool IsVisible { get { return checkBox1.Checked; } }
        public bool IsSelected { get { return selected; } }

        private bool selected;

        protected int id;


        public Panel(string name) : this()
        {
            Name = name;
        }

        public Panel()
        {
            InitializeComponent();
            selected = false;
        }

        public void ChangeSelection()
        {
            selected = !selected;
            BackColor = selected ? SystemColors.ControlDark : SystemColors.Control;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Panel_Click(object sender, EventArgs e)
        {
            ChangeSelection();
        }
    }
}
