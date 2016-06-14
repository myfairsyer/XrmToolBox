using System;
using System.Collections.Generic;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;

namespace XrmToolBox.Extensibility
{
    public class SnapshotManager
    {
        private readonly List<Snapshot> snapshots;

        public SnapshotManager()
        {
            snapshots = new List<Snapshot>();
        }

        public event EventHandler<SnapshotAddedEventArgs> SnapshotAdded;

        public List<Snapshot> Snapshots { get { return snapshots; } }

        public void AddSnapShot(Snapshot snapshot)
        {
            snapshots.Add(snapshot);

            if(SnapshotAdded != null)
            {
                SnapshotAdded(this, new SnapshotAddedEventArgs { SnapshotData = snapshot });
            }
        }

        public void RemoveSnapshot(Snapshot snapshot)
        {
            snapshots.Remove(snapshot);
        }

        public void ClearPluginSnapshots(ISnapshotable sCtrl)
        {
            for(int i=snapshots.Count - 1; i>=0; i--)
            {
                if(snapshots[i].Plugin == sCtrl)
                {
                    snapshots.RemoveAt(i);
                }
            }
        }
    }
}
