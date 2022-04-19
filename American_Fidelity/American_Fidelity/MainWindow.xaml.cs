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

            string[] linesOfFile = File.ReadAllLines("AmericanFidelityInfo.csv");

            for (int i = 1; i < linesOfFile.Length; i++)
            {
                AmericanFInfo entries = new AmericanFInfo(linesOfFile[i], i);
                lst_Softwares.Items.Add(entries.Software.ToString().ToLower());
                if (!lst_Filter.Items.Contains(entries.produced_by))
                {
                    lst_Filter.Items.Add(entries.produced_by.ToString().ToLower());
                }
                if (!lst_Filter.Items.Contains(entries.most_broad_definition))
                {
                    lst_Filter.Items.Add(entries.most_broad_definition.ToString().ToLower());
                }
                if (!lst_Filter.Items.Contains(entries.verb))
                {
                    lst_Filter.Items.Add(entries.verb.ToString().ToLower());
                }

            }

        }
        private void lst_Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!lst_Terms.Items.Contains(lst_Filter.SelectedItem))//checks to see if the item being selected is already in the list of sorted items
            {
                lst_Terms.Items.Add(lst_Filter.SelectedItem);
            }
        }
        private void lst_Terms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string remove = lst_Terms.SelectedItem.ToString().ToLower();
            //lst_Terms.Items.Remove(remove);
        }
        private void Search(object sender, MouseEventArgs e)
        {
            txt_FilterTerms.Text = "";
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            lst_Softwares.Items.Clear();
            //if()
        }
    }
}

