using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;

namespace WpfYoutube_dl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string youtube_link = "";
        string doelmapPad;
        public MainWindow()
        {

        }

        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            youtube_link = txtYt_link.Text;

            InitializeComponent();

            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "cmd.exe";
            info.RedirectStandardInput = true;
            info.UseShellExecute = false;
            info.WindowStyle = ProcessWindowStyle.Hidden;

            p.StartInfo = info;
            p.Start();

            using (StreamWriter sw = p.StandardInput)
            {
                if (rdbtnMp3.IsChecked == true)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        sw.WriteLine(@"cd " + doelmapPad);
                        sw.WriteLine("youtube-dl  --extract-audio --audio-format mp3 " + youtube_link);
                    }
                } else if (rdbtnMp4.IsChecked == true)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        sw.WriteLine(@"cd " + doelmapPad);
                        sw.WriteLine("youtube-dl " + youtube_link);
                    }
                }

            }
        }

        private void btnKiesmap_Click(object sender, RoutedEventArgs e)
        {
            TextReader tr;
            

            FolderBrowserDialog dlgOpen = new FolderBrowserDialog();
            dlgOpen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dlgOpen.Description = "Kies je doelmap:";
            if (dlgOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                doelmapPad = dlgOpen.SelectedPath;
                txtDoelpad.Text = doelmapPad;
            }
            

            //dlgOpen.Title = "Kies een bestandslocatie:";
            //bool? result;
            //result = dlgOpen.ShowDialog();
            //if (result == true)
            //{
            //    doelmapPad = dlgOpen.InitialDirectory;
            //}
            //else
            //{
            //    return;
            //}
        }
    }
}
