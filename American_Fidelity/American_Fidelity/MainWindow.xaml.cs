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
        private List<AmericanFInfo> americanF = new List<AmericanFInfo>();
        public MainWindow()
        {
            InitializeComponent();

            string[] linesOfFile = File.ReadAllLines("AmericanFidelityInfo.csv");

            for (int i = 1; i < linesOfFile.Length; i++)
            {
                AmericanFInfo entries = new AmericanFInfo(linesOfFile[i], i);
                americanF.Add(entries);


                lst_Softwares.Items.Add(entries.Software);
                if (!lst_Filter.Items.Contains(entries.produced_by))
                {

                    lst_Filter.Items.Add(entries.produced_by);
                }
                if (!lst_Filter.Items.Contains(entries.most_broad_definition))
                {

                    lst_Filter.Items.Add(entries.most_broad_definition);
                }
                if (!lst_Filter.Items.Contains(entries.verb))
                {

                    lst_Filter.Items.Add(entries.verb);
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
            lst_Terms.Items.Remove(lst_Terms.SelectedItem);
        }
        private void Search(object sender, MouseEventArgs e)
        {
            txt_FilterTerms.Text = "";
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            lst_Softwares.Items.Clear();


            foreach (var entry in americanF)
            {
                Boolean check = true;
                foreach (var term in lst_Terms.Items)
                {
                    if (entry.produced_by.Contains(term.ToString()) || entry.most_broad_definition.Contains(term.ToString()) || entry.verb.Contains(term.ToString()))
                    {




                    }
                    else
                    {
                        check = false;
                    }




                }
                if (check == true)
                {
                    if (!lst_Softwares.Items.Contains(entry.Software))
                    {
                        lst_Softwares.Items.Add(entry.Software);
                    }
                }

            }


        }
    }
}

