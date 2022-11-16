using System;
using System.Reflection;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace SoftwareFinder
{
    [Serializable]
    internal class Software
    {
        public Software()
        {
            Name = Annotation = Type = Version = Developer = Distribution = string.Empty;
        }
        public string Name { get; set; }
        public string Annotation { get; set; }
        public string Type { get; set; }
        public string Version { get; set; }
        public string Developer { get; set; }
        public string Distribution { get; set; }
        public bool IsAllFieldsInitialized()
        {
            return Name != string.Empty && Annotation != string.Empty && Type != string.Empty &&
                   Version != string.Empty && Developer != string.Empty && Distribution != string.Empty;
        }
        public bool IsAllFieldsBlank()
        {
            return Name == string.Empty && Annotation == string.Empty && Type == string.Empty &&
                   Version == string.Empty && Developer == string.Empty && Distribution == string.Empty;
        }
    }
}
