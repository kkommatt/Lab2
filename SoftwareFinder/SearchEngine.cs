using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace SoftwareFinder
{
    internal class SearchEngine
    {
        public readonly Software _desiredSoftware;
        public readonly ISearchEngineStrategy _engine;

        public SearchEngine(Software desiredSoftware, ISearchEngineStrategy engine)
        {
            _desiredSoftware = desiredSoftware;
            _engine = engine;
        }

        public List<(string service, List<Software> foundedSoftwares)> ScanAllFiles()
        {
            var results = new List<(string, List<Software>)>();

            var filesPaths = FilesProvider.GetInstance.FilesPaths;
            var servicesNames = FilesProvider.GetInstance.ServicesNames;

            for (var i = 0; i < filesPaths.Length; ++i)
            {
                var serviceName = servicesNames[i];
                var filePath = filesPaths[i];
                var foundedSoftwareInFaculty = _engine.DoSearchInFile(filePath, _desiredSoftware);

                results.Add((serviceName, foundedSoftwareInFaculty));
            }

            return results;
        }
    }

    // Strategy
    internal interface ISearchEngineStrategy
    {
        List<Software> DoSearchInFile(string filePath, Software desiredSoftware);
    }

    // Concrete Strategy A
    internal class EngineDOM : ISearchEngineStrategy
    {
        public List<Software> DoSearchInFile(string filePath, Software desiredSoftware)
        {
            var foundedSoftware = new List<Software>();

            var xDoc = new XmlDocument();
            xDoc.Load(filePath);
            var xRoot = xDoc.DocumentElement;

            var softwareNodes = xRoot?.SelectNodes("Software");
            if (softwareNodes != null)
            {
                foreach (XmlElement software in softwareNodes)
                {
                    var newSoftware = new Software();

                    foreach (XmlElement element in software)
                    {
                        if (element.Name == "Name" && (string.IsNullOrWhiteSpace(desiredSoftware.Name) ||
                                                        ElementsComparer.IsEqual(element.InnerText,
                                                            desiredSoftware.Name)))
                        {
                            newSoftware.Name = element.InnerText;
                        }

                        else if (element.Name == "Annotation" && (string.IsNullOrWhiteSpace(desiredSoftware.Annotation) ||
                                                             element.InnerText.ToUpper()
                                                                 .Contains(desiredSoftware.Annotation.ToUpper())))
                        {
                            newSoftware.Annotation = element.InnerText;
                        }

                        else if (element.Name == "Type" && (string.IsNullOrWhiteSpace(desiredSoftware.Type) ||
                                                             ElementsComparer.IsEqual(element.InnerText,
                                                                 desiredSoftware.Type)))
                        {
                            newSoftware.Type = element.InnerText;
                        }

                        else if (element.Name == "Version" && (string.IsNullOrWhiteSpace(desiredSoftware.Version) ||
                                                             ElementsComparer.IsEqual(element.InnerText,
                                                                 desiredSoftware.Version)))
                        {
                            newSoftware.Version = element.InnerText;
                        }

                        else if (element.Name == "Developer" && (string.IsNullOrWhiteSpace(desiredSoftware.Developer) ||
                                                              ElementsComparer.IsEqual(element.InnerText,
                                                                  desiredSoftware.Developer)))
                        {
                            newSoftware.Developer = element.InnerText;
                        }

                        else if (element.Name == "Distribution" && (string.IsNullOrWhiteSpace(desiredSoftware.Distribution) ||
                                                              element.InnerText.ToUpper()
                                                                  .Contains(desiredSoftware.Distribution.ToUpper())))
                        {
                            newSoftware.Distribution = element.InnerText;
                        }
                    }

                    if (newSoftware.IsAllFieldsInitialized())
                    {
                        foundedSoftware.Add(newSoftware);
                    }
                }
            }

            return foundedSoftware;
        }
    }

    // Concrete Strategy B
    internal class EngineSAX : ISearchEngineStrategy
    {
        public List<Software> DoSearchInFile(string filePath, Software desiredSoftware)
        {
            var foundedSoftware = new List<Software>();
            using (var xr = XmlReader.Create(filePath))
            {
                var iteratorSoftware = new Software();

                var element = string.Empty;
                while (xr.Read())
                {
                    // Reads the element
                    if (xr.NodeType == XmlNodeType.Element)
                    {
                        element = xr.Name; // The name of the current element
                    }
                    // Reads the element value
                    else if (xr.NodeType == XmlNodeType.Text)
                    {
                        if (element == "Name" && (string.IsNullOrWhiteSpace(desiredSoftware.Name) ||
                                                   ElementsComparer.IsEqual(xr.Value,
                                                       desiredSoftware.Name)))
                        {
                            iteratorSoftware.Name = xr.Value;
                        }
                        else if (element == "Annotation" && (string.IsNullOrWhiteSpace(desiredSoftware.Annotation) ||
                                                        xr.Value.ToUpper()
                                                            .Contains(desiredSoftware.Annotation.ToUpper())))
                        {
                            iteratorSoftware.Annotation = xr.Value;
                        }

                        else if (element == "Type" && (string.IsNullOrWhiteSpace(desiredSoftware.Type) ||
                                                        ElementsComparer.IsEqual(xr.Value,
                                                            desiredSoftware.Type)))
                        {
                            iteratorSoftware.Type = xr.Value;
                        }

                        else if (element == "Version" && (string.IsNullOrWhiteSpace(desiredSoftware.Version) ||
                                                        ElementsComparer.IsEqual(xr.Value,
                                                            desiredSoftware.Version)))
                        {
                            iteratorSoftware.Version = xr.Value;
                        }

                        else if (element == "Developer" && (string.IsNullOrWhiteSpace(desiredSoftware.Developer) ||
                                                         ElementsComparer.IsEqual(xr.Value,
                                                             desiredSoftware.Developer)))
                        {
                            iteratorSoftware.Developer = xr.Value;
                        }

                        else if (element == "Distribution" && (string.IsNullOrWhiteSpace(desiredSoftware.Distribution) ||
                                                         xr.Value.ToUpper()
                                                             .Contains(desiredSoftware.Distribution.ToUpper())))
                        {
                            iteratorSoftware.Distribution = xr.Value;
                        }
                    }

                    // Reads the closing element
                    else if ((xr.NodeType == XmlNodeType.EndElement) && (xr.Name == "Software"))
                    {
                        if (iteratorSoftware.IsAllFieldsInitialized())
                        {
                            var newSoftware = iteratorSoftware;
                            foundedSoftware.Add(newSoftware);
                            iteratorSoftware = new Software();
                        }
                    }
                }
            }
            return foundedSoftware;
        }
    }

    // Concrete Strategy C
    internal class EngineLinq : ISearchEngineStrategy
    {
        public List<Software> DoSearchInFile(string filePath, Software desiredSoftware)
        {
            var xdoc = XDocument.Load(filePath);
            var foundedElements = from elem in xdoc.Element("Softwares")?.Elements("Software")
                                  where
                                      (string.IsNullOrWhiteSpace(desiredSoftware.Name) ||
                                       ElementsComparer.IsEqual(elem.Element("Name")?.Value, desiredSoftware.Name)) &&

                                      (string.IsNullOrWhiteSpace(desiredSoftware.Annotation) ||
                                       elem.Element("Annotation").Value.ToUpper().Contains(desiredSoftware.Annotation.ToUpper())) &&

                                      (string.IsNullOrWhiteSpace(desiredSoftware.Type) ||
                                       ElementsComparer.IsEqual(elem.Element("Type")?.Value, desiredSoftware.Type)) &&

                                      (string.IsNullOrWhiteSpace(desiredSoftware.Version) ||
                                       ElementsComparer.IsEqual(elem.Element("Version")?.Value, desiredSoftware.Version)) &&

                                      (string.IsNullOrWhiteSpace(desiredSoftware.Developer) ||
                                       ElementsComparer.IsEqual(elem.Element("Developer")?.Value, desiredSoftware.Developer)) &&

                                      (string.IsNullOrWhiteSpace(desiredSoftware.Distribution) ||
                                       ElementsComparer.IsEqual(elem.Element("Distribution")?.Value, desiredSoftware.Distribution))

                                  select new Software
                                  {
                                      Name = elem.Element("Name")?.Value.ToString(),
                                      Annotation = elem.Element("Annotation")?.Value.ToString(),
                                      Type = elem.Element("Type")?.Value.ToString(),
                                      Version = elem.Element("Version")?.Value.ToString(),
                                      Developer = elem.Element("Developer")?.Value.ToString(),
                                      Distribution = elem.Element("Distribution")?.Value.ToString()
                                  };

            return foundedElements.ToList();
        }
    }
}
