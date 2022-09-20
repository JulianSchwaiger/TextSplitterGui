using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace TextSplitterGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string currentDir = Environment.CurrentDirectory;
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string inputFile = textBox1.Text;

            var filePath = Path.Combine(currentDir, inputFile);

            var reader = File.OpenText(filePath);

            var fullText = reader.ReadToEnd();
            reader.Close();

            int count = 1;
            foreach (var s in fullText.AsEnumerable())
            {
                if(!s.Equals(' ')) //Checks for spaces 😐
                {
                    var writer = File.CreateText($"{desktopPath}{Path.DirectorySeparatorChar}{count}_{s}🤓.txt");
                    writer.WriteLine(s);
                    writer.Close();
                    count++;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();


            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".txt";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                textBox1.Text = filename;
                btnDoSplit.IsEnabled = true;
            }
        }
    }
}
