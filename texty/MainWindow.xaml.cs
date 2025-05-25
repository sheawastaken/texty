using System.IO.Enumeration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace texty
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
        private void New_Click(object sender, RoutedEventArgs e)
        {
            TextContent.Text = string.Empty;
            Title = "New - Texty";
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                TextContent.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
                string filePath = openFileDialog.FileName;
                Title = $"{System.IO.Path.GetFileName(filePath)} - Texty";
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, TextContent.Text);
                Title = $"{System.IO.Path.GetFileName(saveFileDialog.FileName)} - Texty";
            }
        }
    }
}