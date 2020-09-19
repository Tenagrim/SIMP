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
        public int CurrentEntityId;
        public int NewParent;
        public bool flag;

        public DocumentStructureArgs(int[] selected, int curEnt, int newParent, bool flag)
        {
            SelectedIds = selected;
            CurrentEntityId = curEnt;
            NewParent = newParent;
            this.flag = flag;
        }
    }


}
