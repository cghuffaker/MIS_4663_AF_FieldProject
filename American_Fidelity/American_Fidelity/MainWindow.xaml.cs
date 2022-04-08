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
using System.Windows.Shapes;

namespace American_Fidelity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string[] linesOfFile = File.ReadAllLines("ARIS_SoftwareCatalog_OUProject.csv");

            for (int i = 1; i < linesOfFile.Length; i++)
            {
                Software entries = new Software(linesOfFile[i], i);

                lst_Softwares.Items.Add(entries.Name);
            }


        //private void lst_Attributes_SelectionChanged(object sender, SelectionChangedEventArgs e)
       // {

        }
    }
}
