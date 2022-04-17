using mshtml;
using System;
using System.Windows;
using System.Windows.Forms;

namespace WPF_WYSIWYG_HTML_Editor
{
    /// <summary>
    /// Interaction logic for Image.xaml
    /// </summary>
    public partial class Image : Window, IDisposable
    {
        public HTMLDocument doc;

        public Image(HTMLDocument doc)
        {
            this.doc = doc;
            InitializeComponent();
        }


        private void Window_Initialized(object sender, EventArgs e)
        {
            description.Focus();
        }


        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            if (doc != null)
            {
                dynamic r = doc.selection.createRange();
                r.pasteHTML(string.Format(@"<img alt=""{1}"" src=""{0}"">", link.Text, description.Text));
                Hide();
            }
        }


        public void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = GetImageFilter(),
                FilterIndex = 2,
                RestoreDirectory = true,
            };
            DialogResult result = openFileDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                link.Text = openFileDialog.FileName;
            }
        }


        private static string GetImageFilter()
        {
            return
                "All Files (*.*)|*.*" +
                "|All Pictures (*.emf;*.wmf;*.jpg;*.jpeg;*.jfif;*.jpe;*.png;*.bmp;*.dib;*.rle;*.gif;*.emz;*.wmz;*.tif;*.tiff;*.svg;*.ico)" +
                    "|*.emf;*.wmf;*.jpg;*.jpeg;*.jfif;*.jpe;*.png;*.bmp;*.dib;*.rle;*.gif;*.emz;*.wmz;*.tif;*.tiff;*.svg;*.ico" +
                "|Windows Enhanced Metafile (*.emf)|*.emf" +
                "|Windows Metafile (*.wmf)|*.wmf" +
                "|JPEG File Interchange Format (*.jpg;*.jpeg;*.jfif;*.jpe)|*.jpg;*.jpeg;*.jfif;*.jpe" +
                "|Portable Network Graphics (*.png)|*.png" +
                "|Bitmap Image File (*.bmp;*.dib;*.rle)|*.bmp;*.dib;*.rle" +
                "|Compressed Windows Enhanced Metafile (*.emz)|*.emz" +
                "|Compressed Windows MetaFile (*.wmz)|*.wmz" +
                "|Tag Image File Format (*.tif;*.tiff)|*.tif;*.tiff" +
                "|Scalable Vector Graphics (*.svg)|*.svg" +
                "|Icon (*.ico)|*.ico";
        }



        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Dispose();
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}
