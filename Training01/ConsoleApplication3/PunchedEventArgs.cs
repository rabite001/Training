using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class PunchedEventArgs : EventArgs
    {
        public PunchedEventArgs(string name, int count, string tool)
        {
            this.Name = name;
            this.Count = count;
            this.Tool = tool;
        }
        public string Name { get; private set; }
        public int Count { get; private set; }
        public string Tool { get; private set; }
    }
}
