using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;

namespace XrmToolBox.Forms
{
    internal partial class SnapshotsDialog : Form
    {
        private readonly SnapshotManager sManager;

        private ISnapshotable plugin;

        public ISnapshotable Plugin {
            get { return plugin; }
            internal set {
                plugin = value;

                lbSnapshots.Items.Clear();
                if (plugin != null)
                {
                    lbSnapshots.Items.AddRange(sManager.Snapshots.OrderBy(s => s.Date).Where(s => s.Plugin == plugin).ToArray());
                    if (lbSnapshots.Items.Count > 0)
                    {
                        lbSnapshots.TopIndex = lbSnapshots.Items.Count - 1;
                    }
                }
            }
        }

        public SnapshotsDialog(SnapshotManager sManager, ISnapshotable plugin = null)
        {
            InitializeComponent();

            this.sManager = sManager;
            this.sManager.SnapshotAdded += SManager_SnapshotAdded;
            this.plugin = plugin;
        }

        private void SManager_SnapshotAdded(object sender, SnapshotAddedEventArgs e)
        {
            lbSnapshots.Items.Add(e.SnapshotData);
            lbSnapshots.TopIndex = lbSnapshots.Items.Count - 1;
        }

        private void SnapshotsDialog_Load(object sender, EventArgs e)
        {
            if (plugin != null)
            {
                lbSnapshots.Items.AddRange(sManager.Snapshots.OrderBy(s => s.Date).Where(s => s.Plugin == plugin).ToArray());
            }

            if (lbSnapshots.Items.Count > 0)
            {
                lbSnapshots.TopIndex = lbSnapshots.Items.Count - 1;
            }
        }

        private void tsbRestore_Click(object sender, EventArgs e)
        {
            if(plugin != null)
            {
                plugin.RestoreSnapshot((Snapshot)lbSnapshots.SelectedItem);
            }
        }
    }
}
