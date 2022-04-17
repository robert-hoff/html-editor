using System.Windows.Controls;
using System.Windows.Navigation;
using mshtml;

namespace WPF_WYSIWYG_HTML_Editor
{
    /// <summary>
    /// Interaction logic for WebBrowser.xaml
    /// </summary>
    public partial class WPFWebBrowser : UserControl
    {
        public HTMLDocument doc;
        public WebBrowser webBrowser;

        public WPFWebBrowser()
        {
            InitializeComponent();
        }

        public void NewWb(string url)
        {
            if (webBrowser != null)
            {
                webBrowser.LoadCompleted -= Completed;
                webBrowser.Dispose();
                gridwebBrowser.Children.Remove(webBrowser);
            }

            if (doc != null)
            {
                doc.clear();
            }

            webBrowser = new WebBrowser();
            webBrowser.LoadCompleted += Completed;
            gridwebBrowser.Children.Add(webBrowser);

            Script.HideScriptErrors(webBrowser, true);

            if (url == "")
            {
                webBrowser.NavigateToString(Properties.Resources.New);
                doc = webBrowser.Document as HTMLDocument;
                doc.designMode = "On";
                Format.doc = doc;
                return;
            }
            else
            {
                webBrowser.Navigate(url);
            }


            doc = webBrowser.Document as HTMLDocument;
            Format.doc = doc;
        }

        private void Completed(object sender, NavigationEventArgs e)
        {
            doc = webBrowser.Document as HTMLDocument;
            doc.designMode = "On";
        }

    }
}
