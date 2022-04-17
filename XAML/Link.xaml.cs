using System;
using System.Windows;
using mshtml;

namespace WPF_WYSIWYG_HTML_Editor
{
    /// <summary>
    /// Interaction logic for Link.xaml
    /// </summary>
    public partial class Link : Window, IDisposable
    {
        public HTMLDocument doc;

        public Link(HTMLDocument Doc)
        {
            InitializeComponent();
            doc = Doc;
        }

        private void AddLink_Initialized(object sender, EventArgs e)
        {
            description.Focus();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            if (doc != null)
            {
                dynamic r = doc.selection.createRange();
                r.pasteHTML(string.Format(@"<a href='{0}'target=""_blank"">{1}</a>", link.Text, description.Text));
                this.Hide();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\";
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                System.Windows.Forms.DialogResult result = openFileDialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    link.Text = openFileDialog.FileName;
                }
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Dispose();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
