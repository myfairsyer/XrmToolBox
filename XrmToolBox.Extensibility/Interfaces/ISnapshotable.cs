using System;
using XrmToolBox.Extensibility.Args;

namespace XrmToolBox.Extensibility.Interfaces
{
    public interface ISnapshotable
    {
        void RestoreSnapshot(object snapshotData);

        event EventHandler<SnapshotEventArgs> SnapshotSent;
    }
}
