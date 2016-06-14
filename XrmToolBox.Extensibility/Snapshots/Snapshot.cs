using System;
using XrmToolBox.Extensibility.Interfaces;

namespace XrmToolBox.Extensibility
{
    public class Snapshot
    {
        public Snapshot()
        {
            Date = DateTime.Now;
        }

        public IXrmToolBoxPluginControl Plugin { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }

        public DateTime Date { get; private set; }

        public override string ToString()
        {
            return Message;
        }
    }
}
