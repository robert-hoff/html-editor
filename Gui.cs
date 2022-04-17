using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using mshtml;


namespace WPF_WYSIWYG_HTML_Editor
{
    public static class Gui
    {
        public static WPFWebBrowser webBrowser;
        public static HtmlEditor htmlEditor;

        public static List<Items> RibbonComboboxFormatInitionalisation()
        {
            return new List<Items>
            {
                new Items("<p>", "Paragraph"),
                new Items("<h1>", "Heading 1"),
                new Items("<h2>", "Heading 2"),
                new Items("<h3>", "Heading 3"),
                new Items("<h4>", "Heading 4"),
                new Items("<h5>", "Heading 5"),
                new Items("<h6>", "Heading 6"),
                new Items("<address>", "Adress"),
                new Items("<pre>", "Preformat")
            };
        }

        public static List<string> RibbonComboboxFontSizeInitialisation()
        {

            Debug.WriteLine($"je;;p");

            List<string> items = new List<string>();
            for (int x = 1; x <= 7; x++)
            {

                items.Add(x.ToString());
            }
            return items;
        }

        public static void SettingsFontColor()
        {
            webBrowser.doc = webBrowser.webBrowser.Document as HTMLDocument;
            if (webBrowser.doc != null)
            {
                System.Windows.Media.Color col = DialogBox.Pick();
                string colorstr = string.Format("#{0:X2}{1:X2}{2:X2}", col.R, col.G, col.B);
                webBrowser.doc.execCommand("ForeColor", false, colorstr);
            }
        }

        public static void SettingsBackColor()
        {
            webBrowser.doc = webBrowser.webBrowser.Document as HTMLDocument;
            if (webBrowser.doc != null)
            {
                System.Windows.Media.Color col = DialogBox.Pick();
                string colorstr = string.Format("#{0:X2}{1:X2}{2:X2}", col.R, col.G, col.B);
                webBrowser.doc.body.style.background = colorstr;
            }
        }

        public static void SettingsAddLink()
        {
            using (Link link = new Link(webBrowser.doc))
            {
                link.ShowDialog();
            }
        }

        public static void SettingsAddImage()
        {
            using (Image image = new Image(webBrowser.doc))
            {
                image.ShowDialog();
            }
        }

        public static void RibbonButtonSave()
        {
            dynamic doc = webBrowser.doc;
            dynamic htmlText = doc.documentElement.InnerHtml;
            string path = DialogBox.SaveFile();
            if (path != "")
            {
                File.WriteAllText(path, htmlText);
            }
        }

        public static void RibbonComboboxFonts(ComboBox RibbonComboboxFonts)
        {
            if (webBrowser.webBrowser.Document is HTMLDocument doc)
            {
                doc.execCommand("FontName", false, RibbonComboboxFonts.SelectedItem.ToString());
            }
        }

        public static void RibbonComboboxFontHeight(ComboBox RibbonComboboxFontHeight)
        {
            if (webBrowser.webBrowser.Document is IHTMLDocument2 doc)
            {
                doc.execCommand("FontSize", false, RibbonComboboxFontHeight.SelectedItem);
            }
        }

        public static void RibbonComboboxFormat(ComboBox RibbonComboboxFormat)
        {
            string ID = ((Items) RibbonComboboxFormat.SelectedItem).Value;

            webBrowser.doc = webBrowser.webBrowser.Document as HTMLDocument;
            if (webBrowser.doc != null)
            {
                webBrowser.doc.execCommand("FormatBlock", false, ID);
            }
        }

        public static void EditWeb()
        {
            if (webBrowser.Visibility == Visibility.Visible)
            {
                return;
            }
            htmlEditor.Visibility = Visibility.Hidden;
            webBrowser.Visibility = Visibility.Visible;
            htmlEditor.Editor.SelectAll();
            webBrowser.doc.body.innerHTML = htmlEditor.Editor.Selection.Text;
        }

        public static void ViewHTML()
        {
            if (htmlEditor.Visibility == Visibility.Visible)
            {
                return;
            }
            htmlEditor.Visibility = Visibility.Visible;
            webBrowser.Visibility = Visibility.Hidden;
            htmlEditor.Editor.Selection.Text = webBrowser.doc.documentElement.innerHTML;
        }

        public static void NewDocument()
        {
            webBrowser.NewWb("");
        }

        public static void NewDocumentFile()
        {
            // check that a file was targeted for open (dialog returns null if the user cancels)
            string fileContent = DialogBox.SelectFile();
            if (fileContent != null)
            {
                webBrowser.NewWb(fileContent);
            }
        }
    }
}
