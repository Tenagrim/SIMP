using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsControlLibrary1
{
    public class DocumentStructureArgs : EventArgs
    {
        public int[] SelectedIds { get; set; }
        public int CurrentEntity;
        public int NewParent;
    }
}
