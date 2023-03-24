using HtmlRefactoringWindowsApp.Css;

namespace HtmlRefactoringWindowsApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            textBoxStartLoadTime.Text = DateTime.Now.TimeOfDay.ToString();

            var stringList = System.IO.File.ReadLines(textBoxFileName.Text).ToList();

            var combinedString = string.Join("\r\n", stringList);

            textBoxStartValidationTime.Text = DateTime.Now.TimeOfDay.ToString();

            var cssProperies = new CssProperties(combinedString);

            textBoxEndValidationTime.Text = DateTime.Now.TimeOfDay.ToString();

            textBoxNumberOfProperties.Text = cssProperies.Count.ToString();
        }
    }
}