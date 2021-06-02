using Chataria.Core;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Controls;


namespace Chataria
{
    /// <summary>
    /// Interaction logic for AttachmentPopup.xaml
    /// </summary>
    public partial class AttachmentPopup : UserControl
    {
        public AttachmentPopup()
        {
            InitializeComponent();
            //DataContext = new AttachmentViewModel();
        }

        /// <summary>
        /// function to attach an image to a message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Open File Explorer
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|jpeg files (*.jpeg)|*.jpeg";
            dialog.Title = "Select an Image File";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;
            dialog.ShowDialog();

            // Save image in local Storage
            if (dialog.FileName != "")
            {
                string[] items = dialog.FileName.Split(@"\");
                string lastItem = items[items.Length - 1];
                string savePath = "C:/Users/fayxs/source/repos/Chataria/Chataria/Storage/Images/" + lastItem;
                try
                {
                    File.Copy(dialog.FileName, savePath);
                } 
                catch { }
                finally
                {
                    // Set Local Storage Path
                    (IoC.Application.CurrentPageViewModel as ChatMessageListViewModel).LocalImagePath = savePath;
                }
            }        
        }
    }
}
