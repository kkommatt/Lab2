using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareFinder
{
    internal class ResultsPrinter
    {
        private readonly RichTextBox _outputBox;
        public ResultsPrinter(RichTextBox outputBox)
        {
            _outputBox = outputBox;
        }

        public void Print(IEnumerable<(string service, List<Software> foundedSoftware)> results)
        {
            _outputBox.Text = string.Empty;
            foreach (var (service, foundedSoftware) in results)
            {
                _outputBox.AppendText($"\n{service}:\n");

                var outputNumber = 1;
                foreach (var softwareOutput in foundedSoftware
                    .Select(software => $"{outputNumber}:\n" +
                                    $"  Name: {software.Name}\n" +
                                    $"  Annotation: {software.Annotation}\n" +
                                    $"  Type: {software.Type}\n" +
                                    $"  Version: {software.Version}\n" +
                                    $"  Developer: {software.Developer}\n" +
                                    $"  Distribution: {software.Distribution}\n"))
                {
                    _outputBox.AppendText(softwareOutput);
                    ++outputNumber;
                }
            }
        }
    }
}
    

