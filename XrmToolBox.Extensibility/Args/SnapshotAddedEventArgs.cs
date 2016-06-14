using System;

namespace XrmToolBox.Extensibility.Args
{
    public class SnapshotAddedEventArgs : EventArgs
    {
        public Snapshot SnapshotData { get; set; }
    }
}
