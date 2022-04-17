using System.Windows.Controls;
using System.Windows.Documents;

namespace WPF_WYSIWYG_HTML_Editor
{
    /// <summary>
    /// Interaction logic for HtmlEditor.xaml
    /// </summary>
    public partial class HtmlEditor : UserControl
    {
        public HtmlEditor()
        {
            InitializeComponent();
        }

        public void SpaceLine(int space)
        {
            Paragraph p = Editor.Document.Blocks.FirstBlock as Paragraph;
            p.LineHeight = space;
        }
    }
}
