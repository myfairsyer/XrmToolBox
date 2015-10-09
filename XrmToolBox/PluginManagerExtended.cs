using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Registration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;
using MessageBox = System.Windows.Forms.MessageBox;

namespace XrmToolBox
{
    public class PluginManagerExtended : MarshalByRefObject
    {
        private static readonly string PluginPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Plugins");
        private CompositionContainer container;
        private DirectoryCatalog directoryCatalog;

        public PluginManagerExtended()
        {
        }

        public PluginManagerExtended(Form parentForm)
        {
        }

        public event EventHandler PluginsListUpdated;

        [ImportMany(AllowRecomposition = true)]
        public IEnumerable<Lazy<IXrmToolBoxPlugin, PluginMetadata>> Plugins { get; set; }

        internal bool HasPlugins { get { return Plugins.Any(); } }

        public List<PluginMetadata> GetPluginMetadata()
        {
            return Plugins.Select(p => p.Metadata).ToList();
        }

        public IEnumerable<Lazy<IXrmToolBoxPlugin, PluginMetadata>> GetPlugins()
        {
            return Plugins;
        }

        public void Initialize()
        {
            try
            {
                var regBuilder = new RegistrationBuilder();
                regBuilder.ForTypesDerivedFrom<Lazy<IXrmToolBoxPlugin, PluginMetadata>>().Export<Lazy<IXrmToolBoxPlugin, PluginMetadata>>();

                var catalog = new AggregateCatalog();
                catalog.Catalogs.Add(new AssemblyCatalog(typeof(PluginManagerExtended).Assembly, regBuilder));

                directoryCatalog = new DirectoryCatalog(PluginPath, regBuilder);
                catalog.Catalogs.Add(directoryCatalog);

                container = new CompositionContainer(catalog);
                container.ComposeParts(this);
            }
            catch (ReflectionTypeLoadException ex)
            {
                if (ex.LoaderExceptions.Length == 1)
                {
                    throw ex.LoaderExceptions[0];
                }
                var sb = new StringBuilder();
                var i = 1;
                sb.AppendLine("Multiple Exception Occured Attempting to Intialize the Plugin Manager");
                foreach (var exception in ex.LoaderExceptions)
                {
                    sb.AppendLine("Exception " + i++);
                    sb.AppendLine(exception.ToString());
                    sb.AppendLine();
                    sb.AppendLine();
                }

                throw new ReflectionTypeLoadException(ex.Types, ex.LoaderExceptions, sb.ToString());
            }
        }

        public void Recompose()
        {
            directoryCatalog.Refresh();
            container.ComposeParts(directoryCatalog.Parts);
            Plugins = container.GetExportedValues<Lazy<IXrmToolBoxPlugin, PluginMetadata>>();
        }

        internal void DoSomething()
        {
            Plugins.ToList().ForEach(p => MessageBox.Show(p.Metadata.Name));
        }

        internal Lazy<IXrmToolBoxPlugin, PluginMetadata> GetOnePlugin(string fullname)
        {
            return Plugins.FirstOrDefault(p => p.Value.GetType().FullName == fullname);
        }

        internal List<string> GetPluginNames()
        {
            return Plugins.ToList().Select(p => p.Metadata.Name).ToList();
        }

        internal List<string> GetPluginsNamesByFilter(string filter)
        {
            var filteredPlugins = (filter != null && filter.ToString().Length > 0
               ? Plugins.Where(p
                   => p.Metadata.Name.ToLower().Contains(filter.ToString().ToLower())
                   || p.Metadata.Description.ToLower().Contains(filter.ToString().ToLower())
                   || p.Value.GetType().GetCompany().ToLower().Contains(filter.ToString().ToLower()))
               : Plugins).OrderBy(p => p.Metadata.Name).Select(p => p.Value.GetType().FullName).ToList();

            return filteredPlugins;
        }
    }
}