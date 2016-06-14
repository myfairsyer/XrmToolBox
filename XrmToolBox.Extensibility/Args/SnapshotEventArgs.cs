using System;
using System.Collections.Generic;
using System.Linq;
using XrmToolBox.Extensibility.Interfaces;

namespace XrmToolBox.Extensibility.Args
{
    public class SnapshotEventArgs : EventArgs
    {
        public SnapshotEventArgs(string description, object snapshotData)
        {
            Description = description;
            SnapshotData = snapshotData;
        }

        public string Description { get; set; }

        public object SnapshotData { get; set; }
    }
}
