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
        private List<string> trial = new List<string>();
        public MainWindow()
        {
            InitializeComponent();

            string[] linesOfFile = File.ReadAllLines("AmericanFidelityInfo.csv");

            for (int i = 1; i < linesOfFile.Length; i++)
            {
                AmericanFInfo entries = new AmericanFInfo(linesOfFile[i], i);
                americanF.Add(entries);


                lst_Softwares.Items.Add(entries);
                if (!lst_Filter.Items.Contains(entries.produced_by))
                {
                    trial.Add(entries.produced_by.Trim());
                    lst_Filter.Items.Add(entries.produced_by.Trim());
                }
                if (!lst_Filter.Items.Contains(entries.most_broad_definition))
                {
                    trial.Add(entries.most_broad_definition.Trim());
                    lst_Filter.Items.Add(entries.most_broad_definition.Trim());
                }
                if (!lst_Filter.Items.Contains(entries.verb.Trim()))
                {
                    trial.Add(entries.verb.Trim());
                    lst_Filter.Items.Add(entries.verb.Trim());
                }

            }

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
                foreach (string term in lst_Terms.Items)
                {
                    if (!string.IsNullOrEmpty(term) && (entry.produced_by.Contains(term.ToString()) || entry.most_broad_definition.Contains(term.ToString()) || entry.verb.Contains(term.ToString())))
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
                        lst_Softwares.Items.Add(entry);
                    }
                }

            }


        }

        private void TypeSearch(object sender, TextChangedEventArgs e)
        {
            lst_Filter.Items.Clear();

            foreach (var item in trial)
            {


                if (item.ToString().ToLower().Contains(txt_FilterTerms.Text))
                {

                    lst_Filter.Items.Add(item.Trim());
                }

            }
        }
        private void selectTerm(object sender, MouseButtonEventArgs e)
        {
            if (!lst_Terms.Items.Contains(lst_Filter.SelectedItem))//checks to see if the item being selected is already in the list of sorted items
            {
                lst_Terms.Items.Add(lst_Filter.SelectedItem);

            }
        }

        private void softwareDetail(object sender, MouseButtonEventArgs e)
        {
            softwareCom win = new softwareCom();
            AmericanFInfo select = (AmericanFInfo)lst_Softwares.SelectedItem;

            win.PopulateData(select);
            win.ShowDialog();
        }

        private void RemoveTerm(object sender, MouseButtonEventArgs e)
        {
            lst_Terms.Items.Remove(lst_Terms.SelectedItem);
        }
    }
}

