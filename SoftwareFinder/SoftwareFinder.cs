namespace SoftwareFinder
{
    public partial class SoftwareFinderForm : Form
    {
        private List<(string service, List<Software> foundedSoftwares)> _results = new List<(string, List<Software>)>();
        public SoftwareFinderForm()
        {
            InitializeComponent();
        }
        private void ConvertToHTMLButton_Click(object sender, EventArgs e)
        {
            var converter = new HTMLConverter(_results, this);
            converter.Convert();
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            var searcher = new Searcher(this);
            _results = searcher.ExecuteSearch();

            var printer = new ResultsPrinter(ResultsBox);
            printer.Print(_results);
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            ResultsBox.Text = string.Empty;
            _results.Clear();
        }

    }
}