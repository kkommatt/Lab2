using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace SoftwareFinder
{
    internal class HTMLConverter
    {
        internal List<Software> _outputSoftwares;
        internal SoftwareFinderForm _form;

        public HTMLConverter(IEnumerable<(string service, List<Software> foundedSoftwares)> results, SoftwareFinderForm form)
        {
            _outputSoftwares = new List<Software>();
            foreach (var (_, foundedSoftwares) in results)
            {
                _outputSoftwares.AddRange(foundedSoftwares);
            }

            _form = form;
        }

        public void Convert()
        {
            if (_outputSoftwares.Count != 0 && _form.HTMLSaveDialog.ShowDialog() == DialogResult.OK)
            {
                var htmlPath = _form.HTMLSaveDialog.FileName;
                var xmlPath = ExtractResultsInTempXML(htmlPath);

                TransformWithTemplate(xmlPath, htmlPath);
                RemoveTempXML(xmlPath);
            }
        }

        private string ExtractResultsInTempXML(string htmlPath)
        {
            var xmlFilePath = htmlPath.Replace(".html", ".xml");
            
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            
            using XmlWriter writer = XmlWriter.Create(xmlFilePath, settings);
            writer.WriteStartElement("Softwares");
            
            foreach (var x in _outputSoftwares)
            {
                writer.WriteStartElement("Software");
                writer.WriteElementString("Name", x.Name.ToString());
                writer.WriteElementString("Annotation", x.Annotation.ToString());
                writer.WriteElementString("Type", x.Type.ToString());
                writer.WriteElementString("Version", x.Version.ToString());
                writer.WriteElementString("Developer", x.Developer.ToString());
                writer.WriteElementString("Distribution", x.Distribution.ToString());
                writer.WriteEndElement();
            }
            
            writer.WriteEndElement();

            return xmlFilePath;
        }

        private static void TransformWithTemplate(string xmlPath, string htmlPath)
        {
            var xslt = new XslCompiledTransform();
            xslt.Load(@"C:\унік\ООП\SoftwareFinder\SoftwareFinder\HTMLTemplate.xsl");
            xslt.Transform(xmlPath, htmlPath);
        }

        private static void RemoveTempXML(string xmlPath)
        {
            File.Delete(xmlPath);
        }
    }

}
