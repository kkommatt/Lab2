using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareFinder
{
    internal class Searcher
    {
        private readonly SoftwareFinderForm _form;
        public Searcher(SoftwareFinderForm form)
        {
            _form = form;
        }

        public List<(string service, List<Software> foundedSoftwares)> ExecuteSearch()
        {
            var desiredSoftware = CreateSearchRequest();
            var engineStrategy = GetSearchEngine();
            if (desiredSoftware == null || engineStrategy == null)
            {
                return new List<(string, List<Software>)>();
            }

            var executiveEngine = new SearchEngine(desiredSoftware, engineStrategy);

            try
            {
                List<(string, List<Software>)> results = executiveEngine.ScanAllFiles();
                return results;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Error occurred while reading an input XML file." +
                                "Try to reload data XML files.",
                    "XML file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<(string, List<Software>)>();
            }
        }

        private Software CreateSearchRequest()
        {
            var desiredSoftware = new Software();

            if (_form.NameCheck.Checked)
            {
                desiredSoftware.Name = _form.NameBox.Text;
            }

            if (_form.AnnotationCheck.Checked)
            {
                desiredSoftware.Annotation = _form.AnnotationBox.Text;
            }

            if (_form.TypeCheck.Checked)
            {
                desiredSoftware.Type = _form.TypeBox.Text;
            }

            if (_form.VersionCheck.Checked)
            {
                desiredSoftware.Version = _form.VersionBox.Text;
            }

            if (_form.DeveloperCheck.Checked)
            {
                desiredSoftware.Developer = _form.DeveloperBox.Text;
            }

            if (_form.DistributionCheck.Checked)
            {
                desiredSoftware.Distribution = _form.DistributionBox.Text;
            }

            return desiredSoftware.IsAllFieldsBlank() ? null : desiredSoftware;
        }

        private ISearchEngineStrategy GetSearchEngine()
        {
            ISearchEngineStrategy searchEngine = null;

            if (_form.DomButton.Checked)
            {
                searchEngine = new EngineDOM();
            }

            if (_form.SaxButton.Checked)
            {
                searchEngine = new EngineSAX();
            }

            if (_form.LinqButton.Checked)
            {
                searchEngine = new EngineLinq();
            }

            return searchEngine;
        }
    }
}
