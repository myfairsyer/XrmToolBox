using System;
using System.Collections.Generic;
using XrmToolBox.Extensibility.Interfaces;

namespace XrmToolBox.Extensibility
{
    [Serializable]
    public class PluginMetadata : IPluginMetadata
    {
        public PluginMetadata(IDictionary<string, object> items)
        {
            foreach (var item in items)
            {
                switch (item.Key)
                {
                    case "BackgroundColor":
                        BackgroundColor = item.Value != null ? item.Value.ToString() : null;
                        break;

                    case "BigImageBase64":
                        BigImageBase64 = item.Value != null ? item.Value.ToString() : null;
                        break;

                    case "Description":
                        Description = item.Value != null ? item.Value.ToString() : null;
                        break;

                    case "Name":
                        Name = item.Value.ToString();
                        break;

                    case "PrimaryFontColor":
                        PrimaryFontColor = item.Value != null ? item.Value.ToString() : null;
                        break;

                    case "SecondaryFontColor":
                        SecondaryFontColor = item.Value != null ? item.Value.ToString() : null;
                        break;

                    case "SmallImageBase64":
                        SmallImageBase64 = item.Value != null ? item.Value.ToString() : null;
                        break;
                }
            }
        }

        public string BackgroundColor { get; set; }

        public string BigImageBase64 { get; set; }

        public string Description { get; set; }
        public string Name { get; set; }

        public string PrimaryFontColor { get; set; }

        public string SecondaryFontColor { get; set; }

        public string SmallImageBase64 { get; set; }
    }
}